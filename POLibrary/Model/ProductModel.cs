using System;

namespace POLibrary.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public double Amount { get; set; }
        public string Code { get; set; }
        public string Error { get; set; }

        public int Qty { get; set; }
    }
}