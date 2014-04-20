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
    public partial class Changelog : Form
    {
        public Uri webpage
        {
            get { return webBrowser1.Url; }
            set { webBrowser1.Url = value; Invalidate(); webBrowser1.Refresh(); }
        }
        
        public Changelog()
        {
            InitializeComponent();
        }

        private void Changelog_Load(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
