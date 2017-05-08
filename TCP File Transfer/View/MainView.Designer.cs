using System.Windows.Forms;

namespace File_Transfer.View
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.MainTabPage = new System.Windows.Forms.TabControl();
            this.TabPageSender = new System.Windows.Forms.TabPage();
            this.statusStripSender = new System.Windows.Forms.StatusStrip();
            this.labelSendingProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarSendFile = new System.Windows.Forms.ToolStripProgressBar();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.txtSendPort = new System.Windows.Forms.TextBox();
            this.txtSendIp = new System.Windows.Forms.TextBox();
            this.labelSenderPort = new System.Windows.Forms.Label();
            this.labelSenderIPAdress = new System.Windows.Forms.Label();
            this.labelFileLocation = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.TabPageReceiver = new System.Windows.Forms.TabPage();
            this.statusStripReceiver = new System.Windows.Forms.StatusStrip();
            this.labelReceivedProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarReceiveFile = new System.Windows.Forms.ToolStripProgressBar();
            this.btnReceiveFile = new System.Windows.Forms.Button();
            this.txtReceivePort = new System.Windows.Forms.TextBox();
            this.txtReceiveIpAdress = new System.Windows.Forms.TextBox();
            this.labelReceiverPort = new System.Windows.Forms.Label();
            this.labelReceiverIPAdress = new System.Windows.Forms.Label();
            this.labelSaveLocation = new System.Windows.Forms.Label();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.btnSelectSaveLocation = new System.Windows.Forms.Button();
            this.TabPageAbout = new System.Windows.Forms.TabPage();
            this.GroupBoxAboutDeveloper = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDeveloperGithubProfile = new System.Windows.Forms.LinkLabel();
            this.labelDeveloperWebSite = new System.Windows.Forms.LinkLabel();
            this.labelDeveloperName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBoxAboutApp = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAppGithubRepository = new System.Windows.Forms.LinkLabel();
            this.labelAllRightReserved = new System.Windows.Forms.Label();
            this.labelAppNameAndVersion = new System.Windows.Forms.Label();
            this.pictureBoxAppIcon = new System.Windows.Forms.PictureBox();
            this.MainTabPage.SuspendLayout();
            this.TabPageSender.SuspendLayout();
            this.statusStripSender.SuspendLayout();
            this.TabPageReceiver.SuspendLayout();
            this.statusStripReceiver.SuspendLayout();
            this.TabPageAbout.SuspendLayout();
            this.GroupBoxAboutDeveloper.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBoxAboutApp.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.TabPageSender);
            this.MainTabPage.Controls.Add(this.TabPageReceiver);
            this.MainTabPage.Controls.Add(this.TabPageAbout);
            this.MainTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabPage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MainTabPage.Location = new System.Drawing.Point(0, 0);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.SelectedIndex = 0;
            this.MainTabPage.Size = new System.Drawing.Size(367, 264);
            this.MainTabPage.TabIndex = 2;
            // 
            // TabPageSender
            // 
            this.TabPageSender.Controls.Add(this.statusStripSender);
            this.TabPageSender.Controls.Add(this.btnSendFile);
            this.TabPageSender.Controls.Add(this.txtSendPort);
            this.TabPageSender.Controls.Add(this.txtSendIp);
            this.TabPageSender.Controls.Add(this.labelSenderPort);
            this.TabPageSender.Controls.Add(this.labelSenderIPAdress);
            this.TabPageSender.Controls.Add(this.labelFileLocation);
            this.TabPageSender.Controls.Add(this.txtFileLocation);
            this.TabPageSender.Controls.Add(this.btnSelectFile);
            this.TabPageSender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TabPageSender.Location = new System.Drawing.Point(4, 26);
            this.TabPageSender.Name = "TabPageSender";
            this.TabPageSender.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSender.Size = new System.Drawing.Size(359, 234);
            this.TabPageSender.TabIndex = 0;
            this.TabPageSender.Text = "Send File";
            this.TabPageSender.UseVisualStyleBackColor = true;
            // 
            // statusStripSender
            // 
            this.statusStripSender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statusStripSender.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelSendingProgress,
            this.progressBarSendFile});
            this.statusStripSender.Location = new System.Drawing.Point(3, 209);
            this.statusStripSender.Name = "statusStripSender";
            this.statusStripSender.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripSender.Size = new System.Drawing.Size(353, 22);
            this.statusStripSender.TabIndex = 21;
            this.statusStripSender.Text = "statusStripSender";
            // 
            // labelSendingProgress
            // 
            this.labelSendingProgress.Name = "labelSendingProgress";
            this.labelSendingProgress.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBarSendFile
            // 
            this.progressBarSendFile.Name = "progressBarSendFile";
            this.progressBarSendFile.Size = new System.Drawing.Size(100, 16);
            this.progressBarSendFile.Visible = false;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendFile.Location = new System.Drawing.Point(8, 150);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(343, 45);
            this.btnSendFile.TabIndex = 18;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.BtnSendFile_Click);
            // 
            // txtSendPort
            // 
            this.txtSendPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSendPort.Location = new System.Drawing.Point(235, 100);
            this.txtSendPort.Name = "txtSendPort";
            this.txtSendPort.Size = new System.Drawing.Size(116, 22);
            this.txtSendPort.TabIndex = 17;
            this.txtSendPort.Text = "27018";
            // 
            // txtSendIp
            // 
            this.txtSendIp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSendIp.Location = new System.Drawing.Point(8, 100);
            this.txtSendIp.Name = "txtSendIp";
            this.txtSendIp.Size = new System.Drawing.Size(220, 22);
            this.txtSendIp.TabIndex = 16;
            this.txtSendIp.Text = "127.0.0.1";
            // 
            // labelSenderPort
            // 
            this.labelSenderPort.AutoSize = true;
            this.labelSenderPort.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSenderPort.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSenderPort.Location = new System.Drawing.Point(232, 80);
            this.labelSenderPort.Name = "labelSenderPort";
            this.labelSenderPort.Size = new System.Drawing.Size(34, 17);
            this.labelSenderPort.TabIndex = 15;
            this.labelSenderPort.Text = "Port";
            // 
            // labelSenderIPAdress
            // 
            this.labelSenderIPAdress.AutoSize = true;
            this.labelSenderIPAdress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSenderIPAdress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSenderIPAdress.Location = new System.Drawing.Point(5, 80);
            this.labelSenderIPAdress.Name = "labelSenderIPAdress";
            this.labelSenderIPAdress.Size = new System.Drawing.Size(73, 17);
            this.labelSenderIPAdress.TabIndex = 14;
            this.labelSenderIPAdress.Text = "IP Address";
            // 
            // labelFileLocation
            // 
            this.labelFileLocation.AutoSize = true;
            this.labelFileLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFileLocation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelFileLocation.Location = new System.Drawing.Point(5, 12);
            this.labelFileLocation.Name = "labelFileLocation";
            this.labelFileLocation.Size = new System.Drawing.Size(28, 17);
            this.labelFileLocation.TabIndex = 12;
            this.labelFileLocation.Text = "File";
            this.labelFileLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFileLocation.Location = new System.Drawing.Point(8, 32);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.ReadOnly = true;
            this.txtFileLocation.Size = new System.Drawing.Size(220, 22);
            this.txtFileLocation.TabIndex = 11;
            this.txtFileLocation.Click += new System.EventHandler(this.txtFileLocation_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectFile.Location = new System.Drawing.Point(235, 27);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(116, 30);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "Select...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // TabPageReceiver
            // 
            this.TabPageReceiver.Controls.Add(this.statusStripReceiver);
            this.TabPageReceiver.Controls.Add(this.btnReceiveFile);
            this.TabPageReceiver.Controls.Add(this.txtReceivePort);
            this.TabPageReceiver.Controls.Add(this.txtReceiveIpAdress);
            this.TabPageReceiver.Controls.Add(this.labelReceiverPort);
            this.TabPageReceiver.Controls.Add(this.labelReceiverIPAdress);
            this.TabPageReceiver.Controls.Add(this.labelSaveLocation);
            this.TabPageReceiver.Controls.Add(this.txtSaveLocation);
            this.TabPageReceiver.Controls.Add(this.btnSelectSaveLocation);
            this.TabPageReceiver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TabPageReceiver.Location = new System.Drawing.Point(4, 26);
            this.TabPageReceiver.Name = "TabPageReceiver";
            this.TabPageReceiver.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageReceiver.Size = new System.Drawing.Size(359, 234);
            this.TabPageReceiver.TabIndex = 1;
            this.TabPageReceiver.Text = "Receive File";
            this.TabPageReceiver.UseVisualStyleBackColor = true;
            // 
            // statusStripReceiver
            // 
            this.statusStripReceiver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statusStripReceiver.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelReceivedProgress,
            this.progressBarReceiveFile});
            this.statusStripReceiver.Location = new System.Drawing.Point(3, 209);
            this.statusStripReceiver.Name = "statusStripReceiver";
            this.statusStripReceiver.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripReceiver.Size = new System.Drawing.Size(353, 22);
            this.statusStripReceiver.TabIndex = 29;
            this.statusStripReceiver.Text = "statusStripReceiver";
            // 
            // labelReceivedProgress
            // 
            this.labelReceivedProgress.Name = "labelReceivedProgress";
            this.labelReceivedProgress.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBarReceiveFile
            // 
            this.progressBarReceiveFile.Name = "progressBarReceiveFile";
            this.progressBarReceiveFile.Size = new System.Drawing.Size(100, 16);
            this.progressBarReceiveFile.Visible = false;
            // 
            // btnReceiveFile
            // 
            this.btnReceiveFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReceiveFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReceiveFile.Location = new System.Drawing.Point(8, 150);
            this.btnReceiveFile.Name = "btnReceiveFile";
            this.btnReceiveFile.Size = new System.Drawing.Size(343, 45);
            this.btnReceiveFile.TabIndex = 26;
            this.btnReceiveFile.Text = "Wait for File...";
            this.btnReceiveFile.UseVisualStyleBackColor = true;
            this.btnReceiveFile.Click += new System.EventHandler(this.BtnReceiveFile_Click);
            // 
            // txtReceivePort
            // 
            this.txtReceivePort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtReceivePort.Location = new System.Drawing.Point(235, 100);
            this.txtReceivePort.Name = "txtReceivePort";
            this.txtReceivePort.Size = new System.Drawing.Size(116, 22);
            this.txtReceivePort.TabIndex = 25;
            this.txtReceivePort.Text = "27018";
            // 
            // txtReceiveIpAdress
            // 
            this.txtReceiveIpAdress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtReceiveIpAdress.Location = new System.Drawing.Point(8, 100);
            this.txtReceiveIpAdress.Name = "txtReceiveIpAdress";
            this.txtReceiveIpAdress.Size = new System.Drawing.Size(220, 22);
            this.txtReceiveIpAdress.TabIndex = 24;
            this.txtReceiveIpAdress.Text = "0.0.0.0";
            // 
            // labelReceiverPort
            // 
            this.labelReceiverPort.AutoSize = true;
            this.labelReceiverPort.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelReceiverPort.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelReceiverPort.Location = new System.Drawing.Point(232, 80);
            this.labelReceiverPort.Name = "labelReceiverPort";
            this.labelReceiverPort.Size = new System.Drawing.Size(34, 17);
            this.labelReceiverPort.TabIndex = 23;
            this.labelReceiverPort.Text = "Port";
            // 
            // labelReceiverIPAdress
            // 
            this.labelReceiverIPAdress.AutoSize = true;
            this.labelReceiverIPAdress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelReceiverIPAdress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelReceiverIPAdress.Location = new System.Drawing.Point(5, 80);
            this.labelReceiverIPAdress.Name = "labelReceiverIPAdress";
            this.labelReceiverIPAdress.Size = new System.Drawing.Size(73, 17);
            this.labelReceiverIPAdress.TabIndex = 22;
            this.labelReceiverIPAdress.Text = "IP Address";
            // 
            // labelSaveLocation
            // 
            this.labelSaveLocation.AutoSize = true;
            this.labelSaveLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSaveLocation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSaveLocation.Location = new System.Drawing.Point(5, 12);
            this.labelSaveLocation.Name = "labelSaveLocation";
            this.labelSaveLocation.Size = new System.Drawing.Size(91, 17);
            this.labelSaveLocation.TabIndex = 21;
            this.labelSaveLocation.Text = "Save Location";
            this.labelSaveLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtSaveLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSaveLocation.Location = new System.Drawing.Point(8, 32);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.ReadOnly = true;
            this.txtSaveLocation.Size = new System.Drawing.Size(220, 22);
            this.txtSaveLocation.TabIndex = 20;
            this.txtSaveLocation.Click += new System.EventHandler(this.txtSaveLocation_Click);
            // 
            // btnSelectSaveLocation
            // 
            this.btnSelectSaveLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectSaveLocation.Location = new System.Drawing.Point(235, 27);
            this.btnSelectSaveLocation.Name = "btnSelectSaveLocation";
            this.btnSelectSaveLocation.Size = new System.Drawing.Size(116, 30);
            this.btnSelectSaveLocation.TabIndex = 19;
            this.btnSelectSaveLocation.Text = "Select...";
            this.btnSelectSaveLocation.UseVisualStyleBackColor = true;
            this.btnSelectSaveLocation.Click += new System.EventHandler(this.BtnSelectSaveLocation_Click);
            // 
            // TabPageAbout
            // 
            this.TabPageAbout.Controls.Add(this.GroupBoxAboutDeveloper);
            this.TabPageAbout.Controls.Add(this.GroupBoxAboutApp);
            this.TabPageAbout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TabPageAbout.Location = new System.Drawing.Point(4, 26);
            this.TabPageAbout.Name = "TabPageAbout";
            this.TabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAbout.Size = new System.Drawing.Size(359, 234);
            this.TabPageAbout.TabIndex = 2;
            this.TabPageAbout.Text = "About";
            this.TabPageAbout.UseVisualStyleBackColor = true;
            // 
            // GroupBoxAboutDeveloper
            // 
            this.GroupBoxAboutDeveloper.Controls.Add(this.panel2);
            this.GroupBoxAboutDeveloper.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GroupBoxAboutDeveloper.Location = new System.Drawing.Point(6, 124);
            this.GroupBoxAboutDeveloper.Name = "GroupBoxAboutDeveloper";
            this.GroupBoxAboutDeveloper.Size = new System.Drawing.Size(345, 107);
            this.GroupBoxAboutDeveloper.TabIndex = 1;
            this.GroupBoxAboutDeveloper.TabStop = false;
            this.GroupBoxAboutDeveloper.Text = "About Developers";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDeveloperGithubProfile);
            this.panel2.Controls.Add(this.labelDeveloperWebSite);
            this.panel2.Controls.Add(this.labelDeveloperName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 85);
            this.panel2.TabIndex = 1;
            // 
            // labelDeveloperGithubProfile
            // 
            this.labelDeveloperGithubProfile.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelDeveloperGithubProfile.AutoSize = true;
            this.labelDeveloperGithubProfile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperGithubProfile.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperGithubProfile.Location = new System.Drawing.Point(76, 62);
            this.labelDeveloperGithubProfile.Name = "labelDeveloperGithubProfile";
            this.labelDeveloperGithubProfile.Size = new System.Drawing.Size(196, 15);
            this.labelDeveloperGithubProfile.TabIndex = 9;
            this.labelDeveloperGithubProfile.TabStop = true;
            this.labelDeveloperGithubProfile.Tag = "firats_github_page";
            this.labelDeveloperGithubProfile.Text = "Developer Github Profile: @FiratEski";
            this.labelDeveloperGithubProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedirectLinkLabels);
            // 
            // labelDeveloperWebSite
            // 
            this.labelDeveloperWebSite.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelDeveloperWebSite.AutoSize = true;
            this.labelDeveloperWebSite.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperWebSite.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperWebSite.Location = new System.Drawing.Point(76, 37);
            this.labelDeveloperWebSite.Name = "labelDeveloperWebSite";
            this.labelDeveloperWebSite.Size = new System.Drawing.Size(181, 15);
            this.labelDeveloperWebSite.TabIndex = 8;
            this.labelDeveloperWebSite.TabStop = true;
            this.labelDeveloperWebSite.Tag = "firats_website";
            this.labelDeveloperWebSite.Text = "Developer Website: FiratEski.com";
            this.labelDeveloperWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedirectLinkLabels);
            // 
            // labelDeveloperName
            // 
            this.labelDeveloperName.AutoSize = true;
            this.labelDeveloperName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperName.Location = new System.Drawing.Point(76, 12);
            this.labelDeveloperName.Name = "labelDeveloperName";
            this.labelDeveloperName.Size = new System.Drawing.Size(247, 15);
            this.labelDeveloperName.TabIndex = 5;
            this.labelDeveloperName.Text = "Firat Eski / @firateski / firateski@outlook.com";
            this.labelDeveloperName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::File_Transfer.Properties.Resources.DeveloperIcon_64x64;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GroupBoxAboutApp
            // 
            this.GroupBoxAboutApp.Controls.Add(this.panel1);
            this.GroupBoxAboutApp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GroupBoxAboutApp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupBoxAboutApp.Location = new System.Drawing.Point(6, 6);
            this.GroupBoxAboutApp.Name = "GroupBoxAboutApp";
            this.GroupBoxAboutApp.Size = new System.Drawing.Size(345, 112);
            this.GroupBoxAboutApp.TabIndex = 0;
            this.GroupBoxAboutApp.TabStop = false;
            this.GroupBoxAboutApp.Text = "About File Transfer App";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelAppGithubRepository);
            this.panel1.Controls.Add(this.labelAllRightReserved);
            this.panel1.Controls.Add(this.labelAppNameAndVersion);
            this.panel1.Controls.Add(this.pictureBoxAppIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 90);
            this.panel1.TabIndex = 0;
            // 
            // labelAppGithubRepository
            // 
            this.labelAppGithubRepository.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelAppGithubRepository.AutoSize = true;
            this.labelAppGithubRepository.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppGithubRepository.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppGithubRepository.Location = new System.Drawing.Point(73, 37);
            this.labelAppGithubRepository.Name = "labelAppGithubRepository";
            this.labelAppGithubRepository.Size = new System.Drawing.Size(168, 15);
            this.labelAppGithubRepository.TabIndex = 7;
            this.labelAppGithubRepository.TabStop = true;
            this.labelAppGithubRepository.Tag = "github_repo";
            this.labelAppGithubRepository.Text = "File Transfer Github Repository";
            this.labelAppGithubRepository.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedirectLinkLabels);
            // 
            // labelAllRightReserved
            // 
            this.labelAllRightReserved.AutoSize = true;
            this.labelAllRightReserved.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAllRightReserved.Location = new System.Drawing.Point(73, 62);
            this.labelAllRightReserved.Name = "labelAllRightReserved";
            this.labelAllRightReserved.Size = new System.Drawing.Size(217, 15);
            this.labelAllRightReserved.TabIndex = 6;
            this.labelAllRightReserved.Text = "© 2017 File Transfer - All Right Reserved";
            // 
            // labelAppNameAndVersion
            // 
            this.labelAppNameAndVersion.AutoSize = true;
            this.labelAppNameAndVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppNameAndVersion.Location = new System.Drawing.Point(73, 12);
            this.labelAppNameAndVersion.Name = "labelAppNameAndVersion";
            this.labelAppNameAndVersion.Size = new System.Drawing.Size(155, 15);
            this.labelAppNameAndVersion.TabIndex = 4;
            this.labelAppNameAndVersion.Text = "File Transfer - Version 1.0.0.0";
            this.labelAppNameAndVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxAppIcon
            // 
            this.pictureBoxAppIcon.Image = global::File_Transfer.Properties.Resources.AppIcon_64x64;
            this.pictureBoxAppIcon.Location = new System.Drawing.Point(3, 12);
            this.pictureBoxAppIcon.Name = "pictureBoxAppIcon";
            this.pictureBoxAppIcon.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxAppIcon.TabIndex = 3;
            this.pictureBoxAppIcon.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 264);
            this.Controls.Add(this.MainTabPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.MainTabPage.ResumeLayout(false);
            this.TabPageSender.ResumeLayout(false);
            this.TabPageSender.PerformLayout();
            this.statusStripSender.ResumeLayout(false);
            this.statusStripSender.PerformLayout();
            this.TabPageReceiver.ResumeLayout(false);
            this.TabPageReceiver.PerformLayout();
            this.statusStripReceiver.ResumeLayout(false);
            this.statusStripReceiver.PerformLayout();
            this.TabPageAbout.ResumeLayout(false);
            this.GroupBoxAboutDeveloper.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBoxAboutApp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabPage;
        private System.Windows.Forms.TabPage TabPageSender;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.TextBox txtSendPort;
        private System.Windows.Forms.TextBox txtSendIp;
        private System.Windows.Forms.Label labelSenderPort;
        private System.Windows.Forms.Label labelSenderIPAdress;
        private System.Windows.Forms.Label labelFileLocation;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TabPage TabPageReceiver;
        private System.Windows.Forms.Button btnReceiveFile;
        private System.Windows.Forms.TextBox txtReceivePort;
        private System.Windows.Forms.TextBox txtReceiveIpAdress;
        private System.Windows.Forms.Label labelReceiverPort;
        private System.Windows.Forms.Label labelReceiverIPAdress;
        private System.Windows.Forms.Label labelSaveLocation;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.Button btnSelectSaveLocation;
        private System.Windows.Forms.StatusStrip statusStripSender;
        private System.Windows.Forms.ToolStripStatusLabel labelSendingProgress;
        private System.Windows.Forms.StatusStrip statusStripReceiver;
        private System.Windows.Forms.ToolStripStatusLabel labelReceivedProgress;
        private System.Windows.Forms.TabPage TabPageAbout;
        private System.Windows.Forms.GroupBox GroupBoxAboutDeveloper;
        private System.Windows.Forms.GroupBox GroupBoxAboutApp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAppNameAndVersion;
        private System.Windows.Forms.PictureBox pictureBoxAppIcon;
        private System.Windows.Forms.Label labelAllRightReserved;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDeveloperName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel labelAppGithubRepository;
        private LinkLabel labelDeveloperWebSite;
        private LinkLabel labelDeveloperGithubProfile;
        private ToolStripProgressBar progressBarSendFile;
        private ToolStripProgressBar progressBarReceiveFile;
    }
}

