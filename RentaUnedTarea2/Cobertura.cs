namespace rentaUned
{
    public class Cobertura
    {
        private string id;
        private string descripcion;
        private TipoVehiculo tipoVehiculo;
        private bool estado;
        private int monto;
        public Cobertura()
        { }
        public Cobertura(string id, string descripcion, TipoVehiculo tipoVehiculo, bool estado, int monto)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.tipoVehiculo = tipoVehiculo;
            this.estado = estado;
            this.monto = monto;
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

        public TipoVehiculo TipoVehiculo
        {
            set { tipoVehiculo = value; }
            get { return tipoVehiculo; }
        }

        public bool Estado
        {
            set { estado = value; }
            get { return estado; }
        }

        public int Monto
        {
            set { monto = value; }
            get { return monto; }
        }
    }
}
