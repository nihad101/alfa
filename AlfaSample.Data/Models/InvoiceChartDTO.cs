using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaSample.Data.Models
{
    public class InvoiceChartDTO
    {
        public ChargeType Charge { get; set; }
        public decimal Total { get; set; }
    }
}
