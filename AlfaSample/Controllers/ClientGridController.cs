using System;
﻿using System.Collections.Generic;
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
	public partial class ClientGridController : Controller
    {
        IClientData clientDb;
        public ClientGridController(IClientData db) 
        {
            this.clientDb = db;
        }
		public ActionResult Read(DataSourceRequest request)
		{
            var models  = new List<ClientViewModel>();
            Mapper.Map(clientDb.GetAll(), models);

            return Json(models.ToDataSourceResult(request));
		}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(DataSourceRequest request, ClientViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var client = new Client();
                Mapper.Map(model, client);
                clientDb.Add(client);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update(DataSourceRequest request, ClientViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var client = new Client();
                Mapper.Map(model, client);
                clientDb.Update(client);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(DataSourceRequest request, ClientViewModel model)
        {
            if ( model != null)
            {
                clientDb.Delete(model.CompanyName);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
