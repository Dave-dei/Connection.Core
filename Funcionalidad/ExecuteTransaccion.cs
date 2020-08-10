using Connection.Core.Model;

using System.Collections.Generic;
using System.Data.SqlClient; 

namespace Connection.Core.Funcionalidad
{
    public struct ExecuteTransaccion
    {
        public static bool Exec(SqlCommand cmd, List<SqlParameter> parametros, out RespuestaSQLModel<int> respuesta, string CommandText = "")
        {
            respuesta = new RespuestaSQLModel<int>();

            try
            {
                cmd.CommandText = string.IsNullOrWhiteSpace(CommandText) ? cmd.CommandText : CommandText;

                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parametros.ToArray());
                respuesta.Data = cmd.ExecuteNonQuery();

                respuesta.parametrosOut = ObtenerParametrosOutput.Buscar(cmd.Parameters);
                parametros.Clear();
            }
            catch (System.Exception ex)
            {
                respuesta.Exception = ex;
                return false;
            }

            return true;
        }
    }
}
