using System;
using System.Windows.Forms;

namespace rentaUned
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new rentaUNED());
        }
    }

    class MainArrays
    {
        public static Sucursal[] sucursalArray = new Sucursal[20];
        public static Cliente[] clienteArray = new Cliente[20];
        public static TipoVehiculo[] tipoVehiculoArray = new TipoVehiculo[20];
        public static Vehiculo[] vehiculoArray = new Vehiculo[20];
        public static VehiculoSucursal[] vehiculoSucursalArray = new VehiculoSucursal[20];
        public static Cobertura[] coberturaArray = new Cobertura[20];
    }
}
