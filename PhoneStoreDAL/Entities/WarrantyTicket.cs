using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PhoneStoreDAL.Entities.Enums;


namespace PhoneStoreDAL.Entities
{
    public class WarrantyTicket
    {
        [Key]
        public int WarrantyTicketId { get; set; }

        [Required, StringLength(30)]
        public string Code { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Imei { get; set; } = string.Empty;

        public ImeiUnit? ImeiUnit { get; set; }

        public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;

        [StringLength(500)] public string? IssueDescription { get; set; }
        [StringLength(300)] public string? Accessories { get; set; }

        public int? TechnicianEmployeeId { get; set; }
        public Employee? TechnicianEmployee { get; set; }

        public WarrantyStatus CurrentStatus { get; set; } = WarrantyStatus.Waiting;

        public ICollection<WarrantyStatusLog> StatusLogs { get; set; } = new List<WarrantyStatusLog>();

    }
}
