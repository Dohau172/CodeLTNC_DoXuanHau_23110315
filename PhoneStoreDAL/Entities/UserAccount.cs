using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreDAL.Entities
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; } = "";

        [Required, StringLength(200)]
        public string PasswordHash { get; set; } = "";

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public UserRole Role { get; set; } = UserRole.Staff;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
