using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.DTO
{
    public class ImeiUnitDTO
    {
        public string Imei { get; set; } = "";
        public int ProductVariantId { get; set; }

        // map enum -> int để DTO nhẹ
        public int Status { get; set; }

        public DateTime? SoldAt { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public int WarrantyMonths { get; set; } = 12;
    }
}
