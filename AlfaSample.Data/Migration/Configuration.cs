using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaSample.Data.Models;
using AlfaSample.Data.Services;

namespace AlfaSample.Data.Migration
{
     internal sealed class Configuration : DbMigrationsConfiguration<AlfaDbContext>
    {
        public Configuration() 
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }
        protected override void Seed(AlfaDbContext context)
        {
            context.Client.AddOrUpdate(x => x.CompanyName,
                new Client()
                {
                    CompanyName = "BH Telekom",
                    Address = "Malta 5",
                    City = "71000 Sarajevo",
                    Contract = "C1",
                    ContactPerson = "Hamo Hamić",
                    ContractDateEnd = DateTime.Parse("01/01/2016"),
                    ContractDateStart = DateTime.Parse("01/06/2016"),
                    Email = "bhtelekom@bih.net.ba",
                    Phone = "61111222",
                    Status = StatusType.Active
                },
                new Client()
                {
                    CompanyName = "Telekom Srpske",
                    Address = "Trg Krajine 8",
                    City = "51000 Banja Luka",
                    Contract = "B1",
                    ContactPerson = "Marko Markovic",
                    ContractDateEnd = DateTime.Parse("01/06/2016"),
                    ContractDateStart = DateTime.Parse("12/21/2019"),
                    Email = "info@mtel.ba",
                    Phone = "65333444",
                    Status = StatusType.Active
                },
                new Client()
                {
                    CompanyName = "HT Mostar",
                    Address = "Zapadna strana 1",
                    City = "36000 Mostar",
                    Contract = "K1",
                    ContactPerson = "Anto Antić",
                    ContractDateEnd = DateTime.Parse("01/08/2015"),
                    ContractDateStart = DateTime.Parse("5/29/2018"),
                    Email = "info@eronet.ba",
                    Phone = "63555666",
                    Status = StatusType.InActive
                });

            context.Invoice.AddOrUpdate(
                new Invoice() 
                {
                    InvoiceNumber = "A1",
                    InvoiceDate = DateTime.Parse("02/10/2018"),
                    StartDate = DateTime.Parse("01/01/2018"),
                    EndDate = DateTime.Parse("01/31/2018"),
                    CompanyName = "BH Telekom",
                    Charge = ChargeType.Day,
                    Rate = decimal.Parse("0.2"),
                    Units = 1289,
                    Amount = decimal.Parse("257.8"),
                    Tax = decimal.Parse("43.83"),
                    Total = decimal.Parse("1486.24")
                },
                new Invoice()
                {
                    InvoiceNumber = "A1",
                    InvoiceDate = DateTime.Parse("02/10/2018"),
                    StartDate = DateTime.Parse("01/01/2018"),
                    EndDate = DateTime.Parse("01/31/2018"),
                    CompanyName = "HT Telekom",
                    Charge = ChargeType.Night,
                    Rate = decimal.Parse("0.15"),
                    Units = 6567,
                    Amount = decimal.Parse("985.05"),
                    Tax = decimal.Parse("167.46"),
                    Total = decimal.Parse("1486.24")
                },
                new Invoice()
                {
                    InvoiceNumber = "A2",
                    InvoiceDate = DateTime.Parse("02/10/2018"),
                    StartDate = DateTime.Parse("01/01/2018"),
                    EndDate = DateTime.Parse("01/01/2019"),
                    CompanyName = "BH Telekom",
                    Charge = ChargeType.Weekend,
                    Rate = decimal.Parse("0.28"),
                    Units = 98,
                    Amount = decimal.Parse("27.44"),
                    Tax = decimal.Parse("4.66"),
                    Total = decimal.Parse("1486.24")
                },
                 new Invoice()
                 {
                     InvoiceNumber = "A3",
                     InvoiceDate = DateTime.Parse("02/10/2018"),
                     StartDate = DateTime.Parse("01/01/2018"),
                     EndDate = DateTime.Parse("01/01/2019"),
                     CompanyName = "BH Telekom",
                     Charge = ChargeType.Weekend,
                     Rate = decimal.Parse("0.28"),
                     Units = 98,
                     Amount = decimal.Parse("27.44"),
                     Tax = decimal.Parse("4.66"),
                     Total = decimal.Parse("1486.24")
                 });
        }
    }
}
