#nullable disable

// Clase principal del programa, inicializa las variables globales y maneja la logica del menu principal con un switch case statement
class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            MostrarMenu();
        }
    }

    private static void MostrarMenu()
    {

        Console.Clear();
        foreach(var item in _menu)
        {
            Console.WriteLine(item.ToString());
        }

        Console.Write("Seleccion > ");

        switch (Console.ReadLine())
        {
            case "1":
                int sucursalesRegistradas = MetodosSucursales.RegistrarSucursales();
                Console.WriteLine($"{sucursalesRegistradas} sucursales registradas en esta operacion, presione cualquier tecla para volver al menu principal");
                Console.ReadKey();
                break;
            case "2":
                int clientesRegistrados = MetodosClientes.RegistrarClientes();
                Console.WriteLine($"{clientesRegistrados} clientes registradas en esta operacion, presione cualquier tecla para volver al menu principal");
                Console.ReadKey();
                break;
            case "3":
                int tipoVehiculoRegistrados = MetodosTipoVehiculo.RegistrarTipoVehiculos();
                Console.WriteLine($"{tipoVehiculoRegistrados} tipos de vehiculos registradas en esta operacion, presione cualquier tecla para volver al menu principal");
                Console.ReadKey();
                break;
            case "4":
                int cantidadTipoVehiculos = MetodosTipoVehiculo.ConsultarCantidadTipoVehiculos();
                if (cantidadTipoVehiculos == 0)
                {
                    Console.WriteLine("Debe registrar al menos un tipo de vehiculo antes de registrar vehiculos, preisone cualquier tecla para continuar");
                    Console.ReadKey();
                    break;
                }     
                int vehiculosRegistrados = MetodosVehiculo.RegistrarVehiculos();
                Console.WriteLine($"{vehiculosRegistrados} vehiculos registradas en esta operacion, presione cualquier tecla para volver al menu principal");
                Console.ReadKey();
                break;
            case "5":
            // WIP
                Console.WriteLine("Metodo no listo aun, digite cualquier tecla para continuar");
                Console.ReadKey();
                break;
            case "6":
                int cantidadSucursales = MetodosSucursales.ConsultarCantidadSucursales();
                if (cantidadSucursales == 0)
                {
                    Console.WriteLine("No hay sucursales registradas, pulse cualquier tecla para volver al menu inicial");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
                MetodosSucursales.ConsultarSucursales();
                Console.WriteLine("Presione cualquier tecla para volver al menu inicial");
                Console.ReadKey();
                break;
            case "7":
                int cantidadClientes = MetodosClientes.ConsultarCantidadClientes();
                if (cantidadClientes == 0)
                {
                    Console.WriteLine("No hay clientes registrados, pulse cualquier tecla para volver al menu inicial");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
                MetodosClientes.ConsultarClientes();
                Console.WriteLine("Presione cualquier tecla para volver al menu inicial");
                Console.ReadKey();
                break;
            case "8":
                cantidadTipoVehiculos = MetodosTipoVehiculo.ConsultarCantidadTipoVehiculos();
                if (cantidadTipoVehiculos == 0)
                {
                    Console.WriteLine("No hay tipos de vehiculos registrados, pulse cualquier tecla para volver al menu inicial");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
                MetodosTipoVehiculo.ConsultarTipoVehiculos();
                Console.WriteLine("Presione cualquier tecla para volver al menu inicial");
                Console.ReadKey();
                break;
            case "9":
                int cantidadVehiculos = MetodosVehiculo.ConsultarCantidadVehiculos();
                if (cantidadVehiculos == 0)
                {
                    Console.WriteLine("No hay vehiculos registrados, pulse cualquier tecla para volver al menu inicial");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
                MetodosVehiculo.ConsultarVehiculos();
                Console.WriteLine("Presione cualquier tecla para volver al menu inicial");
                Console.ReadKey();
                break;
            case "10":
                // WIP
                Console.WriteLine("Metodo no listo aun, digite cualquier tecla para continuar");
                Console.ReadKey();
                break;
            case "11":
                bool salirConfirmacion = SalirConfirmacion();
                if (salirConfirmacion)
                {
                    Environment.Exit(0);
                    break;
                } else
                {
                    break;
                }
            default:
                Console.Clear();
                Console.WriteLine("La opcion introducina no es valida, regresando al menu principal");
                Console.ReadKey();
                break;
        }

    }
    private static bool SalirConfirmacion()
    {
        string salirConfirmacionString;
        Console.Clear();
        Console.Write("Esta seguro de que desea salir? (Y/N): ");

        salirConfirmacionString = Console.ReadLine().ToLower();

        if (salirConfirmacionString is "y")
        {
            return true;
        } else if (salirConfirmacionString is "n")
        {
            return false;
        } else
        {
            Console.WriteLine($"{salirConfirmacionString} no es una opcion valida, regresando al menu principal");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
            return false;
        }
        
        

    }

    private static readonly string[] _menu = {
        "Bienvenido al Menu Principal. Seleccione una opcion para continuar, (ej: 1)",
        "1. Registrar Sucursales",
        "2. Registrar Clientes",
        "3. Registrar Tipo Vehiculo",
        "4. Registrar Vehiculos",
        "5. Registrar Vehiculos por Sucursal",
        "6. Consultar Sucursales",
        "7. Consultar Clientes",
        "8. Consultar Tipo de Vehiculos",
        "9. Consultar Vehiculos",
        "10. Consultar Vehiculos por Sucursal",
        "11. SALIR"
    };

    public static Sucursal[] _sucursales = new Sucursal[20];
    public static Cliente[] _clientes = new Cliente[20];
    public static TipoVehiculo[] _tipoVehiculo = new TipoVehiculo[20];
    // public static VehiculoSucursal[] _vehiculosSucursal = new VehiculoSucursal[20];
    public static Vehiculo[] _vehiculos = new Vehiculo[20];
}
