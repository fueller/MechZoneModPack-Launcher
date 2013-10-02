using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vBoxingModPack
{
    public partial class status : Form
    {
        public status()
        {
            InitializeComponent();
        }

        public string stat { get; set; }
        public string returnval { get; set; }
        public bool canceled { get; set; }
        
        private void Download_Load(object sender, EventArgs e)
        {
            this.canceled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.canceled = true;
            this.Close();
        }

        private void status_Shown(object sender, EventArgs e)
        {
            this.canceled = false;
            switch (stat)
            {
                case "login":
                    this.Text = "Logging In";
                    this.returnval = "true";
                    this.doing.Text = "Checking Version";

                    vb.checkVersion();
                    break;
                default:
                    break;
            }
        }

        public void SetProgress(int progress)
        {
            progressBar1.Value = progress;
        }

    }
}
