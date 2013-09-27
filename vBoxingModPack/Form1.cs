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
using vBoxingModPack;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using EQATEC.Analytics.Monitor;

namespace vBoxingModPack
{
	public partial class mainForm : Form
	{
        List<string> output = new List<string>();
        public static IAnalyticsMonitor monitor = AnalyticsMonitorFactory.CreateMonitor("A645BAB7505648C3AE67645A9DB77EF7");
        
        public mainForm()
		{            
            monitor.Start();
            InitializeComponent();
		}

        private void mainForm_Load(object sender, EventArgs e)
        {
            
            ToolTip.SetToolTip(websiteStatus, "Website Status\r\nGerade Offline\r\n");
            ToolTip.SetToolTip(loginStatus, "Login Server Status\r\nGerade Offline\r\n");
            ToolTip.SetToolTip(sessionStatus, "Session Server Status\r\nGerade Offline\r\n");
            ToolTip.SetToolTip(skinsStatus, "Skin Server Status\r\nGerade Offline\r\n");
            ToolTip.SetToolTip(realmStatus, "Realms Server Status\r\nGerade Offline\r\n");
            ToolTip.SetToolTip(usernameText, "Deinen Benutzernamen\r\noder deine Mojang Email");
            ToolTip.SetToolTip(passwordText, "Dein Minecraft Passwort oder\r\nMojang Passwort");
            ToolTip.SetToolTip(savePasswordCheck, "Speichere Passwort\r\n(noch nicht verfügbar");

            usernameText.Text = Properties.Settings.Default.email;
            resHeight.Value = Properties.Settings.Default.height;
            resWidth.Value = Properties.Settings.Default.width;
            
            optionEnable.Checked = Properties.Settings.Default.options;
            ramComb.Checked = Properties.Settings.Default.ram;
            resolutionComb.Checked = Properties.Settings.Default.resolution;
            showConsole.Checked = Properties.Settings.Default.console;
            noServerCheckOnStart.Checked = Properties.Settings.Default.noServerCheck;

            if (Properties.Settings.Default.noServerCheck == false)
            {
               status();
            }

            if (Properties.Settings.Default.nickname != "xx")
            {
                welcomeMessage.Text = "Willkommen zurück " + Properties.Settings.Default.nickname;
            }
            else
            {
                welcomeMessage.Text = "vBoxing Mod Pack";
            }

            for (int i = 512; i <= 16384; i = i + 512)
            {
                ramSelect.Items.Add(i.ToString() + " MB");
            }

            ramSelect.SelectedIndex = Properties.Settings.Default.ramLast;
                
        }

