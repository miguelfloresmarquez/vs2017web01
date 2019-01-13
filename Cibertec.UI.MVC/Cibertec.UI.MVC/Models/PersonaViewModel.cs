using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.UI.MVC.Models
{
    public class PersonaViewModel
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string FullName { get; set; }
    }
}