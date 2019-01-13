using Cibertec.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.UI.MVC.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        [HttpPost]
        public JsonResult Registro(PersonaViewModel persona)
        {
            persona.FullName = persona.Nombre + " " + persona.Apellidos;
            return Json(persona);
        }
    }
}