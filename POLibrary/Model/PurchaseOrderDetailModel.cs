using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLibrary.Model
{
    public class PurchaseOrderDetailModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PurchaseOrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public double Amount { get; set; }
        public int Qty { get; set; }
        public string ProductDescription { get; set; }
        public string Code { get; set; }
        public int SupplierId { get; set; }
        public string Error { get; set; }
        public string rowId { get; set; }
        public bool NewItem { get; set; }
    }
}
