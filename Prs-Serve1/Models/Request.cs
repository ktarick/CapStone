using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prs_Serve1.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }        
        [StringLength(80)]
        public string Description { get; set; }
        [StringLength(80)]
        public string Justification { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [StringLength(80)]
        public string DeliveryMode { get; set; }        
        [Required]
        public DateTime SubmittedDate { get; set; }
        [StringLength(10)]
        [Required]
        public string Status { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        [Required]
        public decimal Total { get; set; }
        [Required]
        public bool Active { get; set; }

        public virtual User User { get; set; }
        public virtual IList<RequestLine> RequestLines { get; set; }

        public Request()
        {
        }
    }
}
