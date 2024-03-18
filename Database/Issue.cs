using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Database
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EssenceOfIssue { get; set; }

        [Required]
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }

        [Required]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }

        public int? TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public string ImagePath { get; set; }

    }
}
