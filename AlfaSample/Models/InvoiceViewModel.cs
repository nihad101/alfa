using AlfaSample.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlfaSample.Models
{
    public class InvoiceViewModel
    {
        [Required]
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public ChargeType Charge { get; set; }
        public decimal Rate { get; set; }
        public int Units { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}