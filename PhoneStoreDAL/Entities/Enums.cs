using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.Entities
{
    public class Enums
    {
        public enum ImeiStatus { InStock = 0, Sold = 1, InWarranty = 2 }
        public enum WarrantyStatus { Waiting = 0, Received = 1, Repairing = 2, Done = 3, Returned = 4 }
        public enum PaymentMethod { Cash = 0, BankTransfer = 1, Installment = 2 }
        public enum UserRole
        {
            Admin = 1,
            Staff = 2
        }


    }
}
