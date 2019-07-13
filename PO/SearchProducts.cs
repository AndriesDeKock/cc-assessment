namespace PO
{
    using POLibrary.Logic;
    using POLibrary.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="SearchProducts" />
    /// </summary>
    public partial class SearchProducts : Form
    {
        /// <summary>
        /// Defines the _products
        /// </summary>
        internal List<ProductModel> _products = new List<ProductModel>();

        /// <summary>
        /// Defines the thisForm
        /// </summary>
        private static SearchProducts thisForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProducts"/> class.
        /// </summary>
        public SearchProducts()
        {
            InitializeComponent();
            thisForm = this;
        }

        /// <summary>
        /// The UnhideForm
        /// </summary>
        public static void UnhideForm()
        {
            thisForm.RetrieveProducts();
            thisForm.Show();
        }

        /// <summary>
        /// The btnNewSupp_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnNewSupp_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item is Products)
                {
                    item.Activate();
                    return;
                }
            }

            Products prods = new Products
            {
                MdiParent = this.MdiParent
            };

            Hide();
            prods.ShowForm(false, null);
        }

        /// <summary>
        /// The dgvProds_CellContentClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dgvProds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 & e.ColumnIndex == dgvProds.Columns["colOpen"].Index)
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item is Products)
                    {
                        item.Activate();
                        return;
                    }
                }

                Products prods = new Products
                {
                    MdiParent = this.MdiParent
                };

                var product = _products.Single(p => p.Id == Convert.ToInt32(dgvProds.Rows[e.RowIndex].Cells["id"].Value));

                Hide();
                prods.ShowForm(true, product);
            }
        }

        /// <summary>
        /// The FormatProductDGV
        /// </summary>
        /// <param name="dgvProds">The dgvProds<see cref="DataGridView"/></param>
        private void FormatProductDGV(DataGridView dgvProds)
        {
            foreach (var item in new string[] { "Error", "supplierid" })
            {
                dgvProds.Columns[item].Visible = false;
            }

            dgvProds.Columns["id"].Width = 50;
            dgvProds.Columns["id"].DisplayIndex = 0;

            dgvProds.Columns["code"].Width = 120;
            dgvProds.Columns["code"].DisplayIndex = 1;
            dgvProds.Columns["code"].HeaderText = "Product Code";

            dgvProds.Columns["description"].DisplayIndex = 2;

            dgvProds.Columns["suppliername"].DisplayIndex = 3;
            dgvProds.Columns["suppliername"].Width = 150;
            dgvProds.Columns["suppliername"].HeaderText = "Supplier";

            dgvProds.Columns["amount"].DisplayIndex = 4;
            dgvProds.Columns["amount"].DefaultCellStyle.Format = "#,##0.00";
            dgvProds.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewButtonColumn colOpen = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colOpen",
                Text = "Open",
                Width = 80,
                UseColumnTextForButtonValue = true
            };

            dgvProds.Columns.Add(colOpen);

            dgvProds.Columns["description"].Width = dgvProds.Width - (dgvProds.Columns["id"].Width + dgvProds.Columns["code"].Width +
                dgvProds.Columns["suppliername"].Width + dgvProds.Columns["amount"].Width + dgvProds.Columns["colOpen"].Width) - 20;
        }

        /// <summary>
        /// The RetrieveProducts
        /// </summary>
        private void RetrieveProducts()
        {
            dgvProds.Columns.Clear();

            Task.Factory.StartNew(() =>
            {
                try
                {
                    _products = new DatabaseProcessor().RetrieveProducts("RetrieveProducts");

                    Invoke((MethodInvoker)delegate
                    {
                        dgvProds.DataSource = new BindingList<ProductModel>(_products);
                        FormatProductDGV(dgvProds);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    Invoke((MethodInvoker)delegate
                    {
                        dgvProds.Columns.Clear();
                    });
                }
            });
        }

        /// <summary>
        /// The SearchProducts_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void SearchProducts_Load(object sender, EventArgs e)
        {
            RetrieveProducts();
        }
    }
}
