using Connection.Core.Data.Entity;
using Connection.Core.Model;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Connection.Core.Funcionalidad.Crud
{
    public struct ObtenerListaGenericafromJson
    {
        public static RespuestaSQLModel<List<T>> Consultar<T>(ParametroEntity parametro)
        {
            RespuestaSQLModel<List<T>> respuesta = new RespuestaSQLModel<List<T>>();
            try
            {
                StringBuilder json = new StringBuilder();
                using (SqlConnection cn = new SqlConnection(parametro.connection))
                {
                    cn.Open();

                    SqlCommand cmd;

                    ConfigurarCommandSQL.Configurar(cn, parametro.storedprocedure, parametro.parametros, out cmd, parametro.timeout);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        json.Append(reader[0]);
                    }
                    respuesta.parametrosOut = ObtenerParametrosOutput.Buscar(cmd.Parameters);
                }

                if (!string.IsNullOrWhiteSpace(json.ToString()))
                    respuesta.Data = JsonConvert.DeserializeObject<List<T>>(json.ToString(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                else
                    respuesta.Data = new List<T>();

            }
            catch (System.Exception ex)
            {
                respuesta.Data = new List<T>();
                respuesta.Exception = ex;
            }

            return respuesta;
        }


    }
}
