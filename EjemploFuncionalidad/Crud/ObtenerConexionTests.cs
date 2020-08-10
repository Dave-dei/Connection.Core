using Connection.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Connection.Core.Funcionalidad.Crud.Tests
{
    [TestClass()]
    public class ObtenerConexionTests
    {
        [TestMethod()] 
        public void OpenTest()
        {
            Exception errortrans;
            try
            {
                using (var conexion = ObtenerConexion.Open("Data Source=localhost;Initial Catalog=SQLTest;Integrated Security=True;Connection Timeout=30000", true, out SqlTransaction transaction, out Exception error))
                {
                    errortrans = error;
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        List<SqlParameter> parametros = new List<SqlParameter>();
                        parametros.Add(new SqlParameter { ParameterName = "@DiaInhabil", Value = "20191218,20191001,20200611" });
                        parametros.Add(new SqlParameter { ParameterName = "@Anio", Value = 2020 });
                        parametros.Add(new SqlParameter { ParameterName = "@ErrorId", Value = 0, Direction = System.Data.ParameterDirection.Output });
                        parametros.Add(new SqlParameter { ParameterName = "@ErrorDescripcion", Value = "", Direction = System.Data.ParameterDirection.Output, Size = 200 });


                        ConfigurarCommandSQL.Configurar(conexion, "adm.pActualizarCalendario", parametros, out SqlCommand cmd, 0, transaction);
                        RespuestaSQLModel<int> respuesta;

                        if (ExecuteTransaccion.Exec(cmd, parametros, out respuesta))
                        {
                            parametros.Add(new SqlParameter { ParameterName = "@CatalogoComunId", Value = 0 });
                            parametros.Add(new SqlParameter { ParameterName = "@Tabla", Value = "TEST" });
                            parametros.Add(new SqlParameter { ParameterName = "@Valor", Value = "transaccion" });
                            parametros.Add(new SqlParameter { ParameterName = "@Descripcion", Value = "datos de prueba transaccion" });
                                       parametros.Add(new SqlParameter { ParameterName = "@ErrorId", Value = 0, Direction = System.Data.ParameterDirection.Output });
                            parametros.Add(new SqlParameter { ParameterName = "@ErrorDescripcion", Value = "", Direction = System.Data.ParameterDirection.Output });

                            if (ExecuteTransaccion.Exec(cmd, parametros, out respuesta, "adm.pActualizarCatalogoComun"))
                            {
                                parametros.Add(new SqlParameter { ParameterName = "@CatalogoComunId", Value = 0 });
                                parametros.Add(new SqlParameter { ParameterName = "@Tabla", Value = "TEST" });
                                parametros.Add(new SqlParameter { ParameterName = "@Valor", Value = "transaccion2" });
                                parametros.Add(new SqlParameter { ParameterName = "@Descripcion", Value = "datos de prueba transaccion" });
                                parametros.Add(new SqlParameter { ParameterName = "@ErrorId", Value = 0, Direction = System.Data.ParameterDirection.Output });
                                parametros.Add(new SqlParameter { ParameterName = "@ErrorDescripcion", Value = "", Direction = System.Data.ParameterDirection.Output });

                                ExecuteTransaccion.Exec(cmd, parametros, out respuesta, "adm.pActualizarCatalogoComun");
                            }
                        }

                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                errortrans = ex;
            }

            Assert.IsTrue(errortrans != null);
        }
    }
}