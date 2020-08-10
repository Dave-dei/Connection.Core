namespace Connection.Core.Data.Entity 
{
    public struct ParametroOutputEntity
    {
        public string Nombre { get; set; }
        public object Value { get; set; }

        public ParametroOutputEntity(string Nombre, object Value)
        {
            this.Nombre = Nombre;
            this.Value = Value;
        }
    }
}
