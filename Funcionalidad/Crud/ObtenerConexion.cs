using System;
using System.Data.SqlClient; 

namespace Connection.Core.Funcionalidad.Crud
{
    public struct ObtenerConexion
    {
        public static SqlConnection Open(string conectionString, bool iniciarTransaccion, out SqlTransaction transaction, out Exception exception)
        {
            transaction = null;
            exception = null;

            SqlConnection conexion = new SqlConnection();
            try
            {
                if (!string.IsNullOrWhiteSpace(conectionString))
                {
                    conexion.ConnectionString = conectionString;
                    conexion.Open();

                    if (iniciarTransaccion)
                        transaction = conexion.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return conexion;
        }
    }
}
