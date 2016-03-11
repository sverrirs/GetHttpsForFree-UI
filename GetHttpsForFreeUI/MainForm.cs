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
        }
    }
}
