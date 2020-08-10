using Connection.Core.Data.Entity;
using Connection.Core.Model;
 
namespace Connection.Core.Funcionalidad.Crud
{
    public struct ActualizarEntity
    {
        public static RespuestaSQLModel<int> Guardar(ParametroEntity parametro)
        {
            return new SQLBase(parametro.connection, parametro.storedprocedure, parametro.parametros, parametro.timeout).Execute(new ExecuteNonQuery());
        }
    }
}
