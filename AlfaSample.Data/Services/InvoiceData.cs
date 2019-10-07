using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaSample.Data.Models;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AlfaSample.Data.Services
{
    public class InvoiceData: IInvoiceData
    {
        private readonly AlfaDbContext db;

        public InvoiceData(AlfaDbContext db) 
        {
            this.db = db;
        }
        public IEnumerable<Invoice> GetAll()
        {
            return from c in db.Invoice
                   orderby c.CompanyName
                   select c;
        }

        public Invoice GetInvoice(string invoiceNumber, string companyName)
        {
            return db.Invoice.FirstOrDefault(c => c.CompanyName == companyName && c.InvoiceNumber == invoiceNumber);
        }

        public void Add(Invoice invoice)
        {
            db.Invoice.Add(invoice);
            db.SaveChanges();
        }

        public void Update(Invoice invoice)
        {
            var entry = db.Entry(invoice);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string invoiceNumber, string companyName)
        {
            var client = db.Invoice.Find(invoiceNumber, companyName);
            db.Invoice.Remove(client);
            db.SaveChanges();
        }

        public InvoiceChart GetInvoiceChart(int year, int month) 
        {
            var paramYear = new SqlParameter("@year", year);
            var paramMonth = new SqlParameter("@month", month);

            var sqlResult =
                db.Database.SqlQuery<InvoiceChartDTO>
                ("dbo.GetInvoiceChartData @year, @month", paramYear, paramMonth).ToList();

            var invoiceChart = new InvoiceChart() 
                                {
                                    Year = year,
                                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                                    Day = sqlResult.FirstOrDefault(x => x.Charge == ChargeType.Day).Total,
                                    Night = sqlResult.FirstOrDefault(x => x.Charge == ChargeType.Night).Total,
                                    Weekend = sqlResult.FirstOrDefault(x => x.Charge == ChargeType.Weekend).Total,
                                };

            return invoiceChart;
        }

        public bool ImportInvoice(String path) {

            var sqlResult =
                db.Database.ExecuteSqlCommand("dbo.spImportInvoice @path", new SqlParameter("@path", path));

            return sqlResult > 0;
        }
    }
}
