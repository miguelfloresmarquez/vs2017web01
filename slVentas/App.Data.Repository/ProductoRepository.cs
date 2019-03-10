using App.Data.Repositoy.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(DbContext Context) : base(Context)
        {
        }

        public ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros)
        {
            var result = new ListaPaginada<ProductoSearch>();
            filtros.Nombre = filtros.Nombre ?? "";
            // Para la paginación es necesario que se indique el ordenamiento
            // con orderby
            var query = from a in context.Set<Categoria>()
                        join b in context.Set<Producto>()
                        on a.CategoriaID equals b.CategoriaID
                        join c in context.Set<Marca>()
                        on b.MarcaID equals c.MarcaID
                        where b.Nombre.Contains(filtros.Nombre)
                        && b.StockActual>filtros.Stock
                        orderby a.Nombre
                        select new ProductoSearch()
                        {
                            ProductoID = b.ProductoID,
                            Nombre = b.Nombre,
                            CategoriaName = a.Nombre,
                            PrecioMayor = b.PrecioMayor,
                            PrecioMenor = b.PrecioMenor,
                            StockActual = b.StockActual,
                            ProductoCode = b.ProductoCode,
                            MarcaName = c.Nombre
                        };
            // Primero se obtiene la cantidad total de registros
            result.TotalRows = query.Count();
            // Finalmente se pagina en el servido
            // se toma el primer registro de la pagina seleccionada
            query = query.Skip(filtros.PageSize * (filtros.PageIndex - 1));
            //se toma los registros restantes según el tamaño de pagina
            query = query.Take(filtros.PageSize);
            result.Listado = query.ToList();
            return result;
        }
    }
}