#nullable disable
class Vehiculo
{
    private string id;
    private string marca;
    private string modelo;
    private TipoVehiculo tipo;
    private int alquilerDiario;
    private int km;

    public Vehiculo()
    {}

    public Vehiculo(
        string id, 
        string marca, 
        string modelo,
        TipoVehiculo tipo,
        int alquilerDiario,
        int km
        )
    {
        this.id = id;
        this.marca = marca;
        this.modelo = modelo;
        this.tipo = tipo;
        this.alquilerDiario = alquilerDiario;
        this.km = km;
    }

    public string Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Marca
    {
        set { marca = value; }
        get { return marca; }
    }

    public string Modelo
    {
        set { modelo = value; }
        get { return modelo; }
    }

    public TipoVehiculo Tipo 
    {
        set { tipo = value; }
        get { return tipo; }
    }

    public int AlquilerDiario
    {
        set { alquilerDiario = value; }
        get { return alquilerDiario; }
    }

    public int Km
    {
        set { km = value; }
        get { return km; }
    }
}

class MetodosVehiculo
{
    private static (bool, int) RevisarEspacioVacioVehiculos()
    {
        for (int i = 0; i < Program._vehiculos.Length; i++)
        {
            if (Program._vehiculos[i] is null)
                return(true, i);
        }

        return(false, -1);
    }

    private static bool revisarVehiculosRepetidos(string idVehiculo)
    {
        foreach (Vehiculo vehiculo in Program._vehiculos)
        {
            if (vehiculo is not null)
            {
                if (vehiculo.Id == idVehiculo)
                {
                    Console.WriteLine($"El id del vehiculo {idVehiculo} ya existe y no se puede repetir");
                    return true;
                }
            }
        }

        return false;
    }

    private static void RegistrarVehiculo(
        int indiceVehiculo,
        string idVehiculo,
        string marcaVehiculo,
        string modeloVehiculo,
        TipoVehiculo tipoVehiculo,
        int alquilerDiarioVehiculo,
        int kmVehiculo)
    {
        Vehiculo nuevoVehiculo = new Vehiculo();

        nuevoVehiculo.Id = idVehiculo;
        nuevoVehiculo.Marca = marcaVehiculo;
        nuevoVehiculo.Modelo = modeloVehiculo;
        nuevoVehiculo.Tipo = tipoVehiculo;
        nuevoVehiculo.AlquilerDiario = alquilerDiarioVehiculo;
        nuevoVehiculo.Km = kmVehiculo;

        Console.WriteLine($"Insertando vehiculo en la posicion {indiceVehiculo}");
        Program._vehiculos[indiceVehiculo] = nuevoVehiculo;
    }

    private static void MostrarSeleccionTipoVehiculo()
    {
        for (int i = 0; i < Program._vehiculos.Length; i++)
        {
            if (Program._tipoVehiculo[i] is not null)
            {
                Console.WriteLine($"Opcion {i+1}");
                Console.WriteLine($"ID: {Program._tipoVehiculo[i].Id}");
                Console.WriteLine($"Descripcion: {Program._tipoVehiculo[i].Descripcion}");
            }
        }
    }


