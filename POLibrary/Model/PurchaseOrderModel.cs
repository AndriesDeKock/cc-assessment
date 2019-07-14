using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLibrary.Model
{
   public class PurchaseOrderModel
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }
        public int SupplierId { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }
        public string Error { get; set; }

    }
}
