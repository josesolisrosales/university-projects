#nullable disable
// Clase principal de sucursal, maneja la definicion del objecto sucursal y los metodos asociados a dicha clase
class Sucursal
{
    private int id;
    private string nombre;
    private string direccion;
    private bool estado;
    private string telefono;
    private int[] vehiculosAsignados;

    public Sucursal()
    {}
    public Sucursal(int id, string nombre, string direccion, bool estado, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.estado = estado;
        this.telefono = telefono;
    }

    public int Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Nombre
    {
        set { nombre = value; }
        get { return nombre; }
    }

    public string Direccion
    {
        set { direccion = value; }
        get { return direccion; }
    }

    public bool Estado
    {
        set { estado = value; }
        get { return estado; }
    }

    public string Telefono
    {
        set { telefono = value; }
        get { return telefono; }
    }
}

class MetodosSucursales
{
    private static (bool, int) RevisarEspacioVacioSucursales()
    {
        for (int i = 0; i < Program._sucursales.Length; i++)
        {
            if (Program._sucursales[i] is null)
                return(true, i);
        }

        return(false, -1);
    }

    private static bool revisarSucursalesRepetidas(int idSucursal)
    {
        foreach (Sucursal sucursal in Program._sucursales)
        {
            if (sucursal is not null)
            {
                if (sucursal.Id == idSucursal)
                {
                Console.WriteLine($"El id de la sucural {idSucursal} ya existe y no se puede repetir");
                return true;
                }
            }
        }

        return false;
    }

    private static void RegistrarSucursal(
        int indiceSucursal,
        string nombreSucursal,
        string direccionSucursal,
        string telefonoSucursal,
        int idSucursal,
        bool estadoSucursal)
    {
        Sucursal nuevaSucursal = new Sucursal();

        nuevaSucursal.Nombre = nombreSucursal;
        nuevaSucursal.Direccion = direccionSucursal;
        nuevaSucursal.Estado = estadoSucursal;
        nuevaSucursal.Telefono = telefonoSucursal;
        nuevaSucursal.Id = idSucursal;
        Console.WriteLine($"Insertando Sucursal en la posicion {indiceSucursal}");
        Program._sucursales[indiceSucursal] = nuevaSucursal;
    }

