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

        private PurchaseOrderModel _purchaseOrder = new PurchaseOrderModel();

        private List<PurchaseOrderDetailModel> _purchaseOrderDetail = new List<PurchaseOrderDetailModel>();

        /// <summary>
        /// Defines the _suppId
        /// </summary>
        internal int _suppId = 0;

        private bool _edit = false;

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
            PopulatePurchaseOrder();

            _purchaseOrderDto = new PurchaseOrderDto();
            //_purchaseOrderDto.product = new List<ProductModel>();
            _purchaseOrderDto.productDetail = new List<PurchaseOrderDetailModel>();
        }

        /// <summary>
        /// The ShowForm
        /// </summary>
        /// <param name="SuppId">The SuppId<see cref="int"/></param>
        public void ShowForm(bool edit, int SuppId, PurchaseOrderModel purchaseOrder)
        {
            _edit = edit;
            _suppId = SuppId;
            _purchaseOrder = purchaseOrder;

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

        private void PopulatePurchaseOrder()
        {
            if (_purchaseOrder != null)
            {
                txtPODescr.Text = _purchaseOrder.Description;
                RetrievePurchaseOrderDetail();
            }
        }

        private void RetrievePurchaseOrderDetail()
        {
            dgvItems.Columns.Clear();

            Task.Factory.StartNew(() =>
            {
                _purchaseOrderDetail = new DatabaseProcessor().RetrievPOSDetail("RetrievePurchaseOrderDetail", _purchaseOrder.Id);

                Invoke((MethodInvoker)delegate
                {
                    dgvItems.DataSource = new BindingList<PurchaseOrderDetailModel>(_purchaseOrderDetail);

                    _purchaseOrderDto.productDetail = _purchaseOrderDetail;
                    FormatItems(dgvItems);

                    if (dgvItems.Rows.Count > 0)
                    {
                        dgvItems_CellContentClick(dgvItems, new DataGridViewCellEventArgs(dgvItems.Columns["colSelect"].Index, 0));
                    }
                });
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
                if (_edit)
                {
                    UpdatePurchaseOrder();
                }
                else
                {
                    _purchaseOrderDto.Description = txtPODescr.Text;
                    SavePurchaseOrder();
                }
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

        private void UpdatePurchaseOrder()
        {
            var newRows = _purchaseOrderDto.productDetail.Where(p => p.NewItem == true).ToList();
            if (newRows != null)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (var item in newRows)
                    {
                        object[,] objParams = new object[,] { { "poId", item.PurchaseOrderId },
                                                               { "prodId", item.ProductId  },
                                                               { "prodAmount", item.Amount  },
                                                               { "prodQty", item.Qty } };

                        using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                        {
                            var results = new DatabaseProcessor().Process("CreatePurchaseOrderDetail", objParams, conn);

                            if (results != null)
                            {
                                results.Close();
                            }
                        }
                    }

                    Invoke((MethodInvoker)delegate
                    {
                        RetrievePurchaseOrderDetail();
                    });
                });
            }
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

            if (dgvItems.Rows.Count == 0)
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
            foreach (var item in _purchaseOrderDto.productDetail)
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
                        results.Close();

                        Invoke((MethodInvoker)delegate
                        {
                            Close();
                        });
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

            _purchaseOrderDto.productDetail.Add(new PurchaseOrderDetailModel
            {
                Id = productDetails.Id,
                ProductDescription = productDetails.Description,
                ProductId = productDetails.Id,
                Amount = productDetails.Amount,
                DateCreated = DateTime.Now,
                PurchaseOrderId = (_purchaseOrder == null)? 0 : _purchaseOrder.Id,
                Qty = prodQty,
                SupplierId = _suppId,
                Code = productDetails.Code,
                rowId = string.Format("{0:ssfff}", DateTime.Now),
                NewItem = true,
                Error = string.Empty,
            });

            dgvItems.Columns.Clear();
            dgvItems.DataSource = new BindingList<PurchaseOrderDetailModel>(_purchaseOrderDto.productDetail);
            FormatItems(dgvItems);

            Application.DoEvents();
        }

        private void FormatItems(DataGridView dgvItems)
        {
            foreach (var item in new string[] { "productid", "purchaseorderid", "datecreated", "amount", "error",
                "Code", "rowId", "SupplierId", "newItem" })
            {
                dgvItems.Columns[item].Visible = false;
            }

            dgvItems.Columns["id"].Width = 80;
            dgvItems.Columns["id"].DisplayIndex = 0;

            dgvItems.Columns["productdescription"].HeaderText = "Description";
            dgvItems.Columns["productdescription"].DisplayIndex = 1;

            dgvItems.Columns["qty"].HeaderText = "Qty";
            dgvItems.Columns["qty"].DisplayIndex = 2;

            DataGridViewButtonColumn colSelect = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colSelect",
                Text = "Select",
                Width = 80,
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn colDelete = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colDelete",
                Text = "Delete",
                Width = 80,
                UseColumnTextForButtonValue = true
            };

            dgvItems.Columns.Add(colSelect);
            dgvItems.Columns.Add(colDelete);

            dgvItems.Columns["productdescription"].Width = dgvItems.Width - (dgvItems.Columns["id"].Width +
                dgvItems.Columns["qty"].Width + dgvItems.Columns["colDelete"].Width + 
                dgvItems.Columns["colSelect"].Width) - 20;

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

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvItems.Columns["colSelect"].Index)
            {
                var product = _purchaseOrderDetail.SingleOrDefault(p => p.Id == Convert.ToInt32(dgvItems.Rows[e.RowIndex].Cells["id"].Value));
                if (product != null)
                {
                    cboProds.SelectedValue = product.ProductId;
                    txtqty.Text = product.Qty.ToString();
                }
            }
            else if (e.RowIndex > -1 && e.ColumnIndex == dgvItems.Columns["colDelete"].Index)
            {
                if (MessageBox.Show("Are you sure you want to remove this item?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    var ss = "";

                    RemovePurchaseOrderItem(Convert.ToInt32(dgvItems.Rows[e.RowIndex].Cells["id"].Value));
                }
            }
        }

        private void RemovePurchaseOrderItem(int PurchaseOrderItemId)
        {
            Task.Factory.StartNew(() =>
            {
                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().Process("RemovePurchaseOrderItem", new object[,] { { "poId", PurchaseOrderItemId } }, conn);

                    if (results != null)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            RetrievePurchaseOrderDetail();
                        });
                        results.Close();
                    }
                }
            });
        }

        private void cboProds_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtqty.Text = 1.ToString();
        }
    }
}