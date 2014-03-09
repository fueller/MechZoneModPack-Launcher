using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MechZoneModPack;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using EQATEC.Analytics.Monitor;
using System.Deployment.Application;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Drawing.Imaging;
using fNbt;


namespace MechZoneModPack
{
	public partial class mainForm : Form
	{
        List<string> output = new List<string>();
        public static IAnalyticsMonitor monitor = AnalyticsMonitorFactory.CreateMonitor("A645BAB7505648C3AE67645A9DB77EF7");
        List<modPackList> modPacks = new List<modPackList>();
        jsonClasses.modpacks modPackList;
        int selected = Properties.Settings.Default.selectedModPack;
                
        public mainForm()
		{
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            monitor.Start();
            InitializeComponent();
		}

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                button1.Visible = true;
                usernameText.Text = "philip.lawall@web.de";
                debugCheck.Checked = true;
            }
            else
            {
                button1.Visible = false;
            }

            this.themeSelecter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ramSelect.DropDownStyle = ComboBoxStyle.DropDownList;

            ToolTip.SetToolTip(websiteStatus, "Website Status\r\nCurrenty Offline\r\n");
            ToolTip.SetToolTip(loginStatus, "Login Server Status\r\nCurrenty Offline\r\n");
            ToolTip.SetToolTip(sessionStatus, "Session Server Status\r\nCurrenty Offline\r\n");
            ToolTip.SetToolTip(skinsStatus, "Skin Server Status\r\nCurrenty Offline\r\n");
            ToolTip.SetToolTip(realmStatus, "Realms Server Status\r\nCurrenty Offline\r\n");
            ToolTip.SetToolTip(usernameText, "Your username\r\nor Mojang Mail");
            ToolTip.SetToolTip(passwordText, "Your Minecraft or\r\nMojang password");
            ToolTip.SetToolTip(savePasswordCheck, "Save password\r\nWARNING: saves password unencryted!");
            
            this.Text = this.Text + " " + (ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Assembly.GetExecutingAssembly().GetName().Version.ToString());
            //this.Text = rm.GetString("form1mainText", cult_ger) + (ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Assembly.GetExecutingAssembly().GetName().Version.ToString());

            usernameText.Text = Properties.Settings.Default.email;
            resHeight.Value = Properties.Settings.Default.height;
            resWidth.Value = Properties.Settings.Default.width;
            
            ramComb.Checked = Properties.Settings.Default.ram;
            resolutionComb.Checked = Properties.Settings.Default.resolution;
            updateFiles.Checked = Properties.Settings.Default.updateFiles;
            noServerCheckOnStart.Checked = Properties.Settings.Default.noServerCheck;
            extraJavaParameterText.Text = Properties.Settings.Default.extraJavaParameter;
            themeSelecter.SelectedIndex = Properties.Settings.Default.theme;
            javaPathLabel.Text = Properties.Settings.Default.javaPath;

            themeSelecter_SelectedIndexChanged(null, null);

            if (Properties.Settings.Default.nickname != "xx")
            {
                welcomeMessage.Text = "Welcome back " + Properties.Settings.Default.nickname;
            }
            else
            {
                welcomeMessage.Text = "MechZone ModPack";
            }

            for (int i = 512; i <= 16384; i = i + 512)
            {
                ramSelect.Items.Add(i.ToString() + " MB");
            }

            if (Properties.Settings.Default.savePassword)
            {
                passwordText.Text = Properties.Settings.Default.password;
            }
            else
            {
                passwordText.Text = "";
                Properties.Settings.Default.password = "";
            }

            ramSelect.SelectedIndex = Properties.Settings.Default.ramLast;
            savePasswordCheck.Checked = Properties.Settings.Default.savePassword;
            passwordText.Text = Properties.Settings.Default.password;
            //MessageBox.Show(Properties.Settings.Default.password.ToString());

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                selected = Properties.Settings.Default.selectedModPack;
                modPackList = JsonConvert.DeserializeObject<jsonClasses.modpacks>(File.ReadAllText(vb.appdata() + "\\temp\\modpacks.json"));
                logTextBox.Clear();
                #region old login and start

