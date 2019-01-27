using System;
using App.Data.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class CategoriaRepositoryTest
    {
        [TestMethod]
        public void ExistenRegistros()
        {
            AppModel model = new AppModel();
            using (AppUnitOfWork UnitOfWork = new AppUnitOfWork(model))
            {
                int cantidad = UnitOfWork.CategoriaRepository.Count();
                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
