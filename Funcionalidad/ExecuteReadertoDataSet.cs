using Connection.Core.Interfaz;
using Connection.Core.Model;
using System.Data;
using System.Data.SqlClient; 

namespace Connection.Core.Funcionalidad
{
    internal struct ExecuteReadertoDataSet : IAccionSQL<DataSet>
    {
        public RespuestaSQLModel<DataSet> Exec(SqlCommand cmd, RespuestaSQLModel<DataSet> respuesta)
        {
            respuesta.Data = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(respuesta.Data);
                        
            return respuesta;
        }        
    }
}
