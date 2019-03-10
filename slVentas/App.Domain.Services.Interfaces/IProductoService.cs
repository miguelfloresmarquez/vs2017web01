using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll(string cadena, int? categoriaID, int? marcaID);
        bool Guardar(Producto entidad);
        Producto GetById(int id);
        ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros);
    }
}
