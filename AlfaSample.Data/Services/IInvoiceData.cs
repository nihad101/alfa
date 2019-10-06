using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaSample.Data.Models;

namespace AlfaSample.Data.Services
{
    public interface IInvoiceData
    {
        IEnumerable<Invoice> GetAll();
        Invoice GetInvoice(string invoiceNumber, string companyName);
        void Add(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(string invoiceNumber, string companyName);
        InvoiceChart GetInvoiceChart(int year, int month);
    }
}
