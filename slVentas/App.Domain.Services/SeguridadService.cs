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
