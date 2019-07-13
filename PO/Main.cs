using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PO
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void tsSuppliers_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item is SearchSuppliers)
                {
                    item.Activate();
                    return;
                }
            }


            SearchSuppliers supps = new SearchSuppliers
            {
                MdiParent = this
            };

            supps.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item is SearchProducts)
                {
                    item.Activate();
                    return;
                }
            }

            SearchProducts prods = new SearchProducts() {
                MdiParent = this
            };

            prods.Show();

        }
    }
}
