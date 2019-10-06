using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaSample.Data.Models
{
    public class Client
    {
        [Key]
        [Required]
        public String CompanyName { get; set; }
        public String City { get; set; }
        public String Address { get; set; }
        [Required]
        public String Contract { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String ContactPerson { get; set; }
        public DateTime ContractDateStart { get; set; }
        public DateTime ContractDateEnd { get; set; }
        public StatusType Status { get; set; }
    }
}
