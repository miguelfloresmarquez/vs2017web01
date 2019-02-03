using App.Data.Repository;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> GetAll(string cadena, int? categoriaID, int? marcaID)
        {
            List<Producto> results;

            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                results = UnitOfWork.ProductoRepository.GetAll(item => item.Nombre.Contains(cadena) && (categoriaID == null || item.CategoriaID == categoriaID) && (marcaID == null || item.MarcaID == marcaID), "Categoria, Marca").ToList();
            }
            return results;
        }

        public Producto GetById(int id)
        {
            Producto producto = new Producto();
            return producto;
        }

        public bool Guardar(Producto entidad)
        {
            bool xRe = true;

            return xRe;
        }
    }
}
