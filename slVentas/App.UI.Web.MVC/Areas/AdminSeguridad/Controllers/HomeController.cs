using App.Domain.Services.Interfaces;
using App.UI.Web.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Areas.AdminSeguridad.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISeguridadService seguridadServices;

        public HomeController(ISeguridadService pSeguridadServices)
        {
            seguridadServices = pSeguridadServices;
        }
        // GET: Seguridad/Home
        public ActionResult Index()
        {
            var model = seguridadServices.GetAll("");
            return View(model);
        }

        public ActionResult BuscarUsuario(string filtroPorNombre)
        {
            filtroPorNombre = filtroPorNombre != null ? filtroPorNombre : "";
            var model = seguridadServices.GetAll(filtroPorNombre);
            return PartialView("IndexLista", model);
        }

    }
}