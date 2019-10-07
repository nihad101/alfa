using AlfaSample.Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlfaSample.Controllers
{
    public class ImportInvoiceController : Controller
    {
        IInvoiceData invoiceDb;
        public ImportInvoiceController(IInvoiceData db)
        {
            this.invoiceDb = db;
        }

        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    file.SaveAs(physicalPath);

                    invoiceDb.ImportInvoice(physicalPath);
                }
            }
            return Content("");
        }

        public ActionResult Remove(string[] fileNames)
        {

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                         System.IO.File.Delete(physicalPath);
                    }
                }
            }
            return Content("");
        }
    }
}