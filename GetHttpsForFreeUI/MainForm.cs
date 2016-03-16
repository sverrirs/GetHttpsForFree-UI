using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetHttpsForFreeUI.Properties;

namespace GetHttpsForFreeUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set the title to include the version number
            var version = typeof (MainForm).Assembly.GetName().Version;
            if (version != null)
                this.Text += $" | v{version}";

            ValidateSetupTab();
        }

        public static void CreateFileWithContents(string filePath, string contents)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            // Create the directory
            var directoryPath = Path.GetDirectoryName(filePath);
            if( !string.IsNullOrWhiteSpace(directoryPath))
                Directory.CreateDirectory(directoryPath);

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

                ShowBalloonTip("Signature created and copied to clipboard",
                                btnOpenSSLExecute,
                                1000);
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
            
                // Create a clean dir, if not able to delete then simply continue
                try
                {
                    if (Directory.Exists(tmpPath))
                        Directory.Delete(tmpPath, true);
                }
                catch
                {
                    MessageBox.Show(this, "Could not prepare 'files' directory. \nMake sure you close all windows previously opened by \nthis operation then try again.\nPath: " + tmpPath);
                    return;
                }

                Directory.CreateDirectory(tmpPath);

                string rawUrl = tbFileServerPath.Text;
                Uri url = new Uri(rawUrl, UriKind.Absolute);

                string fullFilePath = Path.Combine(tmpPath, url.AbsolutePath.TrimStart('/').Replace('/','\\'));
                Directory.CreateDirectory(Path.GetDirectoryName(fullFilePath));

                CreateFileWithContents(fullFilePath, tbFileContents.Text);

                Process.Start(tmpPath);

                picVerificationFileStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblVerificationFileStatus.Text = "Success";

                ShowBalloonTip("Verification file created",
                                btnCreateVerificationFile,
                                1000);
            }
            catch (Exception ex)
            {
                picVerificationFileStatus.Image = ResourceStream.GetImage(ResourceStream.Error);
                lblVerificationFileStatus.Text = ex.Message;
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

        private void btnCreateCertificateFiles_Click(object sender, EventArgs e)
        {
            try
            {
                var rootDir = tbPath.Text;
                string prefix = Path.GetFileName(rootDir);
                string certFile = Path.Combine(rootDir, prefix + "_cert.crt");
                string chainFile = Path.Combine(rootDir, prefix + "_chain.crt");

                CreateFileWithContents(certFile, tbCertSigned.Text.Trim());
                CreateFileWithContents(chainFile, tbCertIntermediate.Text.Trim() + Environment.NewLine + tbCertRoot.Text.Trim());

                Process.Start(rootDir);

                ValidateTabPage3();

                ShowBalloonTip("Certification files created. Congratulations!",
                    btnCreateCertificateFiles,
                    1000);
            }
            catch (Exception ex)
            {
                picCertificateFileStatus.Image = ResourceStream.GetImage(ResourceStream.Error);
                lblCertificateFileStatus.Text = ex.Message;
            }
        }

        private void tbCertSigned_Click(object sender, EventArgs e)
        {
            tbCertSigned.SelectAll();
        }

        private void tbCertIntermediate_Click(object sender, EventArgs e)
        {
            tbCertIntermediate.SelectAll();
        }
        
        private void btnCreateAccountKey_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpPath = Path.Combine(tbPath.Text, "tmp");

                // Create a clean dir
                if (!Directory.Exists(tmpPath))
                    Directory.CreateDirectory(tmpPath);

                string accountKey = Path.Combine(tbPath.Text, tbAccountKey.Text);
                string openSSLPath = tbOpenSSLPath.Text;


                var batFileFullPath = Path.Combine(tmpPath, "run.bat");
                // Create batch file with contents
                string winCommand = "\"" + openSSLPath + "\" genrsa 4096 > \"" + accountKey + "\"";
                CreateFileWithContents(batFileFullPath, winCommand);
                RunExternalExe(batFileFullPath);

                string rawKeyData = GetKeyFileContents(accountKey);

                tbAccountKeyContents.Text = rawKeyData;
                Clipboard.SetText(rawKeyData);

                ValidateTabPage1AccountKey();

                ShowBalloonTip("Account key created and copied to clipboard",
                    btnCreateAccountKey,
                    1000);
            }
            catch (Exception ex)
            {
                picAccountKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Error);
                lblAccountKeyStatus.Text = ex.Message;
            }
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
            try
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

                string rawCertData = GetCertificateSigningRequest(domainKey, certSignFile);
                tbCertSigningRequestContents.Text = rawCertData;
                Clipboard.SetText(rawCertData);

                ValidateTabPage1DomainKey();

                ShowBalloonTip("Domain key created and copied to clipboard",
                    btnCreateDomainKey,
                    1000);
            }
            catch (Exception ex)
            {
                picDomainKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Error);
                lblDomainKeyStatus.Text = ex.Message;
            }
        }

        private string GetCertificateSigningRequest(string keyFilePath, string certSignFilePath)
        {
            string openSSLPath = tbOpenSSLPath.Text;
            string tmpPath = Path.Combine(tbPath.Text, "tmp");
            var batFileFullPath = Path.Combine(tmpPath, "run.bat");

            string winCommand = "\"" + openSSLPath + "\" req -new -sha256 -key \"" + keyFilePath + "\" -subj \"/\" -reqexts SAN -config \"" + certSignFilePath + "\"";
            CreateFileWithContents(batFileFullPath, winCommand);
            string rawOutputData = RunExternalExe(batFileFullPath);

            // If the command is first
            var idx = rawOutputData.IndexOf(winCommand);
            if (idx != -1)
            {
                rawOutputData = rawOutputData.Substring(idx + winCommand.Length + 1).Trim();
            }

            return rawOutputData;
        }

        private string GetKeyFileContents( string keyFileName )
        {
            string openSSLPath = tbOpenSSLPath.Text;
            string tmpPath = Path.Combine(tbPath.Text, "tmp");
            var batFileFullPath = Path.Combine(tmpPath, "run.bat");

            string winCommand = "\"" + openSSLPath + "\" rsa -in \"" + keyFileName + "\" -pubout";
            CreateFileWithContents(batFileFullPath, winCommand);
            string rawKeyData = RunExternalExe(batFileFullPath);

            // If the command is first
            var idx = rawKeyData.IndexOf(winCommand);
            if (idx != -1)
            {
                rawKeyData = rawKeyData.Substring(idx + winCommand.Length + 1).Trim();
            }
            return rawKeyData;
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
            // Load values from settings if nothing is set
            if (string.IsNullOrWhiteSpace(tbOpenSSLPath.Text))
                tbOpenSSLPath.Text = Settings.Default.OpenSSLPath;
            if (string.IsNullOrWhiteSpace(tbPath.Text))
                tbPath.Text = Settings.Default.LastWorkingPath;
            
            var openSSLPathExists = File.Exists(tbOpenSSLPath.Text);
            var workingPathExists = Directory.Exists(tbPath.Text);

            picOKOpenSSL.Image = openSSLPathExists ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
            picOKWorkingPath.Image = workingPathExists ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
            picOKCertificateCreationFile.Image = File.Exists(Path.Combine(tbPath.Text, tbOpenSSLCertCreationFile.Text)) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);

            picOKAccountKey.Image = !string.IsNullOrWhiteSpace(tbAccountKey.Text) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);
            picOKDomainKey.Image = !string.IsNullOrWhiteSpace(tbDomainKey.Text) ? ResourceStream.GetImage(ResourceStream.Ok) : ResourceStream.GetImage(ResourceStream.Error);

            // Save settings for next use
            if (openSSLPathExists)
                Settings.Default.OpenSSLPath = tbOpenSSLPath.Text;
            if (workingPathExists)
                Settings.Default.LastWorkingPath = tbPath.Text;

            if(openSSLPathExists || workingPathExists)
                Settings.Default.Save();
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
                lblAccountKeyStatus.Text = $"Account key '{accountKeyPath}' available";
                btnCreateAccountKey.Enabled = false;

                // Print the key in the box
                if(string.IsNullOrWhiteSpace(tbAccountKeyContents.Text))
                    tbAccountKeyContents.Text = GetKeyFileContents(accountKeyPath);
            }
            else
            {
                picAccountKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Warning);
                lblAccountKeyStatus.Text = $"No Account key has been created yet";
                btnCreateAccountKey.Enabled = true;
                tbAccountKeyContents.Text = string.Empty;
            }
        }

        private void ValidateTabPage1DomainKey()
        {
            string certSignFile = Path.Combine(tbPath.Text, tbOpenSSLCertCreationFile.Text);
            string domainKeyPath = Path.Combine(tbPath.Text, tbDomainKey.Text);

            picDomainKeyStatus.Image = null;
            lblDomainKeyStatus.Text = null;
            if (File.Exists(domainKeyPath) && File.Exists(certSignFile))
            {
                picDomainKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblDomainKeyStatus.Text = $"Domain key '{domainKeyPath}' available";
                btnCreateDomainKey.Enabled = false;

                // Print the key in the box                
                if (string.IsNullOrWhiteSpace(tbCertSigningRequestContents.Text))
                    tbCertSigningRequestContents.Text = GetCertificateSigningRequest(domainKeyPath, certSignFile);
            }
            else
            {
                tbCertSigningRequestContents.Text = string.Empty;
                picDomainKeyStatus.Image = ResourceStream.GetImage(ResourceStream.Warning);
                if (!File.Exists(certSignFile))
                {
                    lblDomainKeyStatus.Text = $"No OpenSSL certificate creation file available (openssl.cnf)";
                    btnCreateDomainKey.Enabled = false;
                }
                else if (!File.Exists(domainKeyPath))
                {
                    lblDomainKeyStatus.Text = $"No Domain key has been created yet";
                    btnCreateDomainKey.Enabled = true;
                }
            }
        }

        private void ValidateTabPage3()
        {
            var rootDir = tbPath.Text;
            string prefix = Path.GetFileName(rootDir);
            string certFile = Path.Combine(rootDir, prefix + "_cert.crt");
            string chainFile = Path.Combine(rootDir, prefix + "_chain.crt");


            picCertificateFileStatus.Image = null;
            lblCertificateFileStatus.Text = null;
            if (File.Exists(certFile) && File.Exists(chainFile))
            {
                picCertificateFileStatus.Image = ResourceStream.GetImage(ResourceStream.Ok);
                lblCertificateFileStatus.Text = $"Chain and Cert files both available at '{rootDir}'";
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

        #endregion

        private void tbOpenSSLData_TextChanged(object sender, EventArgs e)
        {
            picOpenSSLExecStatus.Image = null;
            lblOpenSSLExecStatus.Text = null;
            tbOpenSSLResults.Text = string.Empty;
        }

        private void tbFileServerPath_TextChanged(object sender, EventArgs e)
        {
            picVerificationFileStatus.Image = null;
            lblVerificationFileStatus.Text = null;
        }
        
        private void cbUnlockAccountKey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnlockAccountKey.Checked)
                btnCreateAccountKey.Enabled = true;
            else
                ValidateTabPage1AccountKey();
        }

        private void cbUnlockDomainKey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnlockAccountKey.Checked)
                btnCreateDomainKey.Enabled = true;
            else
                ValidateTabPage1DomainKey();
        }

        private void ShowBrowsePathDialog(TextBox pathResultBox)
        {
            using (var dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                Multiselect = false,
                ValidateNames = false,
                FileName = "Select Folder",
                InitialDirectory = pathResultBox.Text ?? string.Empty
            })
            {
                var result = dialog.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                string firstDir = Path.GetDirectoryName(dialog.FileNames?.FirstOrDefault() ?? string.Empty);
                if (Directory.Exists(firstDir))
                    pathResultBox.Text = firstDir;
            }
        }

        private void ShowBrowseFileDialog(TextBox fileResultBox, string fileNameToFind)
        {
            using (var dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                Multiselect = false,
                ValidateNames = false,
                FileName = fileNameToFind
            })
            {
                // Load an initial path if possible
                var initialPath = fileResultBox.Text ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(initialPath))
                    dialog.InitialDirectory = Path.GetDirectoryName(initialPath);

                var result = dialog.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                string firstFile = dialog.FileNames?.FirstOrDefault() ?? string.Empty;
                if (string.Equals(Path.GetFileName(firstFile), fileNameToFind, StringComparison.OrdinalIgnoreCase))
                    fileResultBox.Text = firstFile;
            }
        }

        private void btnBrowsePathOpenSSL_Click(object sender, EventArgs e)
        {
            ShowBrowseFileDialog(tbOpenSSLPath, "openssl.exe");
            ValidateSetupTab();
        }

        private void btnBrowsePathWorkingPath_Click(object sender, EventArgs e)
        {
            ShowBrowsePathDialog(tbPath);
            ValidateSetupTab();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/sverrirs/GetHttpsForFree-UI");
        }

        private void lnkVerifyDomainVerificationFilesOnServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var urlText = tbFileServerPath.Text;
            if (string.IsNullOrWhiteSpace(urlText))
                return;

            Process.Start(urlText);
        }

        private void tbOpenSSLPath_Leave(object sender, EventArgs e)
        {
            ValidateSetupTab();
        }

        private void tbPath_Leave(object sender, EventArgs e)
        {
            ValidateSetupTab();
        }

        private void tbOpenSSLCertCreationFile_Leave(object sender, EventArgs e)
        {
            ValidateSetupTab();
        }

        private void lnkCopyRequiredSSLCertDataToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(@"####################################################################
# Replace example.com with your own domain.
# Ensure you add all subdomains you indend to secure with this same certificate. 
[SAN]
subjectAltName=DNS:example.com,DNS:www.example.com,DNS:subdomain.example.com");

            ShowBalloonTip("Text copied to clipboard",
                lnkCopyRequiredSSLCertDataToClipboard,
                1000);
        }

        private void lnkOpenCertfileForEditing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = Path.Combine(tbPath.Text, tbOpenSSLCertCreationFile.Text);
            if (!File.Exists(path))
            {
                ShowBalloonTip("File does not exist",
                                lnkOpenCertfileForEditing,
                                1000);
                return;
            }

            Process.Start(path);
        }

        private void ShowBalloonTip(string text, Control control, int durationMsec)
        {
            // Get around tooltip error by showing once empty for the control
            confirmToolTip.Show(string.Empty, control, 0);

            // Now for the real tooltip
            confirmToolTip.Show(text,
                                control,
                                new Point(1, control.Height+2),
                                durationMsec);
        }
    }
}
