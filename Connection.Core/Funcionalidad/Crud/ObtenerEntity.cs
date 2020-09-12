using Connection.Core.Data.Entity;
using Connection.Core.Model;

using System.Collections.Generic;
using System.Linq;

namespace Connection.Core.Funcionalidad.Crud
{
    public struct ObtenerEntity<T>
    {
        public static RespuestaSQLModel<T> Mapear(ParametroEntity parametro,  bool fromjson = false)
        {
            RespuestaSQLModel<T> model = new RespuestaSQLModel<T>();

            RespuestaSQLModel<List<T>> lista = new RespuestaSQLModel<List<T>>();
            lista =  fromjson ? ObtenerListaGenericafromJson.Consultar<T>(parametro) : ObtenerListaGenericafromTable.Consultar<T>(parametro);

            if (lista?.Data.Any() == true)
                model.Data = lista.Data.FirstOrDefault();

            return model;

        }
    }
}