    public static int RegistrarSucursales()
    {
        string nombreSucursal;
        string telefonoSucursal;
        string direccionSucursal;
        int idSucursal;
        bool estadoSucursal;
        string idSucursalString;
        string estadoSucursalString;
        int sucursalesRegistradas = 0;
        
        registrarSucursalAdicional:

        string registrarSucursalAdicionalString = "";

        (bool espacioVacioSucursal, int indiceSucursal) = RevisarEspacioVacioSucursales();

        if (espacioVacioSucursal)
        {
            nombreSucursal = "";
            telefonoSucursal = "";
            direccionSucursal = "";
            idSucursal = 0;
            estadoSucursal = false;
            idSucursalString = "";
            estadoSucursalString = "";

            validacionNombreSucursal:
            Console.Write("Introduzca el nombre de la sucursal a registrar: ");
            nombreSucursal = Console.ReadLine().ToLower();
            
            if (nombreSucursal is "")
            {
                Console.WriteLine("El nombre de la sucursal no puede estar vacio");
                goto validacionNombreSucursal;
            }

            validacionDireccionSucursal:
            Console.Write("Introduzca la direccion de la sucursal a registrar: ");
            direccionSucursal = Console.ReadLine().ToLower();

            if (direccionSucursal is "")
            {
                Console.WriteLine("La direccion de la sucursal no puede estar vacio");
                goto validacionDireccionSucursal;
            }

            validacionTelefonoSucursal:
            Console.Write("Introduzca el telefono de la sucursal a registrar: ");
            telefonoSucursal = Console.ReadLine().ToLower();

            if (telefonoSucursal is "")
            {
                Console.WriteLine("El telefono de la sucursal no puede estar vacio");
                goto validacionTelefonoSucursal;
            }

            validacionIdSucursal:
            Console.Write("Introduzca el ID de la Sucursal a registrar: ");
            idSucursalString = Console.ReadLine();

            if(!Int32.TryParse(idSucursalString, out idSucursal))
            {
                Console.WriteLine($"{idSucursalString} no es un entero valido");
                goto validacionIdSucursal;
            } else
            {
                Int32.TryParse(idSucursalString, out idSucursal);
                if (idSucursal is 0)
                {
                    Console.WriteLine("El ID de la sucursal no puede ser 0");
                    goto validacionIdSucursal;
                } else
                {
                    if (revisarSucursalesRepetidas(idSucursal))
                    {
                        goto validacionIdSucursal;
                    }
                }
            }

            validacionEstadoSucursal:
            Console.Write("Introduzca el estado de la Sucursal a registrar (activa/inactiva): ");
            estadoSucursalString = Console.ReadLine().ToLower();

            if (estadoSucursalString is "activa")
            {
                estadoSucursal = true;
            } else if (estadoSucursalString is "inactiva")
            {
                estadoSucursal = false;
            } else
            {
                Console.WriteLine($"{estadoSucursalString} no es un valor valido, valores validos: activa, inactiva");
                goto validacionEstadoSucursal;
            }

            RegistrarSucursal(
                indiceSucursal,
                nombreSucursal,
                direccionSucursal,
                telefonoSucursal,
                idSucursal,
                estadoSucursal
            );
            sucursalesRegistradas++;

            validarRegistrarSucursalAdicional:
            Console.Write("Desea registrar una sucursal adicional? (Y/N): ");
            registrarSucursalAdicionalString = Console.ReadLine().ToLower();
            if (registrarSucursalAdicionalString is "y")
            {
                goto registrarSucursalAdicional;
            } else if (registrarSucursalAdicionalString is "n")
            {
                Console.WriteLine("Saliendo del menu registrar sucursales, presione cualquier tecla para continuar ");
                Console.ReadKey();
                return sucursalesRegistradas;
            } else
            {
                Console.WriteLine($"{registrarSucursalAdicionalString} no es una opcion valida");
                goto validarRegistrarSucursalAdicional;
            }
        } else
        {
            Console.WriteLine("No hay mas espacio para registrar sucursales, presione cualquier tecla para regresar al menu principal");
            Console.ReadKey();
            return sucursalesRegistradas;
        }
    }
    public static void ConsultarSucursales()
    {
        foreach ( Sucursal sucursal in Program._sucursales)
        { 
            if (sucursal is not null)
            {
                Console.WriteLine($"ID: {sucursal.Id}");
                Console.WriteLine($"Nombre: {sucursal.Nombre}");
                Console.WriteLine($"Direccion: {sucursal.Direccion}");
                switch (sucursal.Estado)
                {
                    case false:
                        Console.WriteLine($"Estado: inactiva");
                        break;
                    case true:
                        Console.WriteLine($"Estado: activa");
                        break;
                }
                Console.WriteLine($"Telefono: {sucursal.Telefono}");
                Console.WriteLine("");
            }
        }
    }

    public static void ConsultarSucursalesActivas()
    {
        foreach ( Sucursal sucursal in Program._sucursales)
        { 
            if (sucursal is not null)
            {
                if (sucursal.Estado is not false)
                {
                    Console.WriteLine($"ID: {sucursal.Id}");
                    Console.WriteLine($"Nombre: {sucursal.Nombre}");
                    Console.WriteLine($"Direccion: {sucursal.Direccion}");
                    Console.WriteLine("");
                }
            }
        }
    }

    public static int ConsultarCantidadSucursales()
    {
        int cantidadSucursales = 0;
        foreach ( Sucursal sucursal in Program._sucursales)
        {
            if (sucursal is not null)
            {
                cantidadSucursales++;
            }
        }

        return cantidadSucursales;
    }
}