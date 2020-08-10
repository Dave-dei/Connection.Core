using Connection.Core.Interfaz;
using Connection.Core.Model;
using System.Data;
using System.Data.SqlClient; 

namespace Connection.Core.Funcionalidad
{
    internal struct ExecuteReadertoTable : IAccionSQL<DataTable>
    {
        public RespuestaSQLModel<DataTable> Exec(SqlCommand cmd, RespuestaSQLModel<DataTable> respuesta)
        {
            respuesta.Data = new DataTable();
            SqlDataReader Datos = cmd.ExecuteReader();
            respuesta.Data.Load(Datos);

            return respuesta;
        }
    }
}
