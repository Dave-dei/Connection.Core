using Connection.Core.Data.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Connection.Core.Funcionalidad
{
    public struct ObtenerParametrosOutput
    {
        public static List<ParametroOutputEntity> Buscar(SqlParameterCollection Parameters)
        {
            List<ParametroOutputEntity> parametrosoutput = new List<ParametroOutputEntity>();

            if (Parameters?.Count > 0)
            {
                parametrosoutput.AddRange(from SqlParameter item in Parameters
                                          where item.Direction == ParameterDirection.InputOutput || item.Direction == ParameterDirection.Output
                                          select new ParametroOutputEntity(item.ParameterName, item.Value));
            }

            return parametrosoutput;
        }
    }
}
