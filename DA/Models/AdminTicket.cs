using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class AdminTicket
    {
        public AdminTicket()
        {
            ID = Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public Guid UserTicketID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string Topic { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Section { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(17)]
        public string Status { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime LastUpdate { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(500)]
        public string Description { get; set; }
    }
}
