using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prs_Serve1.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Username { get; set; }
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        [StringLength(50)]
        [Required]
        public string Firstname { get; set; }
        [StringLength(50)]
        [Required]
        public string Lastname { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(220)]
        public string Email { get; set; }
        public bool IsReviewer { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool Active { get; set; } = true;

        public User()
        {
        }
    }
}
