using System;

namespace rentaUned
{
    public class VehiculoSucursal
    {
        private int id;
        private DateTime fecha;
        private Sucursal sucursal;
        private Vehiculo[] vehiculos = new Vehiculo[10];

        public VehiculoSucursal()
        { }

        public VehiculoSucursal(
            int id,
            DateTime fecha,
            Sucursal sucursal,
            Vehiculo[] vehiculos)
        {
            this.id = id;
            this.fecha = fecha;
            this.sucursal = sucursal;
            this.vehiculos = vehiculos;
        }

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }

        public Sucursal Sucursal
        {
            set { sucursal = value; }
            get { return sucursal; }
        }

        public Vehiculo[] Vehiculos
        {
            private set { ; }
            get { return vehiculos; }
        }

        public void AddVehiculo(Vehiculo vehiculo)
        {
            for (int i = 0; i < this.Vehiculos.Length; i++)
            {
                if (this.Vehiculos[i] == null)
                {
                    this.Vehiculos[i] = vehiculo;
                    break;
                }
            }
        }

        public int CheckEmptyVehiculos()
        {
            int count = 0;
            for (int i = 0; i < this.Vehiculos.Length; i++)
            {
                if (this.Vehiculos[i] == null)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetNextEmptyVehiculos()
        {
            for (int i = 0; i < this.Vehiculos.Length; i++)
            {
                if (this.Vehiculos[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
