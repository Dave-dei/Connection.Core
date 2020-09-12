using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Connection.Core.Funcionalidad
{
    public struct ConfigurarCommandSQL
    {
        public static void Configurar(SqlConnection conexion, string storedprocedure, List<SqlParameter> parametros, out SqlCommand cmd, int timeout = 0, SqlTransaction transaction = null)
        {
            cmd = transaction != null ? new SqlCommand(storedprocedure, conexion, transaction) : new SqlCommand(storedprocedure, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            if (conexion.ConnectionTimeout > 0)
                cmd.CommandTimeout = conexion.ConnectionTimeout;

            else if (timeout > 0)
                cmd.CommandTimeout = timeout;

            if (parametros?.Any() == true)
                cmd.Parameters.AddRange(parametros.ToArray());
        }

    }
}
