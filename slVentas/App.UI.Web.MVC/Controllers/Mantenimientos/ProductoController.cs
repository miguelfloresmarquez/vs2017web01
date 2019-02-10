using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    [LoggingFilter]
    [HandleCustomError]
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        private readonly IMarcaService marcaService;
        private readonly IUnidadMedidaService unidadMedidaService;

        public ProductoController()
        {
            productoService = new ProductoService();
            categoriaService = new CategoriaService();
            marcaService = new MarcaService();
            unidadMedidaService = new UnidadMedidaService();
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
        public ActionResult Create(Producto model, int CategoriaID, int MarcaID, int UnidadMedidaID)
        {
            model.CategoriaID = CategoriaID;
            model.MarcaID = MarcaID;
            model.UnidadMedidaID = UnidadMedidaID;

            bool result = productoService.Guardar(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Producto model = productoService.GetById(id);

            ViewBag.CategoriaID = categoriaService.GetAll("");
            ViewBag.Marcas = marcaService.GetAll("");
            ViewBag.UnidadMedida = unidadMedidaService.GetAll("");

            return View("Create", model);
        }
    }
}