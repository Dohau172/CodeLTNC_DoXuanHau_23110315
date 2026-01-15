using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace PhoneStoreDAL.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, StringLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Role { get; set; } = "Staff";
        public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; } = new List<PurchaseInvoice>();
        public ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
        public ICollection<WarrantyTicket> WarrantyTicketsAssigned { get; set; } = new List<WarrantyTicket>();
        public ICollection<WarrantyStatusLog> WarrantyLogsChanged { get; set; } = new List<WarrantyStatusLog>();

    }
}
