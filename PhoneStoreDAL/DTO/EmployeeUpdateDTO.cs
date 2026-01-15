using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.DTO
{
    public class EmployeeUpdateDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "Staff";

    }
}
