using Connection.Core.Data.Entity;
using Connection.Core.Model;

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Connection.Core.Funcionalidad.Crud
{
    public struct ObtenerListaGenericafromTable
    {
        public static RespuestaSQLModel<List<T>> Consultar<T>(ParametroEntity parametro)
        {
            RespuestaSQLModel<List<T>> respuesta = new RespuestaSQLModel<List<T>>();
            try
            {
                var consulta = new SQLBase(parametro.connection, parametro.storedprocedure, parametro.parametros, parametro.timeout).Execute(new ExecuteReadertoTable());

                respuesta.Exception = consulta.Exception;
                respuesta.parametrosOut = consulta.parametrosOut;

                if (consulta.Data != null)
                {
                    string consultaJson = JsonConvert.SerializeObject(consulta.Data);
                    respuesta.Data = JsonConvert.DeserializeObject<List<T>>(consultaJson, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                }
                else
                    respuesta.Data = new List<T>();
            }
            catch (System.Exception ex)
            {
                respuesta.Data = new List<T>();
                respuesta.Exception = ex;
            }

            return respuesta;
        }
    }
}
