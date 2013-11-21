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
        public ErrorWindow()
        {
            InitializeComponent();
        }

        public Exception ex { get; set; }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, 100);
            ok.Location = new Point(339, 32);
            label1.Text = ex.Message;
            if (ex.Source != null)
            {
                richTextBox1.AppendText(ex.Source + "\n");
            }
            if (ex.HelpLink != null)
            {
                richTextBox1.AppendText(ex.HelpLink + "\n");
            }
            if (ex.HResult != null)
            {
                richTextBox1.AppendText(ex.HResult.ToString() + "\n");
            }
            if (ex.InnerException != null)
            {
                if (ex.InnerException.HelpLink != null)
                {
                    richTextBox1.AppendText(ex.InnerException.HelpLink + "\n");
                }
                if (ex.InnerException.Message != null)
                {
                    richTextBox1.AppendText(ex.InnerException.Message + "\n");
                }
            }
            if (ex.StackTrace != null)
            {
                richTextBox1.AppendText(ex.StackTrace + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moreInfos.Visible = false;
            richTextBox1.Size = new Size(396, 266);
            richTextBox1.Location = new Point(16, 32);
            ok.Location = new Point(339, 304);
            this.Size = new Size(this.Size.Width, 373);
        }
    }
}
