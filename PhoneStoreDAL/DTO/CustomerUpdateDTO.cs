using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.DTO
{
    public class CustomerUpdateDTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = "";
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
