namespace GetHttpsForFreeUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbOpenSSLData = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOpenSSLResults = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenSSLExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFileServerPath = new System.Windows.Forms.TextBox();
            this.tbFileContents = new System.Windows.Forms.TextBox();
            this.btnCreateVerificationFile = new System.Windows.Forms.Button();
            this.tbOpenSSLPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCertSigned = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateCertificateFiles = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCertIntermediate = new System.Windows.Forms.TextBox();
            this.tbCertRoot = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbAccountKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDomainKey = new System.Windows.Forms.TextBox();
            this.picOKOpenSSL = new System.Windows.Forms.PictureBox();
            this.picOKWorkingPath = new System.Windows.Forms.PictureBox();
            this.picOKAccountKey = new System.Windows.Forms.PictureBox();
            this.picOKDomainKey = new System.Windows.Forms.PictureBox();
            this.btnCreateAccountKey = new System.Windows.Forms.Button();
            this.tbAccountKeyContents = new System.Windows.Forms.TextBox();
            this.tbCertSigningRequestContents = new System.Windows.Forms.TextBox();
            this.btnCreateDomainKey = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbOpenSSLCertCreationFile = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOKOpenSSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKWorkingPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKAccountKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKDomainKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOpenSSLData
            // 
            this.tbOpenSSLData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpenSSLData.Location = new System.Drawing.Point(6, 41);
            this.tbOpenSSLData.Multiline = true;
            this.tbOpenSSLData.Name = "tbOpenSSLData";
            this.tbOpenSSLData.Size = new System.Drawing.Size(1154, 83);
            this.tbOpenSSLData.TabIndex = 0;
            this.tbOpenSSLData.Click += new System.EventHandler(this.tbOpenSSLData_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(34, 66);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(1138, 20);
            this.tbPath.TabIndex = 1;
            this.tbPath.Text = "D:\\dev\\devtools\\openssl\\sverrirs_ssl";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(6, 50);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(210, 13);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Working Path (place where files are stored)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data";
            // 
            // tbOpenSSLResults
            // 
            this.tbOpenSSLResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpenSSLResults.Location = new System.Drawing.Point(6, 143);
            this.tbOpenSSLResults.Multiline = true;
            this.tbOpenSSLResults.Name = "tbOpenSSLResults";
            this.tbOpenSSLResults.Size = new System.Drawing.Size(1154, 116);
            this.tbOpenSSLResults.TabIndex = 0;
            this.tbOpenSSLResults.Click += new System.EventHandler(this.tbOpenSSLResults_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Results";
            // 
            // btnOpenSSLExecute
            // 
            this.btnOpenSSLExecute.Location = new System.Drawing.Point(6, 265);
            this.btnOpenSSLExecute.Name = "btnOpenSSLExecute";
            this.btnOpenSSLExecute.Size = new System.Drawing.Size(136, 23);
            this.btnOpenSSLExecute.TabIndex = 4;
            this.btnOpenSSLExecute.Text = "Execute OpenSSL";
            this.btnOpenSSLExecute.UseVisualStyleBackColor = true;
            this.btnOpenSSLExecute.Click += new System.EventHandler(this.btnOpenSSLExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenSSLExecute);
            this.groupBox1.Controls.Add(this.tbOpenSSLData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbOpenSSLResults);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1166, 297);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Execute OpenSSL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreateVerificationFile);
            this.groupBox2.Controls.Add(this.tbFileContents);
            this.groupBox2.Controls.Add(this.tbFileServerPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1166, 142);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Verification Files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "File Server Path";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(-138, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Step 3";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "File Contents";
            // 
            // tbFileServerPath
            // 
            this.tbFileServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileServerPath.Location = new System.Drawing.Point(5, 41);
            this.tbFileServerPath.Name = "tbFileServerPath";
            this.tbFileServerPath.Size = new System.Drawing.Size(1155, 20);
            this.tbFileServerPath.TabIndex = 5;
            this.tbFileServerPath.Click += new System.EventHandler(this.tbFileServerPath_Click);
            // 
            // tbFileContents
            // 
            this.tbFileContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileContents.Location = new System.Drawing.Point(9, 80);
            this.tbFileContents.Name = "tbFileContents";
            this.tbFileContents.Size = new System.Drawing.Size(1151, 20);
            this.tbFileContents.TabIndex = 5;
            this.tbFileContents.Click += new System.EventHandler(this.tbFileContents_Click);
            // 
            // btnCreateVerificationFile
            // 
            this.btnCreateVerificationFile.Location = new System.Drawing.Point(9, 106);
            this.btnCreateVerificationFile.Name = "btnCreateVerificationFile";
            this.btnCreateVerificationFile.Size = new System.Drawing.Size(133, 23);
            this.btnCreateVerificationFile.TabIndex = 6;
            this.btnCreateVerificationFile.Text = "Create Verification File";
            this.btnCreateVerificationFile.UseVisualStyleBackColor = true;
            this.btnCreateVerificationFile.Click += new System.EventHandler(this.btnCreateVerificationFile_Click);
            // 
            // tbOpenSSLPath
            // 
            this.tbOpenSSLPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpenSSLPath.Location = new System.Drawing.Point(34, 27);
            this.tbOpenSSLPath.Name = "tbOpenSSLPath";
            this.tbOpenSSLPath.Size = new System.Drawing.Size(1138, 20);
            this.tbOpenSSLPath.TabIndex = 1;
            this.tbOpenSSLPath.Text = "D:\\dev\\devtools\\openssl\\openssl.exe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "OpenSSL Path";
            // 
            // tbCertSigned
            // 
            this.tbCertSigned.Location = new System.Drawing.Point(9, 41);
            this.tbCertSigned.Multiline = true;
            this.tbCertSigned.Name = "tbCertSigned";
            this.tbCertSigned.Size = new System.Drawing.Size(388, 422);
            this.tbCertSigned.TabIndex = 7;
            this.tbCertSigned.WordWrap = false;
            this.tbCertSigned.Click += new System.EventHandler(this.tbCertSigned_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCreateCertificateFiles);
            this.groupBox3.Controls.Add(this.tbCertRoot);
            this.groupBox3.Controls.Add(this.tbCertIntermediate);
            this.groupBox3.Controls.Add(this.tbCertSigned);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1174, 516);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Certificate Files";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Signed Certificate";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnCreateCertificateFiles
            // 
            this.btnCreateCertificateFiles.Location = new System.Drawing.Point(13, 469);
            this.btnCreateCertificateFiles.Name = "btnCreateCertificateFiles";
            this.btnCreateCertificateFiles.Size = new System.Drawing.Size(171, 23);
            this.btnCreateCertificateFiles.TabIndex = 8;
            this.btnCreateCertificateFiles.Text = "Create Certificate Files";
            this.btnCreateCertificateFiles.UseVisualStyleBackColor = true;
            this.btnCreateCertificateFiles.Click += new System.EventHandler(this.btnCreateCertificateFiles_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Intermediate Certificate";
            this.label7.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbCertIntermediate
            // 
            this.tbCertIntermediate.Location = new System.Drawing.Point(406, 41);
            this.tbCertIntermediate.Multiline = true;
            this.tbCertIntermediate.Name = "tbCertIntermediate";
            this.tbCertIntermediate.Size = new System.Drawing.Size(378, 422);
            this.tbCertIntermediate.TabIndex = 7;
            this.tbCertIntermediate.WordWrap = false;
            this.tbCertIntermediate.Click += new System.EventHandler(this.tbCertIntermediate_Click);
            // 
            // tbCertRoot
            // 
            this.tbCertRoot.Location = new System.Drawing.Point(790, 41);
            this.tbCertRoot.Multiline = true;
            this.tbCertRoot.Name = "tbCertRoot";
            this.tbCertRoot.Size = new System.Drawing.Size(378, 422);
            this.tbCertRoot.TabIndex = 7;
            this.tbCertRoot.Text = resources.GetString("tbCertRoot.Text");
            this.tbCertRoot.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(787, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Root Certificate";
            this.label8.Click += new System.EventHandler(this.label6_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1188, 548);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1180, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step 1 and 2";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1180, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step 3 and 4";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1180, 522);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step 5";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.picOKDomainKey);
            this.tabPage4.Controls.Add(this.picOKAccountKey);
            this.tabPage4.Controls.Add(this.picOKWorkingPath);
            this.tabPage4.Controls.Add(this.picOKOpenSSL);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.tbOpenSSLCertCreationFile);
            this.tabPage4.Controls.Add(this.tbDomainKey);
            this.tabPage4.Controls.Add(this.tbAccountKey);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.tbPath);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.lblPath);
            this.tabPage4.Controls.Add(this.tbOpenSSLPath);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1180, 522);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Setup";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbAccountKeyContents);
            this.groupBox4.Controls.Add(this.btnCreateAccountKey);
            this.groupBox4.Location = new System.Drawing.Point(9, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(594, 512);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Create Account Info";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbCertSigningRequestContents);
            this.groupBox5.Controls.Add(this.btnCreateDomainKey);
            this.groupBox5.Location = new System.Drawing.Point(610, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(562, 509);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Create Certificate Signing Request";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Account key (usually \"account.key\")";
            // 
            // tbAccountKey
            // 
            this.tbAccountKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccountKey.Location = new System.Drawing.Point(34, 121);
            this.tbAccountKey.Name = "tbAccountKey";
            this.tbAccountKey.Size = new System.Drawing.Size(1138, 20);
            this.tbAccountKey.TabIndex = 1;
            this.tbAccountKey.Text = "account.key";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Domain key (usually \"domain.key\")";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // tbDomainKey
            // 
            this.tbDomainKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDomainKey.Location = new System.Drawing.Point(34, 160);
            this.tbDomainKey.Name = "tbDomainKey";
            this.tbDomainKey.Size = new System.Drawing.Size(1138, 20);
            this.tbDomainKey.TabIndex = 1;
            this.tbDomainKey.Text = "domain.key";
            // 
            // picOKOpenSSL
            // 
            this.picOKOpenSSL.Location = new System.Drawing.Point(12, 30);
            this.picOKOpenSSL.Name = "picOKOpenSSL";
            this.picOKOpenSSL.Size = new System.Drawing.Size(16, 16);
            this.picOKOpenSSL.TabIndex = 3;
            this.picOKOpenSSL.TabStop = false;
            // 
            // picOKWorkingPath
            // 
            this.picOKWorkingPath.Location = new System.Drawing.Point(12, 69);
            this.picOKWorkingPath.Name = "picOKWorkingPath";
            this.picOKWorkingPath.Size = new System.Drawing.Size(16, 16);
            this.picOKWorkingPath.TabIndex = 3;
            this.picOKWorkingPath.TabStop = false;
            // 
            // picOKAccountKey
            // 
            this.picOKAccountKey.Location = new System.Drawing.Point(12, 124);
            this.picOKAccountKey.Name = "picOKAccountKey";
            this.picOKAccountKey.Size = new System.Drawing.Size(16, 16);
            this.picOKAccountKey.TabIndex = 3;
            this.picOKAccountKey.TabStop = false;
            // 
            // picOKDomainKey
            // 
            this.picOKDomainKey.Location = new System.Drawing.Point(12, 161);
            this.picOKDomainKey.Name = "picOKDomainKey";
            this.picOKDomainKey.Size = new System.Drawing.Size(16, 16);
            this.picOKDomainKey.TabIndex = 3;
            this.picOKDomainKey.TabStop = false;
            // 
            // btnCreateAccountKey
            // 
            this.btnCreateAccountKey.Location = new System.Drawing.Point(7, 20);
            this.btnCreateAccountKey.Name = "btnCreateAccountKey";
            this.btnCreateAccountKey.Size = new System.Drawing.Size(135, 23);
            this.btnCreateAccountKey.TabIndex = 0;
            this.btnCreateAccountKey.Text = "Create Account Key";
            this.btnCreateAccountKey.UseVisualStyleBackColor = true;
            this.btnCreateAccountKey.Click += new System.EventHandler(this.btnCreateAccountKey_Click);
            // 
            // tbAccountKeyContents
            // 
            this.tbAccountKeyContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccountKeyContents.Location = new System.Drawing.Point(7, 50);
            this.tbAccountKeyContents.Multiline = true;
            this.tbAccountKeyContents.Name = "tbAccountKeyContents";
            this.tbAccountKeyContents.Size = new System.Drawing.Size(581, 456);
            this.tbAccountKeyContents.TabIndex = 1;
            this.tbAccountKeyContents.Click += new System.EventHandler(this.tbAccountKeyContents_Click);
            // 
            // tbCertSigningRequestContents
            // 
            this.tbCertSigningRequestContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCertSigningRequestContents.Location = new System.Drawing.Point(6, 50);
            this.tbCertSigningRequestContents.Multiline = true;
            this.tbCertSigningRequestContents.Name = "tbCertSigningRequestContents";
            this.tbCertSigningRequestContents.Size = new System.Drawing.Size(550, 453);
            this.tbCertSigningRequestContents.TabIndex = 1;
            this.tbCertSigningRequestContents.Click += new System.EventHandler(this.tbCertSigningRequestContents_Click);
            // 
            // btnCreateDomainKey
            // 
            this.btnCreateDomainKey.Location = new System.Drawing.Point(6, 21);
            this.btnCreateDomainKey.Name = "btnCreateDomainKey";
            this.btnCreateDomainKey.Size = new System.Drawing.Size(135, 23);
            this.btnCreateDomainKey.TabIndex = 0;
            this.btnCreateDomainKey.Text = "Create Domain Key";
            this.btnCreateDomainKey.UseVisualStyleBackColor = true;
            this.btnCreateDomainKey.Click += new System.EventHandler(this.btnCreateDomainKey_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(272, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "OpenSSL Certificate Creation File (usually \"openssl.cnf\")";
            this.label11.Click += new System.EventHandler(this.label10_Click);
            // 
            // tbOpenSSLCertCreationFile
            // 
            this.tbOpenSSLCertCreationFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpenSSLCertCreationFile.Location = new System.Drawing.Point(37, 199);
            this.tbOpenSSLCertCreationFile.Name = "tbOpenSSLCertCreationFile";
            this.tbOpenSSLCertCreationFile.Size = new System.Drawing.Size(1138, 20);
            this.tbOpenSSLCertCreationFile.TabIndex = 1;
            this.tbOpenSSLCertCreationFile.Text = "openssl.cnf";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 548);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Get Https For free - Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOKOpenSSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKWorkingPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKAccountKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKDomainKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbOpenSSLData;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOpenSSLResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenSSLExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateVerificationFile;
        private System.Windows.Forms.TextBox tbFileContents;
        private System.Windows.Forms.TextBox tbFileServerPath;
        private System.Windows.Forms.TextBox tbOpenSSLPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCertSigned;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreateCertificateFiles;
        private System.Windows.Forms.TextBox tbCertIntermediate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCertRoot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbDomainKey;
        private System.Windows.Forms.TextBox tbAccountKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picOKDomainKey;
        private System.Windows.Forms.PictureBox picOKAccountKey;
        private System.Windows.Forms.PictureBox picOKWorkingPath;
        private System.Windows.Forms.PictureBox picOKOpenSSL;
        private System.Windows.Forms.TextBox tbCertSigningRequestContents;
        private System.Windows.Forms.TextBox tbAccountKeyContents;
        private System.Windows.Forms.Button btnCreateAccountKey;
        private System.Windows.Forms.Button btnCreateDomainKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbOpenSSLCertCreationFile;
        private System.Windows.Forms.Label label11;
    }
}