    public static int RegistrarVehiculos()
    {
        string idVehiculo;
        string marcaVehiculo;
        string modeloVehiculo;
        TipoVehiculo tipoVehiculo;
        string tipoVehiculoOpcionString;
        int tipoVehiculoOpcion;
        int cantidadTipoVehiculos;
        int alquilerDiarioVehiculo;
        string alquilerDiarioVehiculoString;
        int kmVehiculo;
        string kmVehiculoString;
        int vehiculosRegistrados = 0;

        registrarVehiculoAdicional:

        string registrarVehiculoAdicionalString = "";

        (bool espacioVacioVehiculo, int indiceVehiculo) = RevisarEspacioVacioVehiculos();

        if (espacioVacioVehiculo)
        {
            idVehiculo = "";
            marcaVehiculo = "";
            modeloVehiculo = "";
            tipoVehiculoOpcionString = "";
            tipoVehiculoOpcion = 0;
            alquilerDiarioVehiculo = -1;
            alquilerDiarioVehiculoString = "";
            kmVehiculo = -1;
            kmVehiculoString = "";

            cantidadTipoVehiculos = MetodosTipoVehiculo.ConsultarCantidadTipoVehiculos();

            validacionIdVehiculo:
            Console.Write("Introduzca el ID del Vehiculo a registrar: ");
            idVehiculo = Console.ReadLine();
            if (revisarVehiculosRepetidos(idVehiculo))
            {
                goto validacionIdVehiculo;
            }

            validacionMarcaVehiculo:
            Console.Write("Introduzca la marca del vehiculo a registrar: ");
            marcaVehiculo = Console.ReadLine().ToLower();
            if (marcaVehiculo is "")
            {
                Console.WriteLine("La marca del vehiculo no puede estar vacio");
                goto validacionMarcaVehiculo;
            }            

            validacionModeloVehiculo:
            Console.Write("Introduzca el modelo del vehiculo a registrar: ");
            modeloVehiculo = Console.ReadLine().ToLower();
            if (modeloVehiculo is "")
            {
                Console.WriteLine("El modelo del vehiculo no puede estar vacio");
                goto validacionModeloVehiculo;
            }

            validacionTipoVehiculo:
            Console.WriteLine("Tipos de vehiculos, seleccione el numero de la opcion que desea asignar: ");
            MostrarSeleccionTipoVehiculo();
            Console.Write("Tipo de vehiculo a registrar: ");
            tipoVehiculoOpcionString = Console.ReadLine();

            if(!Int32.TryParse(tipoVehiculoOpcionString, out tipoVehiculoOpcion))
            {
                Console.WriteLine($"{tipoVehiculoOpcionString} no es un entero valido");
                goto validacionTipoVehiculo;
            } else
            {
                Int32.TryParse(tipoVehiculoOpcionString, out tipoVehiculoOpcion);
                if (tipoVehiculoOpcion is 0)
                {
                    Console.WriteLine("La seleccion no puede ser 0");
                    goto validacionTipoVehiculo;
                } else if (tipoVehiculoOpcion > cantidadTipoVehiculos)
                {
                    Console.WriteLine("La seleccion no puede ser mayor a la cantidad de opciones disponibles");
                    goto validacionTipoVehiculo;
                } else
                {
                    tipoVehiculo = Program._tipoVehiculo[tipoVehiculoOpcion-1];
                }
            }

            validacionAlquilerDiarioVehiculo:
            Console.Write("Alquiler diario a registrar: ");
            alquilerDiarioVehiculoString = Console.ReadLine();
            if(!Int32.TryParse(alquilerDiarioVehiculoString, out alquilerDiarioVehiculo))
            {
                Console.WriteLine($"{alquilerDiarioVehiculoString} no es un entero valido");
                goto validacionAlquilerDiarioVehiculo;
            } else
            {
                Int32.TryParse(alquilerDiarioVehiculoString, out alquilerDiarioVehiculo);
                if (alquilerDiarioVehiculo is 0)
                {
                    Console.WriteLine("El alquiler diario no puede ser 0");
                    goto validacionAlquilerDiarioVehiculo;
                }
            }
            
            validacionKmVehiculo:
            Console.Write("Kilometraje a registrar: ");
            kmVehiculoString = Console.ReadLine();
            if(!Int32.TryParse(kmVehiculoString, out kmVehiculo))
            {
                Console.WriteLine($"{kmVehiculoString} no es un entero valido");
                goto validacionKmVehiculo;
            } else
            {
                Int32.TryParse(kmVehiculoString, out kmVehiculo);
            }

            RegistrarVehiculo(
                indiceVehiculo,
                idVehiculo,
                marcaVehiculo,
                modeloVehiculo,
                tipoVehiculo,
                alquilerDiarioVehiculo,
                kmVehiculo
            );
            vehiculosRegistrados++;

            validarRegistrarVehiculoAdicional:
            Console.Write("Desea registrar un vehiculo adicional? (Y/N): ");
            registrarVehiculoAdicionalString = Console.ReadLine().ToLower();
            if (registrarVehiculoAdicionalString is "y")
            {
                goto registrarVehiculoAdicional;
            } else if (registrarVehiculoAdicionalString is "n")
            {
                Console.WriteLine("Saliendo del menu registrar vehiculos, presione cualquiler tecla para continuar ");
                Console.ReadKey();
                return vehiculosRegistrados;
            } else
            {
                Console.WriteLine($"{registrarVehiculoAdicionalString} no es una opcion valida");
                goto validarRegistrarVehiculoAdicional;
            }
        } else
        {
            Console.WriteLine("No hay mas espacio para registrar vehiculos, presione cualquiler tecla para regresar al menu principal");
            Console.ReadKey();
            return vehiculosRegistrados;
        }
    }

    public static void ConsultarVehiculos()
    {
        foreach ( Vehiculo vehiculo in Program._vehiculos)
        { 
            if (vehiculo is not null)
            {
                Console.WriteLine($"ID: {vehiculo.Id}");
                Console.WriteLine($"Marca: {vehiculo.Marca}");
                Console.WriteLine($"Modelo: {vehiculo.Modelo}");
                Console.WriteLine($"Tipo ID: {vehiculo.Tipo.Id}");
                Console.WriteLine($"Alquiler diario: {vehiculo.AlquilerDiario}");
                Console.WriteLine($"Kilometraje Vehiculo: {vehiculo.Km}");
                Console.WriteLine("");

            }
        }
    }

    public static int ConsultarCantidadVehiculos()
    {
        int cantidadVehiculos = 0;
        foreach ( Vehiculo vehiculo in Program._vehiculos)
        {
            if (vehiculo is not null)
            {
                cantidadVehiculos++;
            }
        }

        return cantidadVehiculos;
    }
}