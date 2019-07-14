using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POLibrary.Model
{

    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<PurchaseOrderDetailModel> productDetail { get; set; }
    }
}
