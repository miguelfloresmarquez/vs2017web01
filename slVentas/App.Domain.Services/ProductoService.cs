﻿using App.Data.Repository;
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
            Producto producto;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                producto = UnitOfWork.ProductoRepository.GetById(id);
            }
            return producto;
        }

        public bool Guardar(Producto entidad)
        {
            bool respuesta = false;
            try
            {
                using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
                {
                    if (entidad.ProductoID == 0)
                        UnitOfWork.ProductoRepository.Add(entidad);
                    else
                        UnitOfWork.ProductoRepository.Update(entidad);
                    UnitOfWork.Complete();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
