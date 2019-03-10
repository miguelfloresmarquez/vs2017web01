using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositoy.Interfaces
{
    public interface IProductoRepository:IGenericRepository<Producto>
    {
        ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros);
    }
}
