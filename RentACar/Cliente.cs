#nullable disable
// Clase principal de cliente, maneja la definicion del objecto cliente y los metodos asociados a dicha clase
class Cliente
{
    private string id;
    private string nombre;
    private string primerApellido;
    private string segundoApellido;
    private DateTime fechaNacimiento;
    private char genero;

    public Cliente()
    {}

    public Cliente(
        string id, 
        string nombre, 
        string primerApellido, 
        string segundoApellido, 
        DateTime fechaNacimiento,
        char genero)
    {
        this.id = id;
        this.nombre = nombre;
        this.primerApellido = primerApellido;
        this.segundoApellido = segundoApellido;
        this.fechaNacimiento = fechaNacimiento;
        this.genero = genero;
    }

    public string Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Nombre
    {
        set { nombre = value; }
        get { return nombre; }
    }

    public string PrimerApellido
    {
        set { primerApellido = value; }
        get { return primerApellido; }
    }

    public string SegundoApellido
    {
        set { segundoApellido = value; }
        get { return segundoApellido; }
    }

    public DateTime FechaNacimiento
    {
        set { fechaNacimiento = value; }
        get { return fechaNacimiento; }
    }

    public char Genero
    {
        set { genero = value; }
        get { return genero; }
    }
}

class MetodosClientes
{
    private static (bool, int) RevisarEspacioVacioClientes()
    {
        for (int i = 0; i < Program._clientes.Length; i++)
        {
            if (Program._clientes[i] is null)
                return(true, i);
        }

        return(false, -1);
    }

    private static bool revisarClientesRepetidos(string idCliente)
    {
        foreach (Cliente cliente in Program._clientes)
        {
            if (cliente is not null)
            {
                if (cliente.Id == idCliente)
                {
                    Console.WriteLine($"El id del cliente {idCliente} ya existe y no se puede repetir");
                    return true;
                }
            }
        }

        return false;
    }

    private static void RegistrarCliente(
        int indiceCliente,
        string nombreCliente,
        string idCliente,
        string primerApellidoCliente,
        string segundoApellidoCliente,
        DateTime fechaNacimientoCliente,
        char generoCliente)
    {
        Cliente nuevoCliente = new Cliente();

        nuevoCliente.Nombre = nombreCliente;
        nuevoCliente.PrimerApellido = primerApellidoCliente;
        nuevoCliente.SegundoApellido = segundoApellidoCliente;
        nuevoCliente.FechaNacimiento = fechaNacimientoCliente;
        nuevoCliente.Id = idCliente;
        nuevoCliente.Genero = generoCliente;

        Console.WriteLine($"Insertando Cliente en la posicion {indiceCliente}");
        Program._clientes[indiceCliente] = nuevoCliente;
    }

