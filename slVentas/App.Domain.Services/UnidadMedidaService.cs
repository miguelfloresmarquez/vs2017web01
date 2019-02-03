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
    public class UnidadMedidaService : IUnidadMedidaService
    {
        public IEnumerable<UnidadMedida> GetAll(string cadena)
        {
            List<UnidadMedida> listaUnidadMedida;
            using (AppUnitOfWork UnitOfWord = new AppUnitOfWork())
            {
                listaUnidadMedida = UnitOfWord.UnidadMedidaRepository.GetAll(item => item.Nombre.Contains(cadena)).ToList();
            }
            return listaUnidadMedida;
        }

        public UnidadMedida GetById(int id)
        {
            UnidadMedida unidadMedida;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                unidadMedida = UnitOfWork.UnidadMedidaRepository.GetById(id);
            }
            return unidadMedida;
        }

        public bool Guardar(UnidadMedida entidad)
        {
            bool respuesta = false;
            try
            {
                using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
                {
                    if (entidad.UnidadMedidaID == 0)
                        UnitOfWork.UnidadMedidaRepository.Add(entidad);
                    else
                        UnitOfWork.UnidadMedidaRepository.Update(entidad);
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