        private void usernameText_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.email = usernameText.Text;
            Properties.Settings.Default.Save();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            monitor.TrackFeature("login");
            string session = vb.getSessionKey(usernameText.Text, passwordText.Text);
            if (session == "error")
            {

            }
            else
            {
                //MessageBox.Show(session);
                if (showConsole.Checked)
                {
                    process1.StartInfo.FileName = vb.GetJavaInstallationPath() + "java.exe";
                }
                else
                {
                    process1.StartInfo.FileName = vb.GetJavaInstallationPath() + "javaw.exe";
                }
                process1.StartInfo.WorkingDirectory = vb.appdata() + "\\.vboxing";
                string arguments = "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump ";
                
                if (ramComb.Checked)
	            {
                    arguments += "-Xmx" + ramSelect.Text.Replace(" MB", "") + "M";                         
                }
                else
                {
                    arguments += "-Xmx1G";
                }

                arguments += " -Djava.library.path=" 
                    + vb.appdata() + "\\.vboxing\\versions\\1.6.4-Forge9.11.0.883\\1.6.4-Forge-natives -cp " 
                    + vb.appdata() + "\\.vboxing\\libraries\\net\\minecraftforge\\minecraftforge\\9.11.0.883\\minecraftforge-9.11.0.883.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\net\\minecraft\\launchwrapper\\1.7\\launchwrapper-1.7.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\ow2\\asm\\asm-all\\4.1\\asm-all-4.1.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\scala-lang\\scala-library\\2.10.2\\scala-library-2.10.2.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\scala-lang\\scala-compiler\\2.10.2\\scala-compiler-2.10.2.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\lzma\\lzma\\0.0.1\\lzma-0.0.1.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\net\\sf\\jopt-simple\\jopt-simple\\4.5\\jopt-simple-4.5.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\paulscode\\codecjorbis\\20101023\\codecjorbis-20101023.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\paulscode\\codecwav\\20101023\\codecwav-20101023.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\paulscode\\libraryjavasound\\20101123\\libraryjavasound-20101123.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\paulscode\\librarylwjglopenal\\20100824\\librarylwjglopenal-20100824.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\paulscode\\soundsystem\\20120107\\soundsystem-20120107.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\argo\\argo\\2.25_fixed\\argo-2.25_fixed.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\bouncycastle\\bcprov-jdk15on\\1.47\\bcprov-jdk15on-1.47.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\google\\guava\\guava\\14.0\\guava-14.0.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\apache\\commons\\commons-lang3\\3.1\\commons-lang3-3.1.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\commons-io\\commons-io\\2.4\\commons-io-2.4.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\net\\java\\jinput\\jinput\\2.0.5\\jinput-2.0.5.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\net\\java\\jutils\\jutils\\1.0.0\\jutils-1.0.0.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\com\\google\\code\\gson\\gson\\2.2.2\\gson-2.2.2.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\lwjgl\\lwjgl\\lwjgl\\2.9.0\\lwjgl-2.9.0.jar;" 
                    + vb.appdata() + "\\.vboxing\\libraries\\org\\lwjgl\\lwjgl\\lwjgl_util\\2.9.0\\lwjgl_util-2.9.0.jar;" 
                    + vb.appdata() + "\\.vboxing\\versions\\1.6.4-Forge9.11.0.883\\1.6.4-Forge9.11.0.883.jar net.minecraft.launchwrapper.Launch "
                    + "--username " + Properties.Settings.Default.nickname + " --session " + session + " --version 1.6.4-Forge9.11.0.883 --gameDir " 
                    + vb.appdata() + "\\.vboxing --assetsDir " 
                    + vb.appdata() + "\\.vboxing\\assets --tweakClass cpw.mods.fml.common.launcher.FMLTweaker";
                
                if (resolutionComb.Checked)
                {
                    arguments += " --width " + resWidth.Value + " --height " + resHeight.Value;
                }

                process1.StartInfo.Arguments = arguments;
                //process1.StartInfo.RedirectStandardOutput = true;
                //process1.StartInfo.UseShellExecute = false;
                process1.Start();
                
                //process1.WaitForExit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            status();   
        }

        private void status()
        {
            monitor.TrackFeature("updateStartus");
            dynamic data = vb.getServerStatus();

            if (data != null)
            {
                if (data.v != 9)
                {
                    MessageBox.Show("Es ist ein Fehler aufgetreten!\nBitte wende dich an fueller\nfueller@vboxing.de", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        updateStatus.Location = new Point(778, 89);
                        mojangStatus.Visible = true;
                        mojangStatus.Text = data.psa;
                    }
                    catch (Exception)
                    {
                        updateStatus.Location = new Point(778, 50);
                        mojangStatus.Visible = false;
                    }

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

        private void optionEnable_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.options = optionEnable.Checked;
            Properties.Settings.Default.Save();
            monitor.TrackFeature("optionEnable");
            if (optionEnable.Checked)
            {
                optionenPanel.Enabled = true;
                optionenPanel.Visible = true;
                optionEnable.Location = new Point(53, 293);
                infosMain.Size = new System.Drawing.Size(753, 224);
                
            }
            else
            {
                optionenPanel.Enabled = false;
                optionenPanel.Visible = false;
                optionEnable.Location = new Point(53, 448);
                infosMain.Size = new System.Drawing.Size(753, 360);
            }
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

        private void showConsole_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.console = showConsole.Checked;
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
            monitor.TrackFeature("noServerCheck");
            if (noServerCheckOnStart.Checked)
            {
                Properties.Settings.Default.noServerCheck = true;                
            }
            else
            {
                Properties.Settings.Default.noServerCheck = false;
            }

            Properties.Settings.Default.Save();

        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            monitor.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.numDownFiles = 20;
            Properties.Settings.Default.numFinFiles = 0;
            for (int i = 0; i < 20; i++)
            {
                vb.downloadFile("http://lawall.funpic.de/modpack/files/file1.txt", vb.appdata() + "\\.vboxing\\files\\file" + i + ".txt");
            }
            
            
        }
	}
}