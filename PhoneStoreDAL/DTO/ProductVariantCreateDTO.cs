using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.DTO
{
    public class ProductVariantCreateDTO
    {
        public int ProductLineId { get; set; }
        public string Color { get; set; } = "Unknown";
        public int StorageGb { get; set; }
        public string Sku { get; set; } = "";
        public decimal SalePrice { get; set; }

    }
}
