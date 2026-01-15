using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace PhoneStoreDAL.Entities
{
    public class ProductLine
    {
        [Key]
        public int ProductLineId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

    }
}
