using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreDAL.Entities
{
    public class SalesInvoiceDetail
    {
        [Key]
        public int SalesInvoiceDetailId { get; set; }

        public int SalesInvoiceId { get; set; }
        public SalesInvoice? SalesInvoice { get; set; }

        [Required, StringLength(20)]
        public string Imei { get; set; } = string.Empty;

        public ImeiUnit? ImeiUnit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

    }
}
