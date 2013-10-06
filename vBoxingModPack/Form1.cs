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
using System.Deployment.Application;
using System.Reflection;
using System.Diagnostics;

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
            ToolTip.SetToolTip(savePasswordCheck, "Speichere Passwort\r\nACHTUNG: Speichert Passwort unverschlüsselt!\r\nFunktioniert noch nicht");
            
            this.Text = "vBoxing Mod Pack v." + (ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Assembly.GetExecutingAssembly().GetName().Version.ToString());
            
            usernameText.Text = Properties.Settings.Default.email;
            resHeight.Value = Properties.Settings.Default.height;
            resWidth.Value = Properties.Settings.Default.width;
            
            ramComb.Checked = Properties.Settings.Default.ram;
            resolutionComb.Checked = Properties.Settings.Default.resolution;
            showConsole.Checked = Properties.Settings.Default.console;
            noServerCheckOnStart.Checked = Properties.Settings.Default.noServerCheck;

            //if (Properties.Settings.Default.noServerCheck == false)
            //{
            //   status();
            //}

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

            savePasswordCheck.Checked = Properties.Settings.Default.savePassword;
            passwordText.Text = Properties.Settings.Default.password;
            //MessageBox.Show(Properties.Settings.Default.password.ToString());
        }

        

        private void loginButton_Click(object sender, EventArgs e)
        {
            monitor.TrackFeature("login");
            try
            {
                monitor.TrackFeatureStart("loginProzedure");
                string version = Properties.version.Default.minecraftVer;
                string name = Properties.version.Default.minecraftVer + "-Forge";

                //vb.getFiles();

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
                    if (showConsole.Checked)
                    {
                        process1.StartInfo.FileName = vb.GetJavaInstallationPath() + "java.exe";
                    }
                    else
                    {
                        process1.StartInfo.FileName = vb.GetJavaInstallationPath() + "javaw.exe";
                    }
                    process1.StartInfo.WorkingDirectory = vb.appdata() + "";
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
                        + vb.appdata() + "\\versions\\" + name + "\\" + name + "-natives -cp "
                        + vb.appdata() + "\\libraries\\net\\minecraftforge\\minecraftforge\\9.11.1.916\\minecraftforge-9.11.1.916.jar;"
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

                    if (resolutionComb.Checked)
                    {
                        arguments += " --width " + resWidth.Value + " --height " + resHeight.Value;
                    }

                    //MessageBox.Show(arguments);
                    process1.StartInfo.Arguments = arguments;
                    //process1.StartInfo.RedirectStandardOutput = true;
                    //process1.StartInfo.UseShellExecute = false;
                    monitor.TrackFeatureStop("loginProzedure");
                    process1.Start();
                    
                    /*using (Process process = Process.Start(process1))
                    {
                        using (StreamReader reader = process.StandardOutput)
                        {
                            string result = reader.ReadToEnd();
                            //Console.WriteLine(result);
                            richTextBox1.AppendText(result);
                            Application.DoEvents();
                            this.Update();
                        }
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                monitor.TrackException(ex, "loginButton");
            } 
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
                    MessageBox.Show("Es ist ein Fehler aufgetreten!\nBitte wende dich an fueller\nfueller@vboxing.de", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    updateStatus.Location = new Point(778, 89);
                    mojangStatus.Visible = true;
                    try
                    {                        
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
            jsonClasses.filesList j = vb.checkVersion();

            //modListTable.Columns.Add("name", "Name");
            //modListTable.Columns.Add("version", "Version");
            //modListTable.Columns.Add("forumLink", "Website");

            try
            {
                for (int i = 0; i < j.files.Count; i++)
                {
                    if (!j.files[i].config)
                    {
                        modListTable.Rows.Add(j.files[i].name, j.files[i].version, j.files[i].forumLink); 
                    }
                }
            }
            catch (Exception){}
            modListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void updateStatus_Click(object sender, EventArgs e)
        {
            status();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vb.getLibraries();
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
            Properties.Settings.Default.password = passwordText.Text;
            
            if (!savePasswordCheck.Checked)
            {
                Properties.Settings.Default.password = "";
            }
            
            Properties.Settings.Default.Save();
        }

        private void modListTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //MessageBox.Show(modListTable[e.ColumnIndex, e.RowIndex].Value.ToString());
                Process.Start(modListTable[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto://fueller@vboxing.de");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/fueller/vBoxingModPack");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/fueller/vBoxingModPack/issues");
        }
	}
}