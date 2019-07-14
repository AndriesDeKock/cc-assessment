namespace PO
{
    using POLibrary.Logic;
    using POLibrary.Model;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Suppliers" />
    /// </summary>
    public partial class Suppliers : Form
    {
        /// <summary>
        /// Defines the _edit
        /// </summary>
        internal bool _edit = false;

        /// <summary>
        /// Defines the _supplier
        /// </summary>
        internal SupplierModel _supplier = new SupplierModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="Suppliers"/> class.
        /// </summary>
        public Suppliers()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The ShowForm
        /// </summary>
        /// <param name="edit">The edit<see cref="bool"/></param>
        /// <param name="supplier">The supplier<see cref="SupplierModel"/></param>
        public void ShowForm(bool edit, SupplierModel supplier)
        {
            _supplier = supplier;
            _edit = edit;
            Show();
        }

        /// <summary>
        /// The btnCreateSupplier_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCreateSupplier_Click(object sender, EventArgs e)
        {
            if (ValidateSupplierDetails())
            {
                Task.Factory.StartNew(() =>
                {
                    if (_edit)
                    {
                        UpdateSupplier();
                    }
                    else
                    {
                        SaveSupplier();
                    }
                });
            }
        }

        /// <summary>
        /// The PopulateSupplier
        /// </summary>
        private void PopulateSupplier()
        {
            if (_supplier != null)
            {
                btnCreateSupplier.Text = "Update";
                txtSuppName.Text = _supplier.Name;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// The SaveSupplier
        /// </summary>
        private void SaveSupplier()
        {
            object[,] objParams = new object[,] { { "suppName", txtSuppName.Text } };

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().Process("CreateSupplier", objParams, conn);
                    if (results != null)
                    {
                        if (results.HasRows)
                        {
                            MessageBox.Show(results.GetString(0), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Supplier created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Invoke((MethodInvoker)delegate
                            {
                                Close();
                            });
                        }
                    }

                    results.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// The Suppliers_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void Suppliers_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchSuppliers.UnhideForm();
        }

        /// <summary>
        /// The Suppliers_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Suppliers_Load(object sender, EventArgs e)
        {
            PopulateSupplier();
        }

        /// <summary>
        /// The UpdateSupplier
        /// </summary>
        private void UpdateSupplier()
        {
            object[,] objParams = new object[,] { { "suppName", txtSuppName.Text },
                                                    { "suppNo", _supplier.Id } };

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().Process("UpdateSupplier", objParams, conn);
                    if (results != null)
                    {
                        if (results.HasRows)
                        {
                            MessageBox.Show(results.GetString(0), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Supplier updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Invoke((MethodInvoker)delegate
                            {
                                Close();
                            });
                        }
                    }

                    results.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// The ValidateSupplierDetails
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool ValidateSupplierDetails()
        {
            if (string.IsNullOrEmpty(txtSuppName.Text))
            {
                MessageBox.Show("Please ensure the supplier name is provided.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSuppName.Focus();
                return false;
            }

            return true;
        }

        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item is PurchaseOrders)
                {
                    item.Activate();
                    return;
                }
            }

            PurchaseOrders pos = new PurchaseOrders {
                MdiParent = this.MdiParent
            };

            pos.ShowForm(false, _supplier.Id, null);

        }
    }
}