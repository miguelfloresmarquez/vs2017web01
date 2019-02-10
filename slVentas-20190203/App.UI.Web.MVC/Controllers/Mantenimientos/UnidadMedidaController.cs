using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class UnidadMedidaController : Controller
    {
        // GET: UnidadMedida
        private readonly IUnidadMedidaService unidadMedidaServices;

        public UnidadMedidaController()
        {
            unidadMedidaServices = new UnidadMedidaService();
        }

        public ActionResult Index()
        {
            IEnumerable<UnidadMedida> model = unidadMedidaServices.GetAll("");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UnidadMedida model)
        {
            bool result = unidadMedidaServices.Guardar(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UnidadMedida model = unidadMedidaServices.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(UnidadMedida model)
        {
            bool result = unidadMedidaServices.Guardar(model);
            return RedirectToAction("Index");
        }
    }
}