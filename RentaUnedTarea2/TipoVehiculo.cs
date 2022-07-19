namespace rentaUned
{
    public class TipoVehiculo
    {
        private string id;
        private string descripcion;
        private bool estado;

        public TipoVehiculo()
        { }

        public TipoVehiculo(
            string id,
            string descripcion,
            bool estado
            )
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public string Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public bool Estado
        {
            set { estado = value; }
            get { return estado; }
        }
    }
}
