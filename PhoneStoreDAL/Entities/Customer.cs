using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace PhoneStoreDAL.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(120)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(30)] public string? Phone { get; set; }
        [StringLength(120)] public string? Email { get; set; }
        [StringLength(250)] public string? Address { get; set; }

        public ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();

    }
}
