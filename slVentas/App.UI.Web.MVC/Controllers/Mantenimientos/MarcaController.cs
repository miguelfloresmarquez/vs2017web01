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
    public class MarcaController : Controller
    {
        private readonly IMarcaService marcaServices;
        // GET: Marca
        public MarcaController(IMarcaService pMarcaServices)
        {
            marcaServices = pMarcaServices;
        }

        public ActionResult Index()
        {
            IEnumerable<Marca> model = marcaServices.GetAll("");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Marca model)
        {
            bool result = marcaServices.Guardar(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Marca model = marcaServices.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Marca model)
        {
            bool result = marcaServices.Guardar(model);
            return RedirectToAction("Index");
        }
    }
}