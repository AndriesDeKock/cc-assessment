namespace PO
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Main" />
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The toolStripButton2_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

            SearchProducts prods = new SearchProducts()
            {
                MdiParent = this
            };

            prods.Show();
        }

        /// <summary>
        /// The tsSuppliers_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item is SearchPO)
                {
                    item.Activate();
                    return;
                }
            }

            SearchPO Pos = new SearchPO {
                MdiParent = this
            };

            Pos.Show();

        }
    }
}