#nullable disable
// Clase principal de tipo vehiculo, maneja la definicion del objecto tipo vehiculo y los metodos asociados a dicha clase
class TipoVehiculo
{
    private string id;
    private string descripcion;
    private bool estado;

    public TipoVehiculo()
    {}

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

class MetodosTipoVehiculo
{
    private static (bool, int) RevisarEspacioVacioTipoVehiculo()
    {
        for (int i = 0; i < Program._tipoVehiculo.Length; i++)
        {
            if (Program._tipoVehiculo[i] is null)
                return(true, i);
        }

        return(false, -1);
    }

    private static bool revisarTipoVehiculoRepetido(string idTipoVehiculo)
    {
        foreach (TipoVehiculo tipoVehiculo in Program._tipoVehiculo)
        {
            if (tipoVehiculo is not null)
            {
                if (tipoVehiculo.Id == idTipoVehiculo)
                {
                Console.WriteLine($"El id del tipo de vehiculo {idTipoVehiculo} ya existe y no se puede repetir");
                return true;
                }
            }
        }

        return false;
    }

    private static void RegistrarTipoVehiculo(
        int indiceTipoVehiculo,
        string idTipoVehiculo,
        string descripcionTipoVehiculo,
        bool estadoTipoVehiculo)
    {
        TipoVehiculo nuevoTipoVehiculo = new TipoVehiculo();

        nuevoTipoVehiculo.Id = idTipoVehiculo;
        nuevoTipoVehiculo.Estado = estadoTipoVehiculo;
        nuevoTipoVehiculo.Descripcion = descripcionTipoVehiculo;
        Console.WriteLine($"Insertando Tipo de Vehiculo en la posicion {indiceTipoVehiculo}");
        Program._tipoVehiculo[indiceTipoVehiculo] = nuevoTipoVehiculo;
    }

    public static int RegistrarTipoVehiculos()
    {
        string idTipoVehiculo;
        string descripcionTipoVehiculo;
        bool estadoTipoVehiculo;
        string estadoTipoVehiculoString;
        int tipoVehiculoRegistrados = 0;

        registrarTipoVehiculoAdicional:

        string registrarTipoVehiculoAdicionalString = "";

        (bool espacioVacioTipoVehiculo, int indiceTipoVehiculo) = RevisarEspacioVacioTipoVehiculo();

        if (espacioVacioTipoVehiculo)
        {
            idTipoVehiculo = "";
            descripcionTipoVehiculo = "";
            estadoTipoVehiculo = false;
            estadoTipoVehiculoString = "";

            validacionIdTipoVehiculo:
            Console.Write("Introduzca el Id del tipo de vehiculo a registrar: ");
            idTipoVehiculo = Console.ReadLine().ToLower();

            if (idTipoVehiculo is "")
            {
                Console.WriteLine("El ID del tipo de vehiculo no puede estar vacio");
                goto validacionIdTipoVehiculo;
            }
            if (revisarTipoVehiculoRepetido(idTipoVehiculo))
            {
                goto validacionIdTipoVehiculo;
            }

            validacionDescripcionTipoVehiculo:
            Console.Write("Introduzca la descripcion del tipo de vehiculo a registrar: ");
            descripcionTipoVehiculo = Console.ReadLine().ToLower();

            if (descripcionTipoVehiculo is "")
            {
                Console.WriteLine("La descripcion del tipo de vehiculo no puede estar vacia");
                goto validacionDescripcionTipoVehiculo;
            }

            validacionEstadoTipoVehiculo:
            Console.Write("Introduzca el estado del tipo de vehiculo a registrar (activo/inactivo): ");
            estadoTipoVehiculoString = Console.ReadLine().ToLower();

            if (estadoTipoVehiculoString is "activo")
            {
                estadoTipoVehiculo = true;
            } else if (estadoTipoVehiculoString is "inactivo")
            {
                estadoTipoVehiculo = false;
            } else
            {
                Console.WriteLine($"{estadoTipoVehiculoString} no es un valor valido, valores validos: activo, inactivo");
                goto validacionEstadoTipoVehiculo;
            }

            RegistrarTipoVehiculo(
                indiceTipoVehiculo,
                idTipoVehiculo,
                descripcionTipoVehiculo,
                estadoTipoVehiculo
            );
            tipoVehiculoRegistrados++;

            validarRegistrarTipoVehiculoAdicional:
            Console.Write("Desea registrar un tipo de vehiculo adicional? (Y/N): ");
            registrarTipoVehiculoAdicionalString = Console.ReadLine().ToLower();
            if (registrarTipoVehiculoAdicionalString is "y")
            {
                goto registrarTipoVehiculoAdicional;
            } else if (registrarTipoVehiculoAdicionalString is "n")
            {
                Console.WriteLine("Saliendo del menu registrar tipos de vehiculo, presione cualquier tecla para continuar ");
                Console.ReadKey();
                return tipoVehiculoRegistrados;
            } else
            {
                Console.WriteLine($"{registrarTipoVehiculoAdicionalString} no es una opcion valida");
                goto validarRegistrarTipoVehiculoAdicional;
            }
        } else
        {
            Console.WriteLine("No hay mas espacio para registrar tipos de vehiculo, presione cualquier tecla para regresar al menu principal");
            Console.ReadKey();
            return tipoVehiculoRegistrados;          
        }
    }

    public static void ConsultarTipoVehiculos()
    {
        foreach ( TipoVehiculo tipoVehiculo in Program._tipoVehiculo)
        { 
            if (tipoVehiculo is not null)
            {
                Console.WriteLine($"ID: {tipoVehiculo.Id}");
                Console.WriteLine($"Descripcion: {tipoVehiculo.Descripcion}");
                switch (tipoVehiculo.Estado)
                {
                    case false:
                        Console.WriteLine($"Estado: inactivo");
                        break;
                    case true:
                        Console.WriteLine($"Estado: activo");
                        break;
                }
            }
        }
    }

    public static int ConsultarCantidadTipoVehiculos()
    {
        int cantidadTipoVehiculos = 0;
        foreach ( TipoVehiculo tipoVehiculo in Program._tipoVehiculo)
        {
            if (tipoVehiculo is not null)
            {
                cantidadTipoVehiculos++;
            }
        }

        return cantidadTipoVehiculos;
    }
}