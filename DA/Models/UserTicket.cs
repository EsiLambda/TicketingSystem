using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class UserTicket
    {
        public UserTicket()
        {
            ID = Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(40)]
        public string UserInformationID { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(40)]
        public string Topic { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Section { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(7)]
        public string Importance { get; set; }

        public DateTime Date { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(500)]
        public string Description { get; set; }
    }
}
