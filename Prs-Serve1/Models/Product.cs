using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prs_Serve1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int VendorId { get; set; }                
        [StringLength(30)]
        [Required]
        public string PartNumber { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Price { get; set; } = 0;
        [StringLength(30)]
        [Required]
        public string Unit { get; set; }
        [StringLength(30)]
        public string PhotoPath { get; set; }
        public bool Active { get; set; } = true;

        public virtual Vendor Vendor { get; set; }

        public Product()
        {
        }
    }
}
