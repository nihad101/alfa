using AlfaSample.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlfaSample.Models
{
    public class ClientViewModel
    {
        [Required]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Required]
        public string Contract { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public DateTime ContractDateStart { get; set; }
        public DateTime ContractDateEnd { get; set; }
        public StatusType Status { get; set; }
    }
}