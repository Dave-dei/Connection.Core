using Connection.Core.Model;
using System.Data.SqlClient;

namespace Connection.Core.Interfaz
{
    internal interface IAccionSQL<T>
    {
        RespuestaSQLModel<T> Exec(SqlCommand cmd, RespuestaSQLModel<T> respuesta);
    }
}
