using System.Collections.Generic;
using System.Data.SqlClient;

namespace Connection.Core.Data.Entity
{
    public struct ParametroEntity
    {
        public string connection, storedprocedure;
        public List<SqlParameter> parametros;
        public int timeout;

        public ParametroEntity(string connection, string storedprocedure, List<SqlParameter> parametros, int timeout = 0)
        {
            this.connection = connection;
            this.storedprocedure = storedprocedure;
            this.parametros = parametros;
            this.timeout = timeout;
        }
    }
}
