using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.DTO
{
    public class ProductVariantUpdateDTO
    {
        public int ProductVariantId { get; set; }
        public int ProductLineId { get; set; }
        public string Color { get; set; } = "Unknown";
        public int StorageGb { get; set; }
        public string Sku { get; set; } = "";
        public decimal SalePrice { get; set; }
    }
}
