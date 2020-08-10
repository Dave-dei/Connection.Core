

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Connection.Core.Funcionalidad.Crud.Tests
{
    [TestClass()]
    public class ObtenerListaGenericaTests
    {
        [TestMethod()]
        public void ConsultarTest()
        {
            var parametros = new List<System.Data.SqlClient.SqlParameter>();
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@FechaInicial", Value = "2020/05/01 00:00:00" });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@FechaFinal", Value = "2020/06/01 00:00:00" });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@UUID", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@EstadoId", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@ProveedorClave", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@EmpresaClave", Value = DBNull.Value });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@IntitucionId", Value = "1" });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@CodigoError", Value = 0, Direction = ParameterDirection.Output });
            parametros.Add(new System.Data.SqlClient.SqlParameter { ParameterName = "@MensajeError", Value = "", Direction = ParameterDirection.Output });

            var resultado = ObtenerListaGenericafromTable.Consultar<Comprobante>(new Data.Entity.ParametroEntity
            {
                connection = "Data Source=localhost;Initial Catalog=SQLTest;Integrated Security=True;Connection Timeout=30000",
                storedprocedure = "ope.pObtenerComprobanteProceso",
                parametros = parametros
            });
            Assert.IsTrue(resultado.Data.Any());
        }
    }
    public class Comprobante
    {
        public string ArchivoId { get; set; }
        public string UUID { get; set; }
        public string Valor { get; set; }
        public string RFCEmisor { get; set; }
        public string RFCReceptor { get; set; }
        public string Importe { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Descrpicion { get; set; }
        public string FechaRecepcion { get; set; }
        public string Ruta { get; set; }
        public string Clave { get; set; }
        public string MensajeError { get; set; }
        public string MetodoPago { get; set; }
        public string FormaPago { get; set; }

        public double Total { get; internal set; }
        public string EstadoDescripcion { get; internal set; }
        public string Estado { get; internal set; }
        public string FechaInsercion { get; internal set; }
        public string FechaTimbrado { get; internal set; }
    }
}