using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService categoriaServices;

        public CategoriaController(ICategoriaService pCategoriaServices)
        {
            categoriaServices = pCategoriaServices;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            //IEnumerable<Categoria> model = categoriaServices.GetAll("");
            //return View(model);
            return View();
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        //[HttpPost]
        //public ActionResult Create(Categoria model)
        //{
        //    bool result = categoriaServices.Guardar(model);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Create([ModelBinder(binderType: typeof(CategoriaBinder))] Categoria model)
        {

            bool result = categoriaServices.Guardar(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Categoria model = categoriaServices.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            bool result = categoriaServices.Guardar(model);
            return RedirectToAction("Index");
        }

        public ActionResult Buscar(string filtroPorNombre)
        {
            filtroPorNombre = filtroPorNombre != null ? filtroPorNombre : "";
            var model = categoriaServices.GetAll(filtroPorNombre);
            return PartialView("IndexListado", model);
        }
    }
}