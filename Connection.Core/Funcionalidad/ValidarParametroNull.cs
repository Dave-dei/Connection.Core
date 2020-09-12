using System;
using System.Data.SqlTypes;

namespace Connection.Core.Funcionalidad
{
    public struct ValidarParametroNull
    {
        public static object Validar(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DBNull.Value;

            return value;
        }
        public static object Validar(int? value)
        {
            if (value == 0 || value == null)
                return SqlInt16.Null;

            return value;
        }
        public static object Validar(long? value)
        {
            if (value == 0 || value == null)
                return SqlInt64.Null;

            return value;
        }
        public static object Validar(Guid value)
        {
            if (value == null)
                return SqlGuid.Null;

            return value;
        }
        public static object Validar(bool? value)
        {
            if (value == null)
                return SqlBoolean.Null;

            return value;
        }

        public static object Validar(DateTime? value)
        {
            if (DateTime.MinValue == value || value == null)
                return SqlDateTime.Null;

            return value;
        }
    }
}
