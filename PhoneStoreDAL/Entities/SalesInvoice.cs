using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreDAL.Entities
{
    public class SalesInvoice
    {
        [Key]
        public int SalesInvoiceId { get; set; }

        [Required, StringLength(30)]
        public string Code { get; set; } = string.Empty;

        public DateTime SoldAt { get; set; } = DateTime.UtcNow;

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Tax { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal TotalAmount { get; set; }

        public ICollection<SalesInvoiceDetail> Details { get; set; } = new List<SalesInvoiceDetail>();

    }
}
