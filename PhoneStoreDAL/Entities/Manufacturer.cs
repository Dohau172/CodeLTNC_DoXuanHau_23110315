using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PhoneStoreDAL.Entities
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();

    }
}
