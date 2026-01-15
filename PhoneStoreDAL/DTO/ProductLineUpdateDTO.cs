using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStoreDAL.DTO
{
    public class ProductLineUpdateDTO
    {
        public int ProductLineId { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public int ManufacturerId { get; set; }

    }
}
