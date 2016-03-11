using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetHttpsForFreeUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static void CreateFileWithContents(string filePath, string contents)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (StreamWriter w = new StreamWriter(filePath))
            {
                w.Write(contents);
                w.Close();
            }
        }
        
        public static string RunExternalExe(string filename, string arguments = null)
        {
            var process = new Process();

            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.Append(args.Data);

            string stdError = null;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception("OS error while executing " + $"'{filename}{((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments)}'" + ": " + e.Message, e);
            }

            if (process.ExitCode == 0)
            {
                return stdOutput.ToString();
            }
            else
            {
                var message = new StringBuilder();

                if (!string.IsNullOrEmpty(stdError))
                {
                    message.AppendLine(stdError);
                }

                if (stdOutput.Length != 0)
                {
                    message.AppendLine("Std output:");
                    message.AppendLine(stdOutput.ToString());
                }

                throw new Exception($"'{filename}{((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments)}'" + " finished with exit code = " + process.ExitCode + ": " + message);
            }
        }

        private void btnOpenSSLExecute_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpPath = Path.Combine(tbPath.Text, "tmp");

                // Create a clean dir
                if (Directory.Exists(tmpPath))
                    Directory.Delete(tmpPath, true);

                Directory.CreateDirectory(tmpPath);

                string accountKey = Path.Combine(tbPath.Text, tbAccountKey.Text);
                string openSSLPath = tbOpenSSLPath.Text;

                // Create batch file with contents
                string rawCommand = tbOpenSSLData.Text;
                string winCommand = rawCommand.Replace(@"PRIV_KEY=./account.key; echo -n ", @"echo|set /p=").Replace("openssl", "\"" + openSSLPath + "\"").Replace("$PRIV_KEY", "\""+accountKey+ "\"");

                var batFileFullPath = Path.Combine(tmpPath, "run.bat");
                CreateFileWithContents(batFileFullPath, winCommand);

                string rawResults = RunExternalExe(batFileFullPath);

                // If the command is first
                var idx = rawResults.IndexOf(accountKey);
                if (idx != -1)
                {
                    rawResults = rawResults.Substring(idx + accountKey.Length+1).Trim();
                }

                string winResults = "(stdin)= " + rawResults.Replace(Environment.NewLine, "");

                tbOpenSSLResults.Text = winResults;
                Clipboard.SetText(winResults);

                // Clear out the other boxes so nothing gets confused
                tbFileContents.Text = string.Empty;
                tbFileServerPath.Text = string.Empty;

                picOpenSSLExecStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblOpenSSLExecStatus.Text = "Success";
            }
            catch (Exception ex)
            {
                picOpenSSLExecStatus.Image = ResourceStream.GetImage(ResourceStream.Error);
                lblOpenSSLExecStatus.Text = "Error "+ex.Message;
            }
        }

        private void tbOpenSSLData_Click(object sender, EventArgs e)
        {
            tbOpenSSLData.SelectAll();
        }

        private void tbOpenSSLResults_Click(object sender, EventArgs e)
        {
            tbOpenSSLResults.SelectAll();
        }

        private void btnCreateVerificationFile_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpPath = Path.Combine(tbPath.Text, "files");
            
                // Create a clean dir
                if (Directory.Exists(tmpPath))
                    Directory.Delete(tmpPath, true);

                Directory.CreateDirectory(tmpPath);

                string rawUrl = tbFileServerPath.Text;
                Uri url = new Uri(rawUrl, UriKind.Absolute);

                string fullFilePath = Path.Combine(tmpPath, url.AbsolutePath.TrimStart('/').Replace('/','\\'));
                Directory.CreateDirectory(Path.GetDirectoryName(fullFilePath));

                CreateFileWithContents(fullFilePath, tbFileContents.Text);

                Process.Start(tmpPath);

                picVerificationFileStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblVerificationFileStatus.Text = "Success";
            }
            catch (Exception ex)
            {
                picVerificationFileStatus.Image = ResourceStream.GetImage(ResourceStream.Error);
                lblVerificationFileStatus.Text = "Error "+ex.Message;
            }
        }

        private void tbFileServerPath_Click(object sender, EventArgs e)
        {
            tbFileServerPath.SelectAll();
        }

        private void tbFileContents_Click(object sender, EventArgs e)
        {
            tbFileContents.SelectAll();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateCertificateFiles_Click(object sender, EventArgs e)
        {
            var rootDir = tbPath.Text;
            string prefix = Path.GetFileName(rootDir);
            string certFile = Path.Combine(rootDir, prefix + "_cert.crt");
            string chainFile = Path.Combine(rootDir, prefix + "_chain.crt");

            CreateFileWithContents(certFile, tbCertSigned.Text.Trim());
            CreateFileWithContents(chainFile, tbCertIntermediate.Text.Trim()+Environment.NewLine+tbCertRoot.Text.Trim());

            Process.Start(rootDir);

            ValidateTabPage3();
        }

        private void tbCertSigned_Click(object sender, EventArgs e)
        {
            tbCertSigned.SelectAll();
        }

        private void tbCertIntermediate_Click(object sender, EventArgs e)
        {
            tbCertIntermediate.SelectAll();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateAccountKey_Click(object sender, EventArgs e)
        {
            string tmpPath = Path.Combine(tbPath.Text, "tmp");

            // Create a clean dir
            if (!Directory.Exists(tmpPath))
                Directory.CreateDirectory(tmpPath);

            string accountKey = Path.Combine(tbPath.Text, tbAccountKey.Text);
            string openSSLPath = tbOpenSSLPath.Text;


            var batFileFullPath = Path.Combine(tmpPath, "run.bat");
            // Create batch file with contents
            string winCommand = "\""+ openSSLPath + "\" genrsa 4096 > \"" + accountKey+"\"";
            CreateFileWithContents(batFileFullPath, winCommand);
            RunExternalExe(batFileFullPath);

            winCommand = "\"" + openSSLPath + "\" rsa -in \"" + accountKey + "\" -pubout";
            CreateFileWithContents(batFileFullPath, winCommand);
            string rawKeyData = RunExternalExe(batFileFullPath);

            // If the command is first
            var idx = rawKeyData.IndexOf(winCommand);
            if (idx != -1)
            {
                rawKeyData = rawKeyData.Substring(idx + winCommand.Length + 1).Trim();
            }

            tbAccountKeyContents.Text = rawKeyData;
            Clipboard.SetText(rawKeyData);

            ValidateTabPage1AccountKey();
        }

        private void tbAccountKeyContents_Click(object sender, EventArgs e)
        {
            tbAccountKeyContents.SelectAll();
        }

        private void tbCertSigningRequestContents_Click(object sender, EventArgs e)
        {
            tbCertSigningRequestContents.SelectAll();
        }

        private void btnCreateDomainKey_Click(object sender, EventArgs e)
        {
            string tmpPath = Path.Combine(tbPath.Text, "tmp");

            // Create a clean dir
            if (!Directory.Exists(tmpPath))
                Directory.CreateDirectory(tmpPath);

            string domainKey = Path.Combine(tbPath.Text, tbDomainKey.Text);
            string certSignFile = Path.Combine(tbPath.Text, tbOpenSSLCertCreationFile.Text);
            string openSSLPath = tbOpenSSLPath.Text;


            var batFileFullPath = Path.Combine(tmpPath, "run.bat");
            // Create batch file with contents
            string winCommand = "\"" + openSSLPath + "\" genrsa 4096 > \"" + domainKey + "\"";
            CreateFileWithContents(batFileFullPath, winCommand);
            RunExternalExe(batFileFullPath);

            winCommand = "\"" + openSSLPath + "\" req -new -sha256 -key \"" + domainKey + "\" -subj \"/\" -reqexts SAN -config \""+ certSignFile+"\"";
            CreateFileWithContents(batFileFullPath, winCommand);
            string rawKeyData = RunExternalExe(batFileFullPath);

            // If the command is first
            var idx = rawKeyData.IndexOf(winCommand);
            if (idx != -1)
            {
                rawKeyData = rawKeyData.Substring(idx + winCommand.Length + 1).Trim();
            }

            tbCertSigningRequestContents.Text = rawKeyData;
            Clipboard.SetText(rawKeyData);

            ValidateTabPage1DomainKey();
        }

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
            btnShowHelp.Text = (splitContainer1.Panel1Collapsed ? "Show" : "Hide" ) + " Help";
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkWebsite.Text);
        }

        private void lnkGetOpenSSL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wiki.openssl.org/index.php/Binaries");
        }

        private void lnkGetOpenSSLcnfTemplateFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://web.mit.edu/crypto/openssl.cnf");
        }

        #region Validation for Tab values and settings

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabSetup)
                ValidateSetupTab();
            else if (tabControl1.SelectedTab == tabPage1)
                ValidateTabPage1();
            else if (tabControl1.SelectedTab == tabPage2)
                ValidateTabPage2();
            else if (tabControl1.SelectedTab == tabPage3)
                ValidateTabPage3();
        }

        private void ValidateTabPage2()
        {
            // Initialize the tab page
            picOpenSSLExecStatus.Image = null;
            lblOpenSSLExecStatus.Text = null;
            picVerificationFileStatus.Image = null;
            lblVerificationFileStatus.Text = null;
        }

        private void ValidateSetupTab()
        {
            picOKOpenSSL.Image = File.Exists(tbOpenSSLPath.Text) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
            picOKWorkingPath.Image = Directory.Exists(tbPath.Text) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
            picOKCertificateCreationFile.Image = File.Exists(Path.Combine(tbPath.Text, tbOpenSSLCertCreationFile.Text)) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);

            picOKAccountKey.Image = !string.IsNullOrWhiteSpace(tbAccountKey.Text) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
            picOKDomainKey.Image = !string.IsNullOrWhiteSpace(tbDomainKey.Text) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
        }

        private void ValidateTabPage1()
        {
            ValidateTabPage1AccountKey();
            ValidateTabPage1DomainKey();
        }

        private void ValidateTabPage1AccountKey()
        {
            string accountKeyPath = Path.Combine(tbPath.Text, tbAccountKey.Text);
            picAccountKeyStatus.Image = null;
            lblAccountKeyStatus.Text = null;
            if (File.Exists(accountKeyPath))
            {
                picAccountKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblAccountKeyStatus.Text = $"Account key '{accountKeyPath}' already exists";
            }
            else
            {
                picAccountKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Warning);
                lblAccountKeyStatus.Text = $"No Account key has been created yet";
            }
        }

        private void ValidateTabPage1DomainKey()
        {
            string domainKeyPath = Path.Combine(tbPath.Text, tbDomainKey.Text);
            picDomainKeyStatus.Image = null;
            lblDomainKeyStatus.Text = null;
            if (File.Exists(domainKeyPath))
            {
                picDomainKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblDomainKeyStatus.Text = $"Domain key '{domainKeyPath}' already exists";
            }
            else
            {
                picDomainKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Warning);
                lblDomainKeyStatus.Text = $"No Domain key has been created yet";
            }
        }

        private void ValidateTabPage3()
        {
            var rootDir = tbPath.Text;
            string prefix = Path.GetFileName(rootDir);
            string certFile = Path.Combine(rootDir, prefix + "_cert.crt");
            string chainFile = Path.Combine(rootDir, prefix + "_chain.crt");


            picAccountKeyStatus.Image = null;
            lblAccountKeyStatus.Text = null;
            if (File.Exists(certFile) && File.Exists(chainFile))
            {
                picCertificateFileStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblCertificateFileStatus.Text = $"Chain and Cert files both exist at '{rootDir}'";
            }
            else
            {
                picAccountKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Warning);
                if (!File.Exists(certFile))
                    lblAccountKeyStatus.Text = $"Cert file '{certFile}' could not be found. Re-create files.";
                else
                    lblAccountKeyStatus.Text = $"Chain file '{chainFile}' could not be found. Re-create files.";
            }
        }

        

        private void tbOpenSSLData_TextChanged(object sender, EventArgs e)
        {
            picOpenSSLExecStatus.Image = null;
            lblOpenSSLExecStatus.Text = null;
        }

        private void tbFileServerPath_TextChanged(object sender, EventArgs e)
        {
            picVerificationFileStatus.Image = null;
            lblVerificationFileStatus.Text = null;
        }
        
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            ValidateSetupTab();
        }
    }
}
