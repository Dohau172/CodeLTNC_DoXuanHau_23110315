using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PhoneStoreDAL.Entities.Enums;


namespace PhoneStoreDAL.Entities
{
    public class WarrantyStatusLog
    {
        [Key]
        public int WarrantyStatusLogId { get; set; }

        public int WarrantyTicketId { get; set; }
        public WarrantyTicket? WarrantyTicket { get; set; }

        public WarrantyStatus Status { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        public int ChangedByEmployeeId { get; set; }
        public Employee? ChangedByEmployee { get; set; }

        [StringLength(300)]
        public string? Note { get; set; }


    }
}
