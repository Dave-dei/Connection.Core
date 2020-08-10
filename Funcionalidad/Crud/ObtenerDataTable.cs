using Connection.Core.Data.Entity;
using Connection.Core.Model;
using System.Data;

namespace Connection.Core.Funcionalidad.Crud
{
    public struct ObtenerDataTable
    {
        public static RespuestaSQLModel<DataTable> Consultar(ParametroEntity parametro)
        {
            return new SQLBase(parametro.connection, parametro.storedprocedure, parametro.parametros, parametro.timeout).Execute(new ExecuteReadertoTable());
        }
    }
}