    public static int RegistrarClientes()
    {
        string nombreCliente;
        string idCliente;
        string primerApellidoCliente;
        string segundoApellidoCliente;
        DateTime fechaNacimientoCliente;
        string fechaNacimientoClienteString;
        char generoCliente;
        string generoClienteString;
        int clientesRegistrados = 0;

        registrarClienteAdicional:

        string registrarClienteAdicionalString = "";

        (bool espacioVacioCliente, int indiceCliente) = RevisarEspacioVacioClientes();

        if (espacioVacioCliente)
        {
            nombreCliente = "";
            idCliente = "";
            primerApellidoCliente = "";
            segundoApellidoCliente = "";
            fechaNacimientoCliente = DateTime.Parse("05/05/2005");
            fechaNacimientoClienteString = "";
            generoCliente = 'j';
            
            validacionNombreCliente:
            Console.Write("Introduzca el nombre del cliente a registrar: ");
            nombreCliente = Console.ReadLine().ToLower();
            if (nombreCliente is "")
            {
                Console.WriteLine("El nombre del cliente no puede estar vacio");
                goto validacionNombreCliente;
            }

            validacionPrimerApellidoCliente:
            Console.Write("Introduzca el primer apellido del cliente a registrar: ");
            primerApellidoCliente = Console.ReadLine().ToLower();
            if (primerApellidoCliente is "")
            {
                Console.WriteLine("El primero apellido del cliente no puede estar vacio");
                goto validacionPrimerApellidoCliente;
            }

            validacionSegundoApellidoCliente:
            Console.Write("Introduzca el segundo apellido del cliente a registrar: ");
            segundoApellidoCliente = Console.ReadLine().ToLower();
            if (segundoApellidoCliente is "")
            {
                Console.WriteLine("El segundo apellido del cliente no puede estar vacio");
                goto validacionSegundoApellidoCliente;
            }

            validacionIdCliente:
            Console.Write("Introduzca el ID del Cliente a registrar: ");
            idCliente = Console.ReadLine();
            if (revisarClientesRepetidos(idCliente))
            {
                goto validacionIdCliente;
            }

            validacionFechaNacimientoCliente:
            Console.Write("Introduzca la fecha de nacimiento del cliente (mm/dd/AAAA): ");
            fechaNacimientoClienteString = Console.ReadLine();

            try {
                fechaNacimientoCliente = DateTime.Parse(fechaNacimientoClienteString);
            } catch (FormatException)
            {
                Console.WriteLine($"{fechaNacimientoClienteString} no es una fecha valida");
                goto validacionFechaNacimientoCliente;
            }

            validacionGeneroCliente:
            Console.Write("Introduzca el genero del cliente (M/F): ");
            generoClienteString = Console.ReadLine().ToLower();
            if (generoClienteString.Length > 1) {
                Console.WriteLine("El genero debe ser un solo caracter");
                goto validacionGeneroCliente;
            } else {
                generoCliente = generoClienteString.ToCharArray()[0];
                if (!new[] {'f', 'm'}.Contains(generoCliente)) {
                    Console.WriteLine($"El genero del cliente no puede ser {generoCliente}");
                    goto validacionGeneroCliente;
                }
            }

            RegistrarCliente(
                indiceCliente,
                nombreCliente,
                idCliente,
                primerApellidoCliente,
                segundoApellidoCliente,
                fechaNacimientoCliente,
                generoCliente
            );
            clientesRegistrados++;

            validarRegistrarClienteAdicional:
            Console.Write("Desea registrar un cliente adicional? (Y/N): ");
            registrarClienteAdicionalString = Console.ReadLine().ToLower();
            if (registrarClienteAdicionalString is "y")
            {
                goto registrarClienteAdicional;
            } else if (registrarClienteAdicionalString is "n")
            {
                Console.WriteLine("Saliendo del menu registrar clientes, presione cualquier tecla para continuar ");
                Console.ReadKey();
                return clientesRegistrados;
            } else
            {
                Console.WriteLine($"{registrarClienteAdicionalString} no es una opcion valida");
                goto validarRegistrarClienteAdicional;
            }
        } else
        {
            Console.WriteLine("No hay espacio para registrar clientes adicionales, presione cualquier tecla para regresar al menu principal");
            Console.ReadKey();
            return clientesRegistrados;
        }
    }

    public static void ConsultarClientes()
    {
        foreach ( Cliente cliente in Program._clientes)
        { 
            if (cliente is not null)
            {
                Console.WriteLine($"ID: {cliente.Id}");
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Primer Apellido: {cliente.PrimerApellido}");
                Console.WriteLine($"Segundo Apellido: {cliente.SegundoApellido}");
                Console.WriteLine($"Fecha de nacimiento: {cliente.FechaNacimiento}");
                Console.WriteLine($"Genero: {cliente.Genero}");
                Console.WriteLine("");
            }
        }
    }

    public static int ConsultarCantidadClientes()
    {
        int cantidadClientes = 0;
        foreach ( Cliente cliente in Program._clientes)
        {
            if (cliente is not null)
            {
                cantidadClientes++;
            }
        }

        return cantidadClientes;
    }

}