using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreDAL.Entities
{
    public class ProductVariant
    {
        [Key]
        public int ProductVariantId { get; set; }

        public int ProductLineId { get; set; }
        public ProductLine? ProductLine { get; set; }

        [Required, StringLength(50)]
        public string Color { get; set; } = "Unknown";

        public int StorageGb { get; set; }

        [Required, StringLength(50)]
        public string Sku { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        public int QuantityInStock { get; set; }

        public ICollection<ImeiUnit> ImeiUnits { get; set; } = new List<ImeiUnit>();
        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; } = new List<PurchaseInvoiceDetail>();

    }
}