                /*if (Properties.Settings.Default.selectedModPack == 0)
            {
                monitor.TrackFeature("login");
                logTextBox.Clear();
                try
                {
                    monitor.TrackFeatureStart("loginProzedure");
                    //string version = "1.6.4";
                    string name = "1.6.4-Forge";
                    //string name = "1.7.2-Forge";

                    Download dl = new Download();
                    dl.ShowDialog();


                    string session = vb.getSessionKey(usernameText.Text, passwordText.Text);
                    if (session == "error")
                    {
                        monitor.TrackFeatureCancel("loginProzedure");
                    }
                    else
                    {
                        //MessageBox.Show(session);
                        //MessageBox.Show(vb.GetJavaInstallationPath().ToString());
                        //process1.StartInfo.FileName = vb.GetJavaInstallationPath() + "javaw.exe";
                        //process1.StartInfo.WorkingDirectory = vb.appdata() + "";
                        string arguments = "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump ";

                        if (ramComb.Checked)
                        {
                            arguments += "-Xmx" + ramSelect.Text.Replace(" MB", "") + "M";
                        }
                        else
                        {
                            arguments += "-Xmx1G";
                        }
                        arguments += " " + extraJavaParameterText.Text;
                        arguments += " -Djava.library.path="
                            + vb.appdata() + "\\versions\\" + name + "\\" + name + "-natives -cp "
                            + vb.appdata() + "\\libraries\\net\\minecraftforge\\minecraftforge\\minecraftforge.jar;"
                            //+ vb.appdata() + "\\libraries\\com\\mumfrey\\liteloader\\1.6.4\\liteloader-1.6.4.jar;"
                            + vb.appdata() + "\\libraries\\net\\minecraft\\launchwrapper\\1.8\\launchwrapper-1.8.jar;"
                            + vb.appdata() + "\\libraries\\org\\ow2\\asm\\asm-all\\4.1\\asm-all-4.1.jar;"
                            + vb.appdata() + "\\libraries\\org\\scala-lang\\scala-library\\2.10.2\\scala-library-2.10.2.jar;"
                            + vb.appdata() + "\\libraries\\org\\scala-lang\\scala-compiler\\2.10.2\\scala-compiler-2.10.2.jar;"
                            + vb.appdata() + "\\libraries\\lzma\\lzma\\0.0.1\\lzma-0.0.1.jar;"
                            + vb.appdata() + "\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\4.5\\jopt-simple-4.5.jar;"
                            + vb.appdata() + "\\libraries\\com\\paulscode\\codecjorbis\\20101023\\codecjorbis-20101023.jar;"
                            + vb.appdata() + "\\libraries\\com\\paulscode\\codecwav\\20101023\\codecwav-20101023.jar;"
                            + vb.appdata() + "\\libraries\\com\\paulscode\\libraryjavasound\\20101123\\libraryjavasound-20101123.jar;"
                            + vb.appdata() + "\\libraries\\com\\paulscode\\librarylwjglopenal\\20100824\\librarylwjglopenal-20100824.jar;"
                            + vb.appdata() + "\\libraries\\com\\paulscode\\soundsystem\\20120107\\soundsystem-20120107.jar;"
                            + vb.appdata() + "\\libraries\\argo\\argo\\2.25_fixed\\argo-2.25_fixed.jar;"
                            + vb.appdata() + "\\libraries\\org\\bouncycastle\\bcprov-jdk15on\\1.47\\bcprov-jdk15on-1.47.jar;"
                            + vb.appdata() + "\\libraries\\com\\google\\guava\\guava\\14.0\\guava-14.0.jar;"
                            + vb.appdata() + "\\libraries\\org\\apache\\commons\\commons-lang3\\3.1\\commons-lang3-3.1.jar;"
                            + vb.appdata() + "\\libraries\\commons-io\\commons-io\\2.4\\commons-io-2.4.jar;"
                            + vb.appdata() + "\\libraries\\net\\java\\jinput\\jinput\\2.0.5\\jinput-2.0.5.jar;"
                            + vb.appdata() + "\\libraries\\net\\java\\jutils\\jutils\\1.0.0\\jutils-1.0.0.jar;"
                            + vb.appdata() + "\\libraries\\com\\google\\code\\gson\\gson\\2.2.2\\gson-2.2.2.jar;"
                            + vb.appdata() + "\\libraries\\org\\lwjgl\\lwjgl\\lwjgl\\2.9.0\\lwjgl-2.9.0.jar;"
                            + vb.appdata() + "\\libraries\\org\\lwjgl\\lwjgl\\lwjgl_util\\2.9.0\\lwjgl_util-2.9.0.jar;"
                            + vb.appdata() + "\\versions\\" + name + "\\" + name + ".jar net.minecraft.launchwrapper.Launch "
                            + "--username " + Properties.Settings.Default.nickname + " --session " + session + " --version " + name + " --gameDir "
                            + vb.appdata() + " --assetsDir "
                            + vb.appdata() + "\\assets --tweakClass cpw.mods.fml.common.launcher.FMLTweaker";
                        //+ " --tweakClass com.mumfrey.liteloader.launch.LiteLoaderTweaker";

                        if (resolutionComb.Checked)
                        {
                            arguments += " --width " + resWidth.Value + " --height " + resHeight.Value;
                        }

                        //MessageBox.Show(arguments);
                        //process1.StartInfo.Arguments = arguments;
                        //process1.StartInfo.RedirectStandardOutput = true;
                        //process1.StartInfo.UseShellExecute = false;
                        //StreamReader reader = process1.StandardOutput;

                        ProcessStartInfo start = new ProcessStartInfo();

                        string javaPath = vb.GetJavaInstallationPath();
                        if (javaPath == null)
                        {
                            MessageBox.Show("Die javaw Datei konnte nicht gefunden werden!\nBitte wähle diese nun aus!\nSie liegt meist unter \"C:\\Program Files (x86)\\Java\\jre7\\bin\\javaw.exe\"\noder \"C:\\Program Files\\Java\\jre7\\bin\\javaw.exe\"", "Could not find File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (openJavaFile.ShowDialog() == DialogResult.OK)
                            {
                                javaPath = openJavaFile.FileName;
                                Properties.Settings.Default.javaPath = javaPath;
                                Properties.Settings.Default.Save();
                                javaPathLabel.Text = Properties.Settings.Default.javaPath;
                            }
                        }

                        start.FileName = javaPath;

                        start.Arguments = arguments;
                        start.RedirectStandardError = true;
                        start.UseShellExecute = false;
                        start.WorkingDirectory = vb.appdata();


                        using (Process process = Process.Start(start))
                        {

                            process.ErrorDataReceived += ErrorReceived;
                            process.BeginErrorReadLine();
                        }


                        monitor.TrackFeatureStop("loginProzedure");
                    }
                }
                catch (Exception ex)
                {
                    ErrorWindow err = new ErrorWindow();
                    err.ex = ex;
                    err.ShowDialog();
                    monitor.TrackException(ex, "loginButton");
                }
            }
            else
            {*/
                #endregion

