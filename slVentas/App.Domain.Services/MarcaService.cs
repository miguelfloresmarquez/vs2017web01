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
    public class MarcaService : IMarcaService
    {
        public IEnumerable<Marca> GetAll(string cadena)
        {
            List<Marca> listaMarca;
            using (AppUnitOfWork UnitOfWord = new AppUnitOfWork())
            {
                listaMarca = UnitOfWord.MarcaRepository.GetAll(item => item.Nombre.Contains(cadena)).ToList();
            }
            return listaMarca;
        }

        public Marca GetById(int id)
        {
            Marca marca;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                marca = UnitOfWork.MarcaRepository.GetById(id);
            }
            return marca;
        }

        public bool Guardar(Marca entidad)
        {
            bool respuesta = false;
            try
            {
                using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
                {
                    if (entidad.MarcaID == 0)
                        UnitOfWork.MarcaRepository.Add(entidad);
                    else
                        UnitOfWork.MarcaRepository.Update(entidad);
                    UnitOfWork.Complete();
                }
                respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
