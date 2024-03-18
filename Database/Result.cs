using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Database
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Mark { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public string Comment { get; set; }
    }
}
