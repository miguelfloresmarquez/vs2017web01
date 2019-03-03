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
    public class ComentarioService : IComentarioService
    {
        public IEnumerable<Comentario> GetAll()
        {
            IEnumerable<Comentario> results;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                results = UnitOfWork.ComentarioRepository.GetAll().ToList();
            }
            return results;
        }

        public void Guardar(Comentario entity)
        {
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                UnitOfWork.ComentarioRepository.Add(entity);
                UnitOfWork.Complete();
            }
        }
    }
}
