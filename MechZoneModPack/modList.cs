using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechZoneModPack
{
    public partial class modList : Form
    {
        private jsonClasses.filesList list;

        public jsonClasses.filesList temp
        {
            get { return list; }
            set { list = value; }
        }
        public modList()
        {
            InitializeComponent();
        }

        private void modListTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Process.Start(modListTable[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
        }

        private void modList_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < list.files.Count; i++)
                {
                    if (!list.files[i].config)
                    {
                        modListTable.Rows.Add(list.files[i].name, list.files[i].version, list.files[i].forumLink, list.files[i].authors, list.files[i].description);
                    }
                }

                this.Update();
            }
            catch (Exception) { }
            modListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