                if (!Directory.Exists(vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag))
                {
                    vb.debug("Directory doesn't exist", "Login");
                    DialogResult result = MessageBox.Show("ModPack not downloaded!\nDo you want to download the Pack?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                    {
                        vb.debug("Start Download", "Login");
                        vb.createFolderStructure(selected, modPackList);
                        List<bool> download = new List<bool>();
                        for (int i = 0; i < 7; i++)
                        {
                            download.Add(false);
                        }
                        DownloadNew dl = new DownloadNew();
                        dl.packID = Properties.Settings.Default.selectedModPack;
                        dl.modPackList = modPackList;
                        dl.select = download;
                        dl.ShowDialog();
                        MessageBox.Show("Download Complete\nPlease login again to start the Game", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }else{/*Console.WriteLine("*Do nothing*");*/}
                }
                else
                {
                    vb.debug("Directory exist", "Login");
                    //Check Version
                    List<bool> versions = newVersionAvailable(selected);
                    bool newVersion = false;
                    for (int i = 0; i < versions.Count; i++)
                    {
                        if (versions[i] != true)
                        {
                            newVersion = true;
                        }
                    }
                    if (newVersion)
                    {
                        DialogResult result = MessageBox.Show("A new ModPack version is available!\nDo you want to update your Pack?", "New Version available", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        vb.debug("New Version available", "Login");
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            DownloadNew dl = new DownloadNew();
                            dl.packID = Properties.Settings.Default.selectedModPack;
                            dl.modPackList = modPackList;
                            dl.select = versions;
                            dl.ShowDialog();

                            string localVersionPath = vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\localVersion.json";

                            File.Delete(localVersionPath);

                                using(StreamWriter sw = new StreamWriter(localVersionPath))
	                            {
                                    jsonClasses.version generateVersion = new jsonClasses.version();
                                    generateVersion.configVersion = modPackList.list[selected].configVersion;
                                    generateVersion.deleteVersion = modPackList.list[selected].deleteVersion;
                                    generateVersion.modsVersion = modPackList.list[selected].modsVersion;
                                    generateVersion.sonstigesVersion = modPackList.list[selected].sonstigesVersion;
                                    generateVersion.assetsVersion = modPackList.list[selected].assetsVersion;
                                    generateVersion.nativesVersion = modPackList.list[selected].nativesVersion;
                                    generateVersion.librariesVersion = modPackList.list[selected].librariesVersion;

                                    string json = JsonConvert.SerializeObject(generateVersion,Formatting.Indented);
                                    sw.Write(json);
	                            }
                        }
                        
                        
                    }
                    Console.WriteLine(newVersion.ToString());
                }
                {
                    vb.debug("Starting Minecraft", "Login");
                    string[] session = vb.getSessionKey(usernameText.Text, passwordText.Text);
                    if (session[1] == "error") { Console.WriteLine("error"); }
                    else
                    {
                        string arguments = "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump ";
                        if (ramComb.Checked)
                        {
                            arguments += "-Xmx" + ramSelect.Text.Replace(" MB", "") + "M";
                        }
                        else
                        {
                            arguments += "-Xmx1G";
                        }
                        arguments += " " + extraJavaParameterText.Text + " ";
                        arguments += modPackList.list[selected].arguments.Replace("%APPDATA%", vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag).Replace("%USERNAME%", Properties.Settings.Default.nickname).Replace("%UUID%", session[0]).Replace("%VERSION%", modPackList.list[selected].versionsPath).Replace("%ACCESSTOKEN%", session[1]);
                        if (resolutionComb.Checked)
                        {
                            arguments += " --width " + resWidth.Value + " --height " + resHeight.Value;
                        }
                        
                        //MessageBox.Show(arguments);
                        vb.debug("Logging in", "Arguments");
                        vb.debug(arguments, "Arguments");
                        ProcessStartInfo start = new ProcessStartInfo();

                        string javaPath = vb.GetJavaInstallationPath();
                        if (javaPath == null)
                        {
                            MessageBox.Show("Die javaw Datei konnte nicht gefunden werden!\nBitte wähle diese nun aus!\nSie liegt meist unter \"C:\\Program Files (x86)\\Java\\jre7\\bin\\javaw.exe\"\noder \"C:\\Program Files\\Java\\jre7\\bin\\javaw.exe\"", "Could not find File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (openJavaFile.ShowDialog() == DialogResult.OK)
                            {
                                javaPath = openJavaFile.FileName;
                                Properties.Settings.Default.javaPath = javaPath;
                                Properties.Settings.Default.Save();
                                javaPathLabel.Text = Properties.Settings.Default.javaPath;
                            }
                        }

                        start.FileName = javaPath;

                        start.Arguments = arguments;
                        start.RedirectStandardError = true;
                        start.UseShellExecute = false;
                        start.WorkingDirectory = vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag;
                        using (Process process = Process.Start(start))
                        {
                            vb.debug("Minecraft Startet", "Login");
                            process.ErrorDataReceived += ErrorReceived;
                            process.BeginErrorReadLine();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        private List<bool> newVersionAvailable(int modpack)
        {
            List<bool> result = new List<bool>();
            

            string localVersionPath = vb.appdata() + "\\modpacks\\" + modPackList.list[modpack].tag + "\\localVersion.json";
            jsonClasses.version localVersions = null; /* = JsonConvert.DeserializeObject<jsonClasses.version>(File.ReadAllText(localVersion));*/
            
            if (!File.Exists(localVersionPath))
	        {
		        using(StreamWriter sw = new StreamWriter(localVersionPath))
	            {
                    jsonClasses.version generateVersion = new jsonClasses.version();
                    generateVersion.configVersion = modPackList.list[modpack].configVersion;
                    generateVersion.deleteVersion = modPackList.list[modpack].deleteVersion;
                    generateVersion.modsVersion = modPackList.list[modpack].modsVersion;
                    generateVersion.sonstigesVersion = modPackList.list[modpack].sonstigesVersion;
                    generateVersion.assetsVersion = modPackList.list[modpack].assetsVersion;
                    generateVersion.nativesVersion = modPackList.list[modpack].nativesVersion;
                    generateVersion.librariesVersion = modPackList.list[modpack].librariesVersion;

                    string json = JsonConvert.SerializeObject(generateVersion,Formatting.Indented);
                    sw.Write(json);
	            }
                localVersions = JsonConvert.DeserializeObject<jsonClasses.version>(File.ReadAllText(localVersionPath));
	        }
            else
            {
                localVersions = JsonConvert.DeserializeObject<jsonClasses.version>(File.ReadAllText(localVersionPath));
            }

            if (modPackList.list[modpack].modsVersion == localVersions.modsVersion) {result.Add(true);}
            else {result.Add(false);}

            if (modPackList.list[modpack].configVersion == localVersions.configVersion) { result.Add(true); }
            else { result.Add(false); }

            if (modPackList.list[modpack].deleteVersion == localVersions.deleteVersion) { result.Add(true); }
            else { result.Add(false); }

            if (modPackList.list[modpack].sonstigesVersion == localVersions.sonstigesVersion) { result.Add(true); }
            else { result.Add(false); }

            if (modPackList.list[modpack].assetsVersion == localVersions.assetsVersion) { result.Add(true); }
            else { result.Add(false); }

            if (modPackList.list[modpack].nativesVersion == localVersions.nativesVersion) { result.Add(true); }
            else { result.Add(false); }

            if (modPackList.list[modpack].librariesVersion == localVersions.librariesVersion) { result.Add(true); }
            else { result.Add(false); }

            return result;
        }

        delegate void logTextAdd(string text);
        
        void addLogText(string value)
        {
            int maxlength = 100;

            if (InvokeRequired)
            {
                BeginInvoke(new logTextAdd(addLogText), new object[] { value });
                return;
            }

            logTextBox.Text += value + Environment.NewLine;

            if (logTextBox.Lines.Length > maxlength)
            {
                string[] newLines = new string[maxlength];
                Array.Copy(logTextBox.Lines, 1, newLines, 0, maxlength);
                logTextBox.Lines = newLines;
            }
            
            //logTextBox.Text += value + "\n";
            //logTextBox.AppendText(value + "\n");
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
             
            
            //this.Update();
        }

        private void ErrorReceived(object sender, DataReceivedEventArgs e)
        {
            addLogText(e.Data);
        }

        #region status
        private void status()
        {
            monitor.TrackFeature("updateStartus");
            dynamic data = vb.getServerStatus();

            if (data != null)
            {
                if (data.v != 9)
                {
                    MessageBox.Show("Es ist ein Fehler aufgetreten!\nBitte wende dich an fueller\nfueller@mechzone.net", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                    updateStatus.Location = new Point(778, 50);
                    mojangStatus.Visible = false;

                    //Session Server
                    if (data.report.session.status == "up")
                    {
                        sessionStatus.Image = Properties.Resources.statusOn;
                        ToolTip.SetToolTip(sessionStatus, "Session Server Status\r\n" + data.report.session.title + "\r\n");
                    }
                    else
                    {
                        sessionStatus.Image = Properties.Resources.statusOff;
                        ToolTip.SetToolTip(sessionStatus, "Session Server Status\r\n" + data.report.session.title + "\r\n");
                    }

                    //Website
                    if (data.report.website.status == "up")
                    {
                        websiteStatus.Image = Properties.Resources.statusOn;
                        ToolTip.SetToolTip(websiteStatus, "Website Status\r\n" + data.report.website.title + "\r\n");
                    }
                    else
                    {
                        websiteStatus.Image = Properties.Resources.statusOff;
                        ToolTip.SetToolTip(websiteStatus, "Website Status\r\n" + data.report.website.title + "\r\n");
                    }

                    //skins
                    if (data.report.skins.status == "up")
                    {
                        skinsStatus.Image = Properties.Resources.statusOn;
                        ToolTip.SetToolTip(skinsStatus, "Skins Status\r\n" + data.report.skins.title + "\r\n");
                    }
                    else
                    {
                        skinsStatus.Image = Properties.Resources.statusOff;
                        ToolTip.SetToolTip(skinsStatus, "Skins Status\r\n" + data.report.skins.title + "\r\n");
                    }

                    //realms
                    if (data.report.realms.status == "up")
                    {
                        realmStatus.Image = Properties.Resources.statusOn;
                        ToolTip.SetToolTip(realmStatus, "Realms Status\r\n" + data.report.realms.title + "\r\n");
                    }
                    else
                    {
                        realmStatus.Image = Properties.Resources.statusOff;
                        ToolTip.SetToolTip(realmStatus, "Realms Status\r\n" + data.report.realms.title + "\r\n");
                    }

                    //login
                    if (data.report.login.status == "up")
                    {
                        loginStatus.Image = Properties.Resources.statusOn;
                        ToolTip.SetToolTip(loginStatus, "Login Server Status\r\n" + data.report.login.title + "\r\n");
                    }
                    else
                    {
                        loginStatus.Image = Properties.Resources.statusOff;
                        ToolTip.SetToolTip(loginStatus, "Login Server Status\r\n" + data.report.login.title + "\r\n");
                    }
                    this.Update();
                }
            }
        }
        #endregion

        #region options

        private void usernameText_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.email = usernameText.Text;
            Properties.Settings.Default.Save();
        }

        private void ramComb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ram = ramComb.Checked;
            Properties.Settings.Default.Save();
            monitor.TrackFeature("ramComb");
            if (ramComb.Checked)
            {
                ramSelect.Enabled = true;
            }
            else
            {
                ramSelect.Enabled = false;
            }
        }

        private void resolutionComb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.resolution = resolutionComb.Checked;
            Properties.Settings.Default.Save();
            monitor.TrackFeature("resolutionComb");
            if (resolutionComb.Checked)
            {
                resWidth.Enabled = true;
                resHeight.Enabled = true;
                resX.Enabled = true;
            }
            else
            {
                resWidth.Enabled = false;
                resHeight.Enabled = false;
                resX.Enabled = false;
            }
        }

        private void resWidth_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.width = resWidth.Value;
            Properties.Settings.Default.Save();
        }

        private void resHeight_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.height = resHeight.Value;
            Properties.Settings.Default.Save();
        }

        private void ramSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.ramLast = ramSelect.SelectedIndex;            
            Properties.Settings.Default.Save();
        }

