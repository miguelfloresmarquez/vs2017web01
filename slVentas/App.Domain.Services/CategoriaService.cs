using App.Data.Repository;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        public IEnumerable<Categoria> GetAll(string nombre)
        {
            List<Categoria> results;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                results = UnitOfWork.CategoriaRepository.GetAll(item => item.Nombre.Contains(nombre)).ToList();
            }
            return results;
        }

        public Categoria GetById(int id)
        {
            Categoria categoria;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                categoria = UnitOfWork.CategoriaRepository.GetById(id);
            }
            return categoria;
        }

        public bool Guardar(Categoria entidad)
        {
            bool result = false;
            try
            {
                using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
                {
                    if (entidad.CategoriaID == 0) //Cuando es nuevo registro
                        UnitOfWork.CategoriaRepository.Add(entidad);
                    else
                        UnitOfWork.CategoriaRepository.Update(entidad);
                    UnitOfWork.Complete();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
