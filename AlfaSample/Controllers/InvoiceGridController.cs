using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using AlfaSample.Models;
using AlfaSample.Data.Services;
using AlfaSample.Data.Models;
using AutoMapper;

namespace AlfaSample.Controllers
{
    public class InvoiceGridController : Controller
    {
        IInvoiceData invoiceDb;
        public InvoiceGridController(IInvoiceData db)
        {
            this.invoiceDb = db;
        }

        public ActionResult Read(DataSourceRequest request)
        {
            var models = new List<InvoiceViewModel>();
            Mapper.Map(invoiceDb.GetAll(), models);

            return Json(models.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(DataSourceRequest request, InvoiceViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var invoice = new Invoice();
                Mapper.Map(model, invoice);
                invoiceDb.Add(invoice);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update(DataSourceRequest request, InvoiceViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var invoice = new Invoice();
                Mapper.Map(model, invoice);
                invoiceDb.Update(invoice);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(DataSourceRequest request, InvoiceViewModel model)
        {
            if (model != null)
            {
                invoiceDb.Delete(model.InvoiceNumber, model.CompanyName);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}