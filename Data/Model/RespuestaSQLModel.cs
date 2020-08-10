using Connection.Core.Data.Entity;
using System;
using System.Collections.Generic; 

namespace Connection.Core.Model
{
    public class RespuestaSQLModel<T>
    {
        public Exception Exception { get; set; }
        public List<ParametroOutputEntity> parametrosOut;
        public T Data;

        public RespuestaSQLModel()
        {
            parametrosOut = new List<ParametroOutputEntity>();
        }
    }
}
