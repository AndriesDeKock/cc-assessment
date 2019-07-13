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
    /// Defines the <see cref="SearchSuppliers" />
    /// </summary>
    public partial class SearchSuppliers : Form
    {
        /// <summary>
        /// Defines the thisForm
        /// </summary>
        internal static SearchSuppliers thisForm;

        /// <summary>
        /// Defines the _suppliers
        /// </summary>
        internal List<SupplierModel> _suppliers = new List<SupplierModel>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchSuppliers"/> class.
        /// </summary>
        public SearchSuppliers()
        {
            InitializeComponent();
            thisForm = this;
        }

        /// <summary>
        /// The UnhideForm
        /// </summary>
        public static void UnhideForm()
        {
            thisForm.RetrieveSuppliers();
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
                if (item is Suppliers)
                {
                    item.Activate();
                    return;
                }
            }

            Suppliers supps = new Suppliers()
            {
                MdiParent = this.MdiParent
            };

            Hide();
            supps.ShowForm(false, null);
        }

        /// <summary>
        /// The dgvSupps_CellContentClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dgvSupps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 & e.ColumnIndex == dgvSupps.Columns["colOpen"].Index)
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item is Suppliers)
                    {
                        item.Activate();
                        return;
                    }
                }

                Suppliers supps = new Suppliers
                {
                    MdiParent = this.MdiParent
                };

                var supplier = _suppliers.Single(s => s.Id == Convert.ToInt32(dgvSupps.Rows[e.RowIndex].Cells["id"].Value));

                Hide();
                supps.ShowForm(true, supplier);
            }
        }

        /// <summary>
        /// The FormatSupplierDGV
        /// </summary>
        /// <param name="dgvSupps">The dgvSupps<see cref="DataGridView"/></param>
        private void FormatSupplierDGV(DataGridView dgvSupps)
        {
            foreach (var col in new string[] { "Error" })
            {
                dgvSupps.Columns[col].Visible = false;
            }

            dgvSupps.Columns["Id"].Width = 50;

            DataGridViewButtonColumn colOpen = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Open",
                Name = "colOpen",
                Width = 80,
                UseColumnTextForButtonValue = true
            };

            dgvSupps.Columns.Add(colOpen);

            dgvSupps.Columns["Name"].Width = dgvSupps.Width - (dgvSupps.Columns["Id"].Width + dgvSupps.Columns["colOpen"].Width) - 20;
        }

        /// <summary>
        /// The RetrieveSuppliers
        /// </summary>
        private void RetrieveSuppliers()
        {
            dgvSupps.Columns.Clear();

            Task.Factory.StartNew(() =>
            {
                try
                {
                    _suppliers = new DatabaseProcessor().RetrieveSuppliers("RetrieveSuppliers");

                    Invoke((MethodInvoker)delegate
                    {
                        dgvSupps.DataSource = new BindingList<SupplierModel>(_suppliers);
                        FormatSupplierDGV(dgvSupps);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                    Invoke((MethodInvoker)delegate
                    {
                        dgvSupps.Columns.Clear();
                    });
                }
            });
        }

        /// <summary>
        /// The SearchSuppliers_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void SearchSuppliers_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                RetrieveSuppliers();
            });
        }
    }
}