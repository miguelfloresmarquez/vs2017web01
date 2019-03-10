using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using App.UI.Web.MVC.Filters;
using App.UI.Web.MVC.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    [LoggingFilter]
    [HandleCustomError]
    [Authorize(Roles = "Admin")]
    public class ProductoController : BaseController
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        private readonly IMarcaService marcaService;
        private readonly IUnidadMedidaService unidadMedidaService;

        public ProductoController(IProductoService pProductoService, ICategoriaService pCategoriaService, IMarcaService pMarcaService, IUnidadMedidaService pUnidadMedidaService)
        {
            productoService = pProductoService;
            categoriaService = pCategoriaService;
            marcaService = pMarcaService;
            unidadMedidaService = pUnidadMedidaService;
        }
        // GET: Producto
        public ActionResult Index(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");

            IEnumerable<Producto> model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return View(model);
        }

        public ActionResult IndexVM(ProductoSearchViewModel model)
        {
            string filterByName = string.IsNullOrWhiteSpace(model.FilterByName) ? "" : model.FilterByName.Trim();
            model.Categorias = categoriaService.GetAll("").ToList();
            model.Marcas = marcaService.GetAll("").ToList();
            model.Productos = productoService.GetAll(filterByName, model.FilterByCategoria, model.FilterByMarca).ToList();

            return View(model);
        }

        public ActionResult Index2(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            try
            {
                filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
                ViewBag.Categorias = categoriaService.GetAll("");
                ViewBag.Marcas = marcaService.GetAll("");

                throw new Exception("Lanzando un error simulado");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return View();
        }

        public ActionResult Index2Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            IEnumerable<Producto> model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);
            return PartialView("Index2Resultado", model);
        }

        public ActionResult Index3(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");

            return View();
        }

        public JsonResult Index3Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            IEnumerable<Producto> model = productoService.GetAll(filterByName, filterByCategoria, filterByMarca);

            JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };

            var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, config);
            return Json(model2);
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            ViewBag.UnidadMedida = unidadMedidaService.GetAll("");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model, int iCategoriaID, int iMarcaID, int iUnidadMedidaID)
        {
            model.CategoriaID = iCategoriaID;
            model.MarcaID = iMarcaID;
            model.UnidadMedidaID = iUnidadMedidaID;

            bool result = productoService.Guardar(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Producto model = productoService.GetById(id);

            ViewBag.Categorias = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            ViewBag.UnidadMedida = unidadMedidaService.GetAll("");

            return View("Create", model);
        }

        public ActionResult ConsultaProductosStock()
        {

            return View();
        }

        public JsonResult BuscarProductosStock(ProductoSearchFiltros filtros)
        {
            ListaPaginada<ProductoSearch> model = productoService.BuscarProductosStock(filtros);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}