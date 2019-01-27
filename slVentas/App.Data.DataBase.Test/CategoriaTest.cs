using System;
using System.Linq;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataBase.Test
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void NuevaCategoria()
        {
            using (AppModel model = new AppModel())
            {
                Categoria categoria = new Categoria()
                {
                    Nombre = "Mouse",
                    Estado = true,
                };

                model.Categoria.Add(categoria);
                model.SaveChanges();    // Es requerido para confirmar la transacción en EF
                Assert.IsTrue(categoria.CategoriaID > 0);   // Verificando que se esté creando la categoria
            }
        }

        [TestMethod]
        public void VerificarRegistros()
        {
            using (AppModel model = new AppModel())
            {
                int cantidad = model.Categoria.Count();
                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
