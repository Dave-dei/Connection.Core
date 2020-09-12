using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Connection.Core.Funcionalidad.Crud.Tests
{
    [TestClass()]
    public class RegistrarEntityTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            var parametros = new List<System.Data.SqlClient.SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@UUID", Value = Guid.NewGuid(), SqlDbType = SqlDbType.UniqueIdentifier });
 
            parametros.Add(new SqlParameter { ParameterName = "@Certificado", Value = "20001000000300022767" });
            parametros.Add(new SqlParameter { ParameterName = "@FechaEmision", Value = DateTime.Now, SqlDbType = SqlDbType.DateTime });
            parametros.Add(new SqlParameter { ParameterName = "@Fecha", Value = DateTime.Now, SqlDbType = SqlDbType.DateTime });
            parametros.Add(new SqlParameter { ParameterName = "@UnidadNegocio", Value = "AP903" });
 
            parametros.Add(new SqlParameter { ParameterName = "@ErrorId", Value = 0, Direction = ParameterDirection.Output });
            parametros.Add(new SqlParameter { ParameterName = "@ErrorDescripcion", Value = "", Direction = ParameterDirection.Output });

            var registro = RegistrarEntity.Guardar(new Data.Entity.ParametroEntity
            {
                connection = "Data Source=localhost;Initial Catalog=SQLTest;Integrated Security=True;Connection Timeout=30000",
                storedprocedure = "ope.pAgregarComprobante",
                parametros = parametros
            });

            Assert.IsTrue(registro.Data == 1);
        }
    }
}