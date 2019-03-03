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
    public class SeguridadService : ISeguridadService
    {
        public IEnumerable<Usuario> GetAll(string nombre)
        {
            IEnumerable<Usuario> results;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                results = UnitOfWork.UsuarioRepository.GetAll(item => string.Concat(item.Nombres, " ",item.Apellidos).Contains(nombre)).ToList();
            }
            return results;
        }

        public Usuario VerificarUsuario(string login, string password)
        {
            Usuario results;
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork())
            {
                results = UnitOfWork.UsuarioRepository.GetAll(item => item.Login == login && item.Password == password).SingleOrDefault();
            }
            return results;
        }

    }
}
