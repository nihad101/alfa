using AlfaSample.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlfaSample.Data.Models;
using AlfaSample.Models;
using AutoMapper;

namespace AlfaSample.Controllers
{
    public class InvoiceChartController : Controller
    {
        IInvoiceData invoiceDb;
        public InvoiceChartController(IInvoiceData db) 
        {
            this.invoiceDb = db;
        }
        // GET: InvoiceChart
        public ActionResult Index(int year, int month)
        {
            var viewModel = new InvoiceChartViewModel();
            var invoiceChart = invoiceDb.GetInvoiceChart(year, month);
            Mapper.Map(invoiceChart, viewModel);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}