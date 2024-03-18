﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Database
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        //public int IssueId { get; set; }
        //public virtual Issue Issue { get; set; }
    }
}
