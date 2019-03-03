using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Models.ViewModels;
using AutoMapper;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class ComentarioController : BaseController
    {
        private readonly IComentarioService comentarioServices;
        public ComentarioController(IComentarioService pComentarioServices)
        {
            comentarioServices = pComentarioServices;
        }


        // GET: Comentario
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = comentarioServices.GetAll();
            var viewModel = Mapper.Map<List<ComentarioViewModel>>(model);
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(ComentarioViewModel model)
        {
            Comentario comentario = Mapper.Map<Comentario>(model);
            comentario.Opinion = Sanitizer.GetSafeHtmlFragment(comentario.Opinion);

            comentarioServices.Guardar(comentario);
            return View();
        }


    }
}