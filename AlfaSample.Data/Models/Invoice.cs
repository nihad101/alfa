using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaSample.Data.Models
{
    public class Invoice
    {
        [Key, Column(Order = 0)]
        [Required]
        public String InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Key, Column(Order = 1)]
        [Required]
        public String CompanyName { get; set; }
        public ChargeType Charge { get; set; }
        public decimal Rate { get; set; }
        public int Units { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
