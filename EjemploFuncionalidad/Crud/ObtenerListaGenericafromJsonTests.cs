using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Connection.Core.Funcionalidad.Crud.Tests
{
    [TestClass()]
    public class ObtenerListaGenericafromJsonTests
    {
        [TestMethod()]
        public void ConsultarTest()
        {
            var parametros = new List<System.Data.SqlClient.SqlParameter>();
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@FechaInicial", Value = "2020/05/01 00:00:00" });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@FechaFinal", Value = "2020/05/30 00:00:00" });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@UUID", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@EstadoId", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@ProveedorClave", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@EmpresaClave", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@IntitucionId", Value = "1" });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@CodigoError", Value = 0, Direction = ParameterDirection.Output });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@MensajeError", Value = "", Direction = ParameterDirection.Output });

            var resultado = ObtenerListaGenericafromJson.Consultar<Comprobante>(new Data.Entity.ParametroEntity
            {
                connection = "Data Source=localhost;Initial Catalog=SQLTest;Integrated Security=True;Connection Timeout=30000",
                storedprocedure = "ope.pObtenerComprobanteProceso",
                parametros = parametros
            });
            Assert.IsTrue(resultado.Data.Any());
        }
    }
}