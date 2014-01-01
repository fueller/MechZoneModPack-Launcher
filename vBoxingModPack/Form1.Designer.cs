namespace MechZoneModPack
{
	partial class mainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.savePasswordCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.noServerCheckOnStart = new System.Windows.Forms.CheckBox();
            this.updateStatus = new System.Windows.Forms.Button();
            this.welcomeMessage = new System.Windows.Forms.Label();
            this.ramComb = new System.Windows.Forms.CheckBox();
            this.ramSelect = new System.Windows.Forms.ComboBox();
            this.resX = new System.Windows.Forms.Label();
            this.resHeight = new System.Windows.Forms.NumericUpDown();
            this.resWidth = new System.Windows.Forms.NumericUpDown();
            this.resolutionComb = new System.Windows.Forms.CheckBox();
            this.mojangStatus = new System.Windows.Forms.Label();
            this.infosMain = new System.Windows.Forms.TabControl();
            this.infosTabPage = new System.Windows.Forms.TabPage();
            this.infoBrowser = new System.Windows.Forms.WebBrowser();
            this.modPackTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.modInfoModListBtn = new System.Windows.Forms.Button();
            this.modInfoChangelogBtn = new System.Windows.Forms.Button();
            this.modInfoDescription = new System.Windows.Forms.RichTextBox();
            this.modInfoImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabTexturePack = new System.Windows.Forms.TabPage();
            this.optionTabPage = new System.Windows.Forms.TabPage();
            this.changeJavaPath = new System.Windows.Forms.Button();
            this.javaPathLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.sendLastClientLog = new System.Windows.Forms.Button();
            this.sendLastCrashLog = new System.Windows.Forms.Button();
            this.updateFiles = new System.Windows.Forms.CheckBox();
            this.extraJavaPrameters = new System.Windows.Forms.Label();
            this.extraJavaParameterText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.themeSelecter = new System.Windows.Forms.ComboBox();
            this.openDirectory = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contactTabPage = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.sendErrorLog = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.openJavaFile = new System.Windows.Forms.OpenFileDialog();
            this.selectedModPack = new System.Windows.Forms.Label();
            this.realmStatus = new System.Windows.Forms.PictureBox();
            this.skinsStatus = new System.Windows.Forms.PictureBox();
            this.sessionStatus = new System.Windows.Forms.PictureBox();
            this.loginStatus = new System.Windows.Forms.PictureBox();
            this.websiteStatus = new System.Windows.Forms.PictureBox();
            this.sendLogBG = new System.Windows.Forms.PictureBox();
            this.modInfoDownloadBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resWidth)).BeginInit();
            this.infosMain.SuspendLayout();
            this.infosTabPage.SuspendLayout();
            this.modPackTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modInfoImage)).BeginInit();
            this.optionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contactTabPage.SuspendLayout();
            this.logTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendLogBG)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordText
            // 
            resources.ApplyResources(this.passwordText, "passwordText");
            this.passwordText.Name = "passwordText";
            this.passwordText.TextChanged += new System.EventHandler(this.passwordText_TextChanged);
            this.passwordText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passwordText_KeyUp);
            // 
            // usernameText
            // 
            resources.ApplyResources(this.usernameText, "usernameText");
            this.usernameText.Name = "usernameText";
            this.usernameText.TextChanged += new System.EventHandler(this.usernameText_TextChanged);
            // 
            // savePasswordCheck
            // 
            resources.ApplyResources(this.savePasswordCheck, "savePasswordCheck");
            this.savePasswordCheck.BackColor = System.Drawing.Color.Transparent;
            this.savePasswordCheck.Name = "savePasswordCheck";
            this.savePasswordCheck.TabStop = false;
            this.savePasswordCheck.UseVisualStyleBackColor = false;
            this.savePasswordCheck.CheckedChanged += new System.EventHandler(this.savePasswordCheck_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            // 
            // noServerCheckOnStart
            // 
            resources.ApplyResources(this.noServerCheckOnStart, "noServerCheckOnStart");
            this.noServerCheckOnStart.Name = "noServerCheckOnStart";
            this.ToolTip.SetToolTip(this.noServerCheckOnStart, resources.GetString("noServerCheckOnStart.ToolTip"));
            this.noServerCheckOnStart.UseVisualStyleBackColor = true;
            this.noServerCheckOnStart.CheckedChanged += new System.EventHandler(this.noServerCheckOnStart_CheckedChanged);
            // 
            // updateStatus
            // 
            this.updateStatus.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.updateStatus, "updateStatus");
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.UseVisualStyleBackColor = false;
            this.updateStatus.Click += new System.EventHandler(this.updateStatus_Click);
            // 
            // welcomeMessage
            // 
            resources.ApplyResources(this.welcomeMessage, "welcomeMessage");
            this.welcomeMessage.BackColor = System.Drawing.Color.Transparent;
            this.welcomeMessage.ForeColor = System.Drawing.Color.White;
            this.welcomeMessage.Name = "welcomeMessage";
            // 
            // ramComb
            // 
            resources.ApplyResources(this.ramComb, "ramComb");
            this.ramComb.Name = "ramComb";
            this.ramComb.UseVisualStyleBackColor = true;
            this.ramComb.CheckedChanged += new System.EventHandler(this.ramComb_CheckedChanged);
            // 
            // ramSelect
            // 
            resources.ApplyResources(this.ramSelect, "ramSelect");
            this.ramSelect.FormattingEnabled = true;
            this.ramSelect.Name = "ramSelect";
            this.ramSelect.SelectedIndexChanged += new System.EventHandler(this.ramSelect_SelectedIndexChanged);
            this.ramSelect.SelectionChangeCommitted += new System.EventHandler(this.ramSelect_SelectionChangeCommitted);
            // 
            // resX
            // 
            resources.ApplyResources(this.resX, "resX");
            this.resX.Name = "resX";
            // 
            // resHeight
            // 
            resources.ApplyResources(this.resHeight, "resHeight");
            this.resHeight.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
            this.resHeight.Name = "resHeight";
            this.resHeight.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.resHeight.ValueChanged += new System.EventHandler(this.resHeight_ValueChanged);
            // 
            // resWidth
            // 
            resources.ApplyResources(this.resWidth, "resWidth");
            this.resWidth.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
            this.resWidth.Name = "resWidth";
            this.resWidth.Value = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.resWidth.ValueChanged += new System.EventHandler(this.resWidth_ValueChanged);
            // 
            // resolutionComb
            // 
            resources.ApplyResources(this.resolutionComb, "resolutionComb");
            this.resolutionComb.Name = "resolutionComb";
            this.resolutionComb.UseVisualStyleBackColor = true;
            this.resolutionComb.CheckedChanged += new System.EventHandler(this.resolutionComb_CheckedChanged);
            // 
            // mojangStatus
            // 
            this.mojangStatus.BackColor = System.Drawing.Color.Transparent;
            this.mojangStatus.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.mojangStatus, "mojangStatus");
            this.mojangStatus.Name = "mojangStatus";
            // 
            // infosMain
            // 
            this.infosMain.Controls.Add(this.infosTabPage);
            this.infosMain.Controls.Add(this.modPackTabPage);
            this.infosMain.Controls.Add(this.tabTexturePack);
            this.infosMain.Controls.Add(this.optionTabPage);
            this.infosMain.Controls.Add(this.contactTabPage);
            this.infosMain.Controls.Add(this.logTabPage);
            resources.ApplyResources(this.infosMain, "infosMain");
            this.infosMain.Name = "infosMain";
            this.infosMain.SelectedIndex = 0;
            this.infosMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.infosMain_Selecting);
            // 
            // infosTabPage
            // 
            resources.ApplyResources(this.infosTabPage, "infosTabPage");
            this.infosTabPage.Controls.Add(this.infoBrowser);
            this.infosTabPage.Name = "infosTabPage";
            this.infosTabPage.UseVisualStyleBackColor = true;
            // 
            // infoBrowser
            // 
            resources.ApplyResources(this.infoBrowser, "infoBrowser");
            this.infoBrowser.Name = "infoBrowser";
            this.infoBrowser.Url = new System.Uri("http://mechzone.net/modpack/launcher/info/info.html", System.UriKind.Absolute);
            // 
            // modPackTabPage
            // 
            this.modPackTabPage.Controls.Add(this.panel2);
            this.modPackTabPage.Controls.Add(this.panel1);
            resources.ApplyResources(this.modPackTabPage, "modPackTabPage");
            this.modPackTabPage.Name = "modPackTabPage";
            this.modPackTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.modInfoDownloadBtn);
            this.panel2.Controls.Add(this.modInfoModListBtn);
            this.panel2.Controls.Add(this.modInfoChangelogBtn);
            this.panel2.Controls.Add(this.modInfoDescription);
            this.panel2.Controls.Add(this.modInfoImage);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // modInfoModListBtn
            // 
            resources.ApplyResources(this.modInfoModListBtn, "modInfoModListBtn");
            this.modInfoModListBtn.Name = "modInfoModListBtn";
            this.modInfoModListBtn.UseVisualStyleBackColor = true;
            this.modInfoModListBtn.Click += new System.EventHandler(this.modInfoModListBtn_Click);
            // 
            // modInfoChangelogBtn
            // 
            resources.ApplyResources(this.modInfoChangelogBtn, "modInfoChangelogBtn");
            this.modInfoChangelogBtn.Name = "modInfoChangelogBtn";
            this.modInfoChangelogBtn.UseVisualStyleBackColor = true;
            this.modInfoChangelogBtn.Click += new System.EventHandler(this.modInfoChangelogBtn_Click);
            // 
            // modInfoDescription
            // 
            this.modInfoDescription.BackColor = System.Drawing.Color.White;
            this.modInfoDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.modInfoDescription, "modInfoDescription");
            this.modInfoDescription.Name = "modInfoDescription";
            this.modInfoDescription.ReadOnly = true;
            // 
            // modInfoImage
            // 
            resources.ApplyResources(this.modInfoImage, "modInfoImage");
            this.modInfoImage.Name = "modInfoImage";
            this.modInfoImage.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Name = "panel1";
            // 
            // tabTexturePack
            // 
            resources.ApplyResources(this.tabTexturePack, "tabTexturePack");
            this.tabTexturePack.Name = "tabTexturePack";
            this.tabTexturePack.UseVisualStyleBackColor = true;
            // 
            // optionTabPage
            // 
            resources.ApplyResources(this.optionTabPage, "optionTabPage");
            this.optionTabPage.Controls.Add(this.changeJavaPath);
            this.optionTabPage.Controls.Add(this.javaPathLabel);
            this.optionTabPage.Controls.Add(this.label10);
            this.optionTabPage.Controls.Add(this.sendLastClientLog);
            this.optionTabPage.Controls.Add(this.sendLastCrashLog);
            this.optionTabPage.Controls.Add(this.updateFiles);
            this.optionTabPage.Controls.Add(this.extraJavaPrameters);
            this.optionTabPage.Controls.Add(this.extraJavaParameterText);
            this.optionTabPage.Controls.Add(this.label9);
            this.optionTabPage.Controls.Add(this.themeSelecter);
            this.optionTabPage.Controls.Add(this.openDirectory);
            this.optionTabPage.Controls.Add(this.noServerCheckOnStart);
            this.optionTabPage.Controls.Add(this.ramSelect);
            this.optionTabPage.Controls.Add(this.ramComb);
            this.optionTabPage.Controls.Add(this.resolutionComb);
            this.optionTabPage.Controls.Add(this.resWidth);
            this.optionTabPage.Controls.Add(this.resHeight);
            this.optionTabPage.Controls.Add(this.resX);
            this.optionTabPage.Controls.Add(this.pictureBox2);
            this.optionTabPage.Controls.Add(this.pictureBox1);
            this.optionTabPage.Name = "optionTabPage";
            this.optionTabPage.UseVisualStyleBackColor = true;
            // 
            // changeJavaPath
            // 
            resources.ApplyResources(this.changeJavaPath, "changeJavaPath");
            this.changeJavaPath.Name = "changeJavaPath";
            this.changeJavaPath.UseVisualStyleBackColor = true;
            this.changeJavaPath.Click += new System.EventHandler(this.changeJavaPath_Click);
            // 
            // javaPathLabel
            // 
            resources.ApplyResources(this.javaPathLabel, "javaPathLabel");
            this.javaPathLabel.Name = "javaPathLabel";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // sendLastClientLog
            // 
            resources.ApplyResources(this.sendLastClientLog, "sendLastClientLog");
            this.sendLastClientLog.Name = "sendLastClientLog";
            this.sendLastClientLog.UseVisualStyleBackColor = true;
            this.sendLastClientLog.Click += new System.EventHandler(this.sendLastClientLog_Click);
            // 
            // sendLastCrashLog
            // 
            resources.ApplyResources(this.sendLastCrashLog, "sendLastCrashLog");
            this.sendLastCrashLog.Name = "sendLastCrashLog";
            this.sendLastCrashLog.UseVisualStyleBackColor = true;
            this.sendLastCrashLog.Click += new System.EventHandler(this.sendLastCrashLog_Click);
            // 
            // updateFiles
            // 
            resources.ApplyResources(this.updateFiles, "updateFiles");
            this.updateFiles.Name = "updateFiles";
            this.updateFiles.UseVisualStyleBackColor = true;
            this.updateFiles.CheckedChanged += new System.EventHandler(this.updateFiles_CheckedChanged);
            // 
            // extraJavaPrameters
            // 
            resources.ApplyResources(this.extraJavaPrameters, "extraJavaPrameters");
            this.extraJavaPrameters.Name = "extraJavaPrameters";
            // 
            // extraJavaParameterText
            // 
            resources.ApplyResources(this.extraJavaParameterText, "extraJavaParameterText");
            this.extraJavaParameterText.Name = "extraJavaParameterText";
            this.extraJavaParameterText.TextChanged += new System.EventHandler(this.extraJavaParameterText_TextChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // themeSelecter
            // 
            this.themeSelecter.FormattingEnabled = true;
            this.themeSelecter.Items.AddRange(new object[] {
            resources.GetString("themeSelecter.Items"),
            resources.GetString("themeSelecter.Items1"),
            resources.GetString("themeSelecter.Items2")});
            resources.ApplyResources(this.themeSelecter, "themeSelecter");
            this.themeSelecter.Name = "themeSelecter";
            this.themeSelecter.SelectedIndexChanged += new System.EventHandler(this.themeSelecter_SelectedIndexChanged);
            // 
            // openDirectory
            // 
            resources.ApplyResources(this.openDirectory, "openDirectory");
            this.openDirectory.Name = "openDirectory";
            this.openDirectory.UseVisualStyleBackColor = true;
            this.openDirectory.Click += new System.EventHandler(this.openDirectory_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // contactTabPage
            // 
            resources.ApplyResources(this.contactTabPage, "contactTabPage");
            this.contactTabPage.Controls.Add(this.linkLabel3);
            this.contactTabPage.Controls.Add(this.label8);
            this.contactTabPage.Controls.Add(this.linkLabel2);
            this.contactTabPage.Controls.Add(this.label7);
            this.contactTabPage.Controls.Add(this.linkLabel1);
            this.contactTabPage.Controls.Add(this.label6);
            this.contactTabPage.Controls.Add(this.label5);
            this.contactTabPage.Controls.Add(this.label4);
            this.contactTabPage.Controls.Add(this.label3);
            this.contactTabPage.Name = "contactTabPage";
            this.contactTabPage.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            resources.ApplyResources(this.linkLabel3, "linkLabel3");
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.TabStop = true;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // logTabPage
            // 
            this.logTabPage.Controls.Add(this.logTextBox);
            resources.ApplyResources(this.logTabPage, "logTabPage");
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            resources.ApplyResources(this.logTextBox, "logTextBox");
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.TabStop = false;
            // 
            // sendErrorLog
            // 
            resources.ApplyResources(this.sendErrorLog, "sendErrorLog");
            this.sendErrorLog.Name = "sendErrorLog";
            this.sendErrorLog.UseVisualStyleBackColor = true;
            this.sendErrorLog.Click += new System.EventHandler(this.sendErrorLog_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = resources.GetString("resource.FileName");
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // openJavaFile
            // 
            this.openJavaFile.FileName = "javaw.exe";
            resources.ApplyResources(this.openJavaFile, "openJavaFile");
            this.openJavaFile.InitialDirectory = "C:\\Program Files\\Javax\\";
            // 
            // selectedModPack
            // 
            resources.ApplyResources(this.selectedModPack, "selectedModPack");
            this.selectedModPack.BackColor = System.Drawing.Color.Transparent;
            this.selectedModPack.Name = "selectedModPack";
            // 
            // realmStatus
            // 
            resources.ApplyResources(this.realmStatus, "realmStatus");
            this.realmStatus.Name = "realmStatus";
            this.realmStatus.TabStop = false;
            // 
            // skinsStatus
            // 
            resources.ApplyResources(this.skinsStatus, "skinsStatus");
            this.skinsStatus.Name = "skinsStatus";
            this.skinsStatus.TabStop = false;
            // 
            // sessionStatus
            // 
            resources.ApplyResources(this.sessionStatus, "sessionStatus");
            this.sessionStatus.Name = "sessionStatus";
            this.sessionStatus.TabStop = false;
            // 
            // loginStatus
            // 
            resources.ApplyResources(this.loginStatus, "loginStatus");
            this.loginStatus.Name = "loginStatus";
            this.loginStatus.TabStop = false;
            // 
            // websiteStatus
            // 
            resources.ApplyResources(this.websiteStatus, "websiteStatus");
            this.websiteStatus.Name = "websiteStatus";
            this.websiteStatus.TabStop = false;
            // 
            // sendLogBG
            // 
            this.sendLogBG.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.sendLogBG, "sendLogBG");
            this.sendLogBG.Name = "sendLogBG";
            this.sendLogBG.TabStop = false;
            // 
            // modInfoDownloadBtn
            // 
            resources.ApplyResources(this.modInfoDownloadBtn, "modInfoDownloadBtn");
            this.modInfoDownloadBtn.Name = "modInfoDownloadBtn";
            this.modInfoDownloadBtn.UseVisualStyleBackColor = true;
            this.modInfoDownloadBtn.Click += new System.EventHandler(this.modInfoDownloadBtn_Click);
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectedModPack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sendErrorLog);
            this.Controls.Add(this.infosMain);
            this.Controls.Add(this.welcomeMessage);
            this.Controls.Add(this.updateStatus);
            this.Controls.Add(this.websiteStatus);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.sessionStatus);
            this.Controls.Add(this.skinsStatus);
            this.Controls.Add(this.realmStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savePasswordCheck);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.mojangStatus);
            this.Controls.Add(this.sendLogBG);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.resHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resWidth)).EndInit();
            this.infosMain.ResumeLayout(false);
            this.infosTabPage.ResumeLayout(false);
            this.modPackTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modInfoImage)).EndInit();
            this.optionTabPage.ResumeLayout(false);
            this.optionTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contactTabPage.ResumeLayout(false);
            this.contactTabPage.PerformLayout();
            this.logTabPage.ResumeLayout(false);
            this.logTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendLogBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.CheckBox savePasswordCheck;
        private System.Windows.Forms.PictureBox realmStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox websiteStatus;
        private System.Windows.Forms.PictureBox loginStatus;
        private System.Windows.Forms.PictureBox sessionStatus;
        private System.Windows.Forms.PictureBox skinsStatus;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Button updateStatus;
        private System.Windows.Forms.Label welcomeMessage;
        private System.Windows.Forms.Label resX;
        private System.Windows.Forms.NumericUpDown resHeight;
        private System.Windows.Forms.NumericUpDown resWidth;
        private System.Windows.Forms.CheckBox resolutionComb;
        private System.Windows.Forms.CheckBox ramComb;
        private System.Windows.Forms.ComboBox ramSelect;
        private System.Windows.Forms.Label mojangStatus;
        private System.Windows.Forms.CheckBox noServerCheckOnStart;
        private System.Windows.Forms.TabControl infosMain;
        private System.Windows.Forms.TabPage infosTabPage;
        private System.Windows.Forms.TabPage optionTabPage;
        private System.Windows.Forms.TabPage contactTabPage;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button openDirectory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox themeSelecter;
        private System.Windows.Forms.Label extraJavaPrameters;
        private System.Windows.Forms.TextBox extraJavaParameterText;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.CheckBox updateFiles;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button sendErrorLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button sendLastClientLog;
        private System.Windows.Forms.Button sendLastCrashLog;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox sendLogBG;
        private System.Windows.Forms.OpenFileDialog openJavaFile;
        private System.Windows.Forms.Label javaPathLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button changeJavaPath;
        private System.Windows.Forms.TabPage tabTexturePack;
        private System.Windows.Forms.WebBrowser infoBrowser;
        private System.Windows.Forms.TabPage modPackTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox modInfoImage;
        private System.Windows.Forms.RichTextBox modInfoDescription;
        private System.Windows.Forms.Label selectedModPack;
        private System.Windows.Forms.Button modInfoModListBtn;
        private System.Windows.Forms.Button modInfoChangelogBtn;
        private System.Windows.Forms.Button modInfoDownloadBtn;
	}
}

