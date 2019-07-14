namespace PO
{
    using POLibrary.Logic;
    using POLibrary.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="PurchaseOrders" />
    /// </summary>
    public partial class PurchaseOrders : Form
    {
        /// <summary>
        /// Defines the _suppliers
        /// </summary>
        internal List<SupplierModel> _suppliers = new List<SupplierModel>();

        /// <summary>
        /// Defines the _products
        /// </summary>
        internal List<ProductModel> _products = new List<ProductModel>();

        /// <summary>
        /// Defines the _purchaseOrderDto
        /// </summary>
        internal PurchaseOrderDto _purchaseOrderDto = new PurchaseOrderDto();

        /// <summary>
        /// Defines the _suppId
        /// </summary>
        internal int _suppId = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrders"/> class.
        /// </summary>
        public PurchaseOrders()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The PurchaseOrders_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void PurchaseOrders_Load(object sender, EventArgs e)
        {
            RetrieveProducts();

            _purchaseOrderDto = new PurchaseOrderDto();
            _purchaseOrderDto.product = new List<ProductModel>();
        }

        /// <summary>
        /// The ShowForm
        /// </summary>
        /// <param name="SuppId">The SuppId<see cref="int"/></param>
        public void ShowForm(int SuppId)
        {
            _suppId = SuppId;
            Show();
        }

        /// <summary>
        /// The RetrieveProducts
        /// </summary>
        private void RetrieveProducts()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    _products = new DatabaseProcessor().RetrieveProducts("RetrieveSupplierProducts", _suppId);

                    Invoke((MethodInvoker)delegate
                    {
                        if (_products != null)
                        {
                            cboProds.DataSource = new BindingList<ProductModel>(_products);
                            cboProds.DisplayMember = "Description";
                            cboProds.ValueMember = "Id";
                        }
                        else
                        {
                            MessageBox.Show("No products found", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisableControls(true);
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            });
        }

        private void DisableControls(bool blEnabled)
        {
            cboProds.Enabled = !blEnabled;
            txtPODescr.Enabled = !blEnabled;
            txtqty.Enabled = !blEnabled;
            btnCreatePO.Enabled = !blEnabled;
            btnAddProdItem.Enabled = !blEnabled;
        }

        /// <summary>
        /// The btnCreatePO_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            if (ValidatePODetails())
            {
                _purchaseOrderDto.Description = txtPODescr.Text;

                SavePurchaseOrder();
            }
        }

        /// <summary>
        /// The SavePurchaseOrder
        /// </summary>
        private void SavePurchaseOrder()
        {
            var poDescr = txtPODescr.Text;

            Task.Factory.StartNew(() =>
            {
                object[,] objParams = new object[,] { { "poDescr", poDescr },
                                                       { "poSupp", _suppId } };

                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().ProcessWithOutput("CreatePurchaseOrder", objParams, conn, "poId");

                    if (results != null)
                    {
                        var dataReader = (SqlDataReader)results[0];
                        var poId = (int)results[1];

                        CreatePurchaseOrderDetails(poId);
                        dataReader.Close();
                    }
                }
            });
        }

        /// <summary>
        /// The ValidatePODetails
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool ValidatePODetails()
        {
            if (string.IsNullOrEmpty(txtPODescr.Text))
            {
                MessageBox.Show("Please ensure a description is provided", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPODescr.Focus();
                return false;
            }

            if (lstPOItems.Items.Count == 0)
            {
                MessageBox.Show("Please ensure at least one product item has been added to the purchase order", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// The CreatePurchaseOrderDetails
        /// </summary>
        /// <param name="poId">The poId<see cref="int"/></param>
        private void CreatePurchaseOrderDetails(int poId)
        {
            foreach (var item in _purchaseOrderDto.product)
            {
                object[,] objParams = new object[,] { { "poId", poId },
                                                       { "prodId", item.Id },
                                                       { "prodAmount", item.Amount },
                                                       { "prodQty", item.Qty } };

                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().Process("CreatePurchaseOrderDetail", objParams, conn);
                    if (results != null)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            Close();
                        });

                        results.Close();
                    }
                }
            }
        }

        /// <summary>
        /// The btnAddProdItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnAddProdItem_Click(object sender, EventArgs e)
        {
            int prodItem = Convert.ToInt32(cboProds.SelectedValue);
            int prodQty = Convert.ToInt32(txtqty.Text);

            var productDetails = _products.Single(p => p.Id == prodItem);

            _purchaseOrderDto.product.Add(new ProductModel
            {
                Id = productDetails.Id,
                Description = productDetails.Description,
                Amount = productDetails.Amount,
                Code = productDetails.Code,
                SupplierId = _suppId,
                Qty = prodQty,
                Error = string.Empty
            });

            lstPOItems.Items.Add(productDetails.Description);
        }

        /// <summary>
        /// The txtqty_Validated
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtqty_Validated(object sender, EventArgs e)
        {
            int value = 0;

            if (int.TryParse(txtqty.Text, out value))
            {
                txtqty.Text = value.ToString();
                return;
            }

            txtqty.Text = 0.ToString();
        }

        /// <summary>
        /// The PurchaseOrders_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void PurchaseOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchPO.UnhideForm();
        }
    }
}