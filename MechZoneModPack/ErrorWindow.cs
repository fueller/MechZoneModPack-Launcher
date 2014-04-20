using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechZoneModPack
{
    public partial class ErrorWindow : Form
    {
        string error;
        public ErrorWindow()
        {
            InitializeComponent();
        }

        public Exception ex { get; set; }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            MechZoneModPack.mainForm.monitor.TrackException(ex);
            this.Size = new Size(this.Size.Width, 100);
            ok.Location = new Point(339, 32);
            label1.Text = ex.Message;
            error += ex.Message + "\n";
            if (ex.Source != null)
            {
                error += ex.Source + "\n";
            }
            if (ex.HelpLink != null)
            {
                richTextBox1.AppendText(ex.HelpLink + "\n");
            }
            error += ex.HResult.ToString() + "\n";
            if (ex.InnerException != null)
            {
                if (ex.InnerException.HelpLink != null)
                {
                    error += ex.InnerException.HelpLink + "\n";
                }
                if (ex.InnerException.Message != null)
                {
                    error += ex.InnerException.Message + "\n";
                }
            }
            if (ex.StackTrace != null)
            {
                error += ex.StackTrace + "\n";
            }
            richTextBox1.Text = error;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moreInfos.Visible = false;
            richTextBox1.Size = new Size(396, 266);
            richTextBox1.Location = new Point(16, 32);
            ok.Location = new Point(339, 304);
            this.Size = new Size(this.Size.Width, 373);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vb.sendErrorLog(error, ex);
        }

        private void ok_Click(object sender, EventArgs e)
        {

        }
    }
}
