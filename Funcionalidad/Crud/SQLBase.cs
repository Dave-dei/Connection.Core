using Connection.Core.Interfaz;
using Connection.Core.Model;
 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Connection.Core.Funcionalidad.Crud
{
    internal struct SQLBase
    {
        public int timeout;
        public string connection, storedprocedure;
        public List<SqlParameter> parametros;

        public SQLBase(string connection, string storedprocedure, List<SqlParameter> parametros, int timeout = 0)
        {
            this.connection = connection;
            this.storedprocedure = storedprocedure;
            this.parametros = parametros;
            this.timeout = timeout;
        }


        internal RespuestaSQLModel<T> Execute<T>(IAccionSQL<T> metodo) where T : new()
        {
            RespuestaSQLModel<T> respuesta = new RespuestaSQLModel<T>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(connection))
                {
                    conexion.Open();
                    ConfigurarCommandSQL.Configurar(conexion, storedprocedure, parametros, out SqlCommand cmd, timeout);

                    respuesta = metodo.Exec(cmd, respuesta);
                    respuesta.parametrosOut = ObtenerParametrosOutput.Buscar(cmd.Parameters);
                }
            }
            catch (Exception ex)
            {
                respuesta.Exception = ex;
            }

            return respuesta;

        }

    }
}
