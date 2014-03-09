using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechZoneModPack
{
    public partial class modPackList : UserControl
    {
        private int id;
        //private bool selected = false;
        
        public string modPackName
        {
            get { return modInfoName.Text; }
            set { modInfoName.Text = value; Invalidate(); }
        }

        public string modPackDescription
        {
            get { return modInfoDescription.Text; }
            set { modInfoDescription.Text = value; Invalidate(); }
        }

        public string modPackImage
        {
            get { return modInfoImage.ImageLocation; }
            set { modInfoImage.ImageLocation = value; Invalidate(); }
        }

        public int modPackID
        {
          get { return id; }
          set { id = value; Invalidate(); }
        }

        public modPackList()
        {
            InitializeComponent();
        }

        private void modPackList_Load(object sender, EventArgs e)
        {
            modInfoName.Text = modPackName;
            modInfoDescription.Text = modPackDescription;
            modInfoImage.ImageLocation = modPackImage;
        }
    }
}
