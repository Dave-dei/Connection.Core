using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connection.Core.Funcionalidad.Crud.Tests
{
    [TestClass()]
    public class ObtenerDataSetTests
    {
        [TestMethod()]
        public void ConsultarTest()
        {
            var resultado = ObtenerDataSet.Consultar(new Data.Entity.ParametroEntity
            {
                connection = "Data Source=localhost;Initial Catalog=SQLTest;Integrated Security=True;Connection Timeout=30000",
                storedprocedure = "ope.pNombre"
            });

            Assert.IsTrue(resultado.Data.Tables.Count > 0);
        }
    }
}