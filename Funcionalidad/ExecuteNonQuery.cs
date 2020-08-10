using Connection.Core.Interfaz;
using Connection.Core.Model;
using System.Data.SqlClient;

namespace Connection.Core.Funcionalidad
{
    internal struct ExecuteNonQuery : IAccionSQL<int>
    {
        public RespuestaSQLModel<int> Exec(SqlCommand cmd,  RespuestaSQLModel<int> respuesta)
        {           
            respuesta.Data = cmd.ExecuteNonQuery();
            return respuesta;
        }
    }
}
