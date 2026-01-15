using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace PhoneStoreDAL.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(30)] public string? Phone { get; set; }
        [StringLength(120)] public string? Email { get; set; }
        [StringLength(250)] public string? Address { get; set; }

        public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();

    }
}
