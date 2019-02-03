using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IMarcaService
    {
        IEnumerable<Marca> GetAll(string cadena);
        bool Guardar(Marca entidad);
        Marca GetById(int id);
    }
}