        private void ramSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ramLast = ramSelect.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void noServerCheckOnStart_CheckedChanged(object sender, EventArgs e)
        {
            
            if (noServerCheckOnStart.Checked)
            {
                Properties.Settings.Default.noServerCheck = true;
                monitor.TrackFeature("noServerCheckOn");
            }
            else
            {
                Properties.Settings.Default.noServerCheck = false;
                monitor.TrackFeature("noServerCheckOff");
            }

            Properties.Settings.Default.Save();

        }

        #endregion

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(vb.appdata() + "\\temp\\"))
            {
                Directory.Delete(vb.appdata() + "\\temp\\", true);
            }            
            monitor.Stop();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            this.Update();
            if (Properties.Settings.Default.noServerCheck == false)
            {
                status();                
            }

            vb.checkVersion();

            try
            {
                modPackList = JsonConvert.DeserializeObject<jsonClasses.modpacks>(File.ReadAllText(vb.appdata() + "\\temp\\modpacks.json"));
                
                for (int i = 0; i < modPackList.list.Count; i++)
                {
                    modPacks.Add(new modPackList());
                    modPacks[i].BackColor = System.Drawing.SystemColors.ControlLight;
                    modPacks[i].Name = "modPack" + i;
                    modPacks[i].Location = new Point(3, 3 + (113 * i));
                    modPacks[i].modPackName = modPackList.list[i].name;
                    modPacks[i].modPackDescription = modPackList.list[i].shortDescription;
                    modPacks[i].modPackID = i;
                    modPacks[i].Click += modInfoChangelogButton_Click;
                    modPacks[i].modPackImage = vb.downloadLocation() + "/modpack/modpacks/" + modPackList.list[i].tag + "/" + modPackList.list[i].logo;
                    panel1.Controls.Add(modPacks[i]);
                }
            

            this.Update();
            try
            {
                modPacks[Properties.Settings.Default.selectedModPack].BorderStyle = BorderStyle.Fixed3D;
            }
            catch (Exception)
            {
                modPacks[0].BorderStyle = BorderStyle.Fixed3D;
            }
            try
            {
                showDescription(Properties.Settings.Default.selectedModPack);
            }
            catch (Exception)
            {
                showDescription(0);
            }
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        void modInfoChangelogButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < modPacks.Count; i++)
			{
                modPacks[i].BorderStyle = BorderStyle.None;
                if (sender.Equals(modPacks[i]))
	            {
                    modPacks[i].BorderStyle = BorderStyle.Fixed3D;
                    Properties.Settings.Default.selectedModPack = i;
                    Properties.Settings.Default.Save();
                    int selected = Properties.Settings.Default.selectedModPack;
                    //Console.WriteLine(selected.ToString());
                    showDescription(i);
	            }
			}
            
        }

        private void updateStatus_Click(object sender, EventArgs e)
        {
            status();
        }

        private void savePasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savePassword = savePasswordCheck.Checked;
            if (savePasswordCheck.Checked)
            {
                Properties.Settings.Default.password = passwordText.Text;
            }
            else
            {
                Properties.Settings.Default.password = "";
            }
            Properties.Settings.Default.Save();
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            
            
            if (Properties.Settings.Default.savePassword == false)
            {
                Properties.Settings.Default.password = "";
            }
            else
            {
                Properties.Settings.Default.password = passwordText.Text;
            }
            
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto://fueller@mechzone.de");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/fueller/vBoxingModPack");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/fueller/vBoxingModPack/issues");
        }

        private void openDirectory_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", vb.appdata());
        }

        private void themeSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(themeSelecter.SelectedIndex.ToString());
            Properties.Settings.Default.theme = themeSelecter.SelectedIndex;
            Properties.Settings.Default.Save();
            switch (themeSelecter.SelectedIndex)
            {
                case 0:
                    this.BackgroundImage = Properties.Resources.Bild1;
                    infosTabPage.BackgroundImage = Properties.Resources.Bild1_mitte;
                    infosTabPage.BackgroundImageLayout = ImageLayout.Stretch;
                    optionTabPage.BackgroundImage = Properties.Resources.Bild1_mitte;
                    optionTabPage.BackgroundImageLayout = ImageLayout.Stretch;
                    contactTabPage.BackgroundImage = Properties.Resources.Bild1_mitte;
                    contactTabPage.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Update();
                    break;
                case 1:
                    this.BackgroundImage = Properties.Resources.Bild2;
                    infosTabPage.BackgroundImage = Properties.Resources.Bild2_mitte;
                    infosTabPage.BackgroundImageLayout = ImageLayout.Stretch;
                    optionTabPage.BackgroundImage = Properties.Resources.Bild2_mitte;
                    optionTabPage.BackgroundImageLayout = ImageLayout.Stretch;
                    contactTabPage.BackgroundImage = Properties.Resources.Bild2_mitte;
                    contactTabPage.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Update();
                    break;
                case 2:
                    this.BackgroundImage = null;
                    infosTabPage.BackgroundImage = null;
                    optionTabPage.BackgroundImage = null;
                    contactTabPage.BackgroundImage = null;
                    this.Update();
                    break;
                default:
                    break;
            }
        }

        private void extraJavaParameterText_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.extraJavaParameter = extraJavaParameterText.Text;
            Properties.Settings.Default.Save();
        }

        private void updateFiles_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.updateFiles = updateFiles.Checked;
            Properties.Settings.Default.Save();

            //MessageBox.Show(Properties.Settings.Default.updateFiles.ToString());
        }

        private void infosMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 5)
            {
                sendErrorLog.Visible = true;
                sendLogBG.Visible = true;
            }
            else
            {
                sendErrorLog.Visible = false;
                sendLogBG.Visible = false;
            }
            //Console.WriteLine(e.TabPageIndex);
        }

        private void sendErrorLog_Click(object sender, EventArgs e)
        {
            sendLastCrashLog_Click(sender, e);
            //vb.sendErrorLog(logTextBox.Text, null);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<bool> test = newVersionAvailable(Properties.Settings.Default.selectedModPack);
            MessageBox.Show("");
            
            /*DownloadNew test = new DownloadNew();
            //test.packID = Properties.Settings.Default.selectedModPack;
            test.packID = 1;
            test.modPackList = modPackList;
            test.ShowDialog();*/
            /*try
            {
                int nix = 0;
                int test = 100 / nix;
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }*/
            
            /*Image test = Image.FromFile(@"D:\temp\test.png");
            string result = ImageToBase64String(test, ImageFormat.Png);
            StreamWriter write = new StreamWriter(@"D:\temp\test.txt");
            write.Write(result);*/
            //Console.Write("done");
            //Console.WriteLine(result);
        }

        private void sendLastCrashLog_Click(object sender, EventArgs e)
        {
            selected = Properties.Settings.Default.selectedModPack;
            try
            {
                var directory = new DirectoryInfo(vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\crash-reports");
                var myFile = (from f in directory.GetFiles() orderby f.LastWriteTime descending select f).First();
                StreamReader reader = new StreamReader(myFile.OpenRead());
                string error = "Modpack: " + modPackList.list[selected].name + "\n\n";
                error += reader.ReadToEnd();
                vb.sendErrorLog(error, null);
                reader.Close();
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        private void sendLastClientLog_Click(object sender, EventArgs e)
        {
            selected = Properties.Settings.Default.selectedModPack;
            try
            {
                string error = "";

                StringBuilder sb = new StringBuilder();

                Stream stream = File.Open(vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\ForgeModLoader-client-0.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(stream);

                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
                int maxLen = 150000;
                error += "Länge: " + sb.Length + " Modpack: " + modPackList.list[selected].name + "\n\n";

                //Console.WriteLine(sb.Length);
                //Console.WriteLine(sb.Length - maxLen);

                if (sb.Length < maxLen)
                {
                    error += sb.ToString();
                }
                else
                {
                    error += sb.ToString(sb.Length - maxLen, maxLen);
                }
                vb.sendErrorLog(error, null);
                
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
            
        }

        private void changeJavaPath_Click(object sender, EventArgs e)
        {
            try
            {
                string javaPath = vb.GetJavaInstallationPath();
                MessageBox.Show("Bitte wähle nun javaw.exe aus!\nSie liegt meist unter \"C:\\Program Files\\Java\\jre7\\bin\\javaw.exe\"", "javaw.exe Pfad ändern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (openJavaFile.ShowDialog() == DialogResult.OK)
                {
                    javaPath = openJavaFile.FileName;
                    Properties.Settings.Default.javaPath = javaPath;
                    Properties.Settings.Default.Save();
                    javaPathLabel.Text = Properties.Settings.Default.javaPath;
                }
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        private void passwordText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, null);
            }
        }

        public static void addBugToSpreadsheet(string text, string link)
        {

            try
            {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create("https://docs.google.com/forms/d/1VIoN_o9TnAuQ5PptQj459c6R-dhXtXPvd-x-SFOBXQg/formResponse");

                ASCIIEncoding encoding = new ASCIIEncoding();
                string postData = "entry.1715453108=" + Properties.Settings.Default.email + " " + Properties.Settings.Default.nickname;
                postData += "&entry.1075040391=" + link;
                postData += "&entry.107304472=" + text;
                byte[] data = encoding.GetBytes(postData);

                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;

                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        #region image
        private string ImageToBase64String(Image image, ImageFormat format)
        {
            try
            {
                string base64;
                using (MemoryStream memory = new MemoryStream())
                {
                    image.Save(memory, format);
                    base64 = Convert.ToBase64String(memory.ToArray());
                }
                return base64;
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
                return null;
            }
        }

        private Image ImageFromBase64String(string base64)
        {
            try
            {
                if (base64 != null)
                {
                    Image result;
                    using (MemoryStream memory = new MemoryStream(Convert.FromBase64String(base64)))
                    {
                        result = Image.FromStream(memory);
                    }
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
                return null;
            }
        }
        #endregion

        private void showDescription(int id)
        {
            modInfoImage.ImageLocation = vb.downloadLocation() + "/modpack/modpacks/" + modPackList.list[id].tag + "/" + modPackList.list[id].mainLogo;
            modInfoDescription.Text = modPackList.list[id].longDescription;
            selectedModPack.Text = "Selected ModPack:\n" + modPackList.list[id].name;
        }

        private void modInfoChangelogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Changelog changelog = new Changelog();
                changelog.webpage = new Uri(modPackList.list[Properties.Settings.Default.selectedModPack].changelogUrl);
                changelog.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        private void modInfoModListBtn_Click(object sender, EventArgs e)
        {
            selected = Properties.Settings.Default.selectedModPack;
            //Console.WriteLine(selected);
            try
            {
                modList list = new modList();

                if (File.Exists(vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\temp\\mods.json"))
                {
                    File.Delete(vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\temp\\mods.json");
                }

                
                vb.downloadFile(modPackList.list[selected].modsFile, vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\temp\\mods.json", null);
                jsonClasses.filesList mods = JsonConvert.DeserializeObject<jsonClasses.filesList>(File.ReadAllText(vb.appdata() + "\\modpacks\\" + modPackList.list[selected].tag + "\\temp\\mods.json"));
                
                list.temp = mods;
                list.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorWindow err = new ErrorWindow();
                err.ex = ex;
                err.ShowDialog();
            }
        }

        private void modInfoDownloadBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you realy want to redownload the Pack?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //vb.createFolderStructure(Properties.Settings.Default.selectedModPack, modPackList);
                List<bool> download = new List<bool>();
                for (int i = 0; i < 7; i++)
                {
                    download.Add(false);
                }
                DownloadNew dl = new DownloadNew();
                dl.packID = Properties.Settings.Default.selectedModPack;
                dl.modPackList = modPackList;
                dl.select = download;
                dl.ShowDialog();
                MessageBox.Show("Download Complete\nPlease login to start the Game", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void infoBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //Console.WriteLine(e.Url.ToString());
            e.Cancel = true;
            Process.Start(e.Url.ToString());
        }

        private void debugCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.debugMode = debugCheck.Checked;
            Properties.Settings.Default.Save();
        }
	}
}