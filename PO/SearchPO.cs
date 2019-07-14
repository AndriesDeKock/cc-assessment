using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POLibrary.Model;
using POLibrary.Logic;

namespace PO
{
    public partial class SearchPO : Form
    {
        List<PurchaseOrderModel> _purchaseOrders = new List<PurchaseOrderModel>();

        static SearchPO thisForm;

        public SearchPO()
        {
            InitializeComponent();
            thisForm = this;
        }

        private void SearchPO_Load(object sender, EventArgs e)
        {
            RetrievePurchaseOrders();
        }


        private void RetrievePurchaseOrders() {

            dgvPO.Columns.Clear();

            Task.Factory.StartNew(() => {

                try
                {
                    _purchaseOrders = new DatabaseProcessor().RetrievePOS("RetrievePurchaseOrders");

                    Invoke((MethodInvoker)delegate
                    {
                        dgvPO.DataSource = new BindingList<PurchaseOrderModel>(_purchaseOrders);
                        FormatProductDGV(dgvPO);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    Invoke((MethodInvoker)delegate
                    {
                        dgvPO.Columns.Clear();
                    });
                }

            });

        }

        public static void UnhideForm() {

            if (thisForm != null)
            {
                thisForm.RetrievePurchaseOrders();
                thisForm.Show();
            }
        }


        private void FormatProductDGV(DataGridView dgvPO) {

            foreach (var item in new string[] { "Error", "SupplierId" })
            {
                dgvPO.Columns[item].Visible = false;
            }

            dgvPO.Columns["id"].Width = 80;
            dgvPO.Columns["supplier"].Width = 120;

            dgvPO.Columns["amount"].DefaultCellStyle.Format = "#,##0.00";
            dgvPO.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPO.Columns["created"].DefaultCellStyle.Format = "dd MMM yyyy";

            DataGridViewButtonColumn colOpen = new DataGridViewButtonColumn {
                HeaderText = "",
                Text = "Open",
                Name = "colOpen",
                Width = 80,
                UseColumnTextForButtonValue = true
            };

            dgvPO.Columns.Add(colOpen);

            dgvPO.Columns["Description"].Width = dgvPO.Width - (dgvPO.Columns["id"].Width + dgvPO.Columns["Supplier"].Width +
                dgvPO.Columns["Created"].Width + dgvPO.Columns["Amount"].Width + 
                dgvPO.Columns["colOpen"].Width) - 20;

        }

        private void dgvPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvPO.Columns["colOpen"].Index)
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

                var purchaseOrder = _purchaseOrders.Single(po => po.Id == Convert.ToInt32(dgvPO.Rows[e.RowIndex].Cells["id"].Value));

                Hide();
                pos.ShowForm(true, purchaseOrder.SupplierId, purchaseOrder);
            }
        }
    }
}
