namespace PO
{
    using POLibrary.Logic;
    using POLibrary.Model;
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Products" />
    /// </summary>
    public partial class Products : Form
    {
        /// <summary>
        /// Defines the _product
        /// </summary>
        internal ProductModel _product = new ProductModel();

        /// <summary>
        /// Defines the _edit
        /// </summary>
        internal bool _edit = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Products"/> class.
        /// </summary>
        public Products()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The txtProdPrice_Validated
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void txtProdPrice_Validated(object sender, EventArgs e)
        {
            var value = 0D;

            if (double.TryParse(txtProdPrice.Text, out value))
            {
                txtProdPrice.Text = value.ToString();
                return;
            }

            txtProdPrice.Text = 0.ToString();
        }

        /// <summary>
        /// The btnCreateSupplier_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCreateSupplier_Click(object sender, EventArgs e)
        {
            if (ValidateProductDetails())
            {
                Task.Factory.StartNew(() =>
                {
                    if (_edit)
                    {
                        UpdateProduct();
                    }
                    else
                    {
                        SaveProduct();
                    }
                });
            }
        }

        /// <summary>
        /// The ValidateProductDetails
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool ValidateProductDetails()
        {

            if (string.IsNullOrEmpty(txtProdDescr.Text))
            {
                MessageBox.Show("Please provide a product description", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProdDescr.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProdId.Text))
            {
                MessageBox.Show("Please provide a product ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProdId.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProdPrice.Text))
            {
                MessageBox.Show("Please provide a product price", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProdPrice.Focus();
                return false;
            }
            else
            {
                var prodValue = Convert.ToDouble(txtProdPrice.Text);

                if (prodValue <= 0)
                {
                    MessageBox.Show("Product value must be larger than zero (0)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProdPrice.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The SaveProduct
        /// </summary>
        private void SaveProduct()
        {
            var SuppId = 0;

            Invoke((MethodInvoker)delegate
            {
                SuppId = Convert.ToInt32(cboSupps.SelectedValue);
            });

            object[,] objParams = new object[,] { { "prodDescr", txtProdDescr.Text },
                                                    { "prodCode", txtProdId.Text },
                                                    { "prodAmount", txtProdPrice.Text },
                                                    { "prodSupp", SuppId } };

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().Process("CreateProduct", objParams, conn);
                    if (results != null)
                    {
                        if (results.HasRows)
                        {
                            MessageBox.Show(results.GetString(0), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Product created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Invoke((MethodInvoker)delegate
                            {
                                Close();
                            });
                        }

                        results.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// The UpdateProduct
        /// </summary>
        private void UpdateProduct()
        {
            var prodCode = string.Empty;
            var prodDescr = string.Empty;
            var prodAmount = 0D;
            var prodSuppId = 0;

            Invoke((MethodInvoker)delegate { 

                prodCode = txtProdId.Text;
                prodDescr = txtProdDescr.Text;
                prodAmount = Convert.ToDouble(txtProdPrice.Text);
                prodSuppId = Convert.ToInt32(cboSupps.SelectedValue);

            });

            object[,] objParams = new object[,] { { "prodDescr", prodDescr }, 
                                                    { "prodAmount", prodAmount }, 
                                                    { "prodSuppId", prodSuppId }, 
                                                    { "prodCode",  prodCode }, 
                                                    { "prodId", _product.Id } };

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseProcessor.DatabaseConnectionString))
                {
                    var results = new DatabaseProcessor().Process("UpdateProduct", objParams, conn);
                    if (results != null)
                    {
                        if (results.HasRows)
                        {
                            MessageBox.Show(results.GetString(0), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Product updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// The Products_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Products_Load(object sender, EventArgs e)
        {
            RetrieveSupplierList();
           
        }

        /// <summary>
        /// The ShowForm
        /// </summary>
        /// <param name="edit">The edit<see cref="bool"/></param>
        /// <param name="product">The product<see cref="ProductModel"/></param>
        public void ShowForm(bool edit, ProductModel product)
        {

            _product = product;
            _edit = edit;

            Show();
        }

        /// <summary>
        /// The RetrieveSupplierList
        /// </summary>
        private void RetrieveSupplierList()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    var suppliers = new DatabaseProcessor().RetrieveSuppliers("RetrieveSuppliers");

                    Invoke((MethodInvoker)delegate
                    {
                        cboSupps.DataSource = new BindingList<SupplierModel>(suppliers); ;
                        cboSupps.DisplayMember = "Name";
                        cboSupps.ValueMember = "Id";

                        PopulateProducts();

                    });

                  
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate {
                        MessageBox.Show(ex.Message.ToString());
                        DisableControls(true);
                    });
                }

            });
        }

        private void PopulateProducts() {

            if (_product != null)
            {
                txtProdDescr.Text = _product.Description;
                txtProdPrice.Text = _product.Amount.ToString();
                txtProdId.Text = _product.Code;
                cboSupps.SelectedValue = _product.SupplierId;
            }
        }

        /// <summary>
        /// The DisableControls
        /// </summary>
        /// <param name="disabled">The disabled<see cref="bool"/></param>
        private void DisableControls(bool disabled)
        {

            txtProdDescr.Enabled = !disabled;
            txtProdId.Enabled = !disabled;
            txtProdPrice.Enabled = !disabled;
            cboSupps.Enabled = !disabled;

            btnCreateSupplier.Enabled = !disabled;

        }

        private void Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchProducts.UnhideForm();
        }
    }
}
