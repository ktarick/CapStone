﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prs_Serve1.Models
{
    public class RequestLine
    {
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }        
        [Required]
        public int ProductId { get; set; }        
        [Required]
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public RequestLine()
        {
        }
    }
}
