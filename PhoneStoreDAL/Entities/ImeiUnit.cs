using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreDAL.Entities
{
    public class ImeiUnit
    {
        [Key, StringLength(20)]
        public string Imei { get; set; } = string.Empty;

        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        public ImeiStatus Status { get; set; } = ImeiStatus.InStock;

        public DateTime? SoldAt { get; set; }

        public DateTime? WarrantyStartDate { get; set; }
        public int WarrantyMonths { get; set; } = 12;

        public int? ReceivedInPurchaseInvoiceId { get; set; }
        public PurchaseInvoice? ReceivedInPurchaseInvoice { get; set; }
    }
}
