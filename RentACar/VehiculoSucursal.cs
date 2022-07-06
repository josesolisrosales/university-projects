// #nullable disable

// class VehiculoSucursal
// {
//     private int id;
//     private DateTime fecha;
//     private Sucursal sucursal;
//     private Vehiculo[] vehiculos;

//     public VehiculoSucursal()
//     {}

//     public VehiculoSucursal(
//         int id,
//         DateTime fecha,
//         Sucursal sucursal,
//         Vehiculo[] vehiculos)
//     {
//         this.id = id;
//         this.fecha = fecha;
//         this.sucursal = sucursal;
//         this.vehiculos = vehiculos;
//     }

//     public int Id
//     {
//         set { id = value; }
//         get { return id; }
//     }

//     public DateTime Fecha
//     {
//         set { fecha = value; }
//         get { return fecha; }
//     }

//     public Sucursal Sucursal
//     {
//         set { sucursal = value; }
//         get { return sucursal; }
//     }

//     public Vehiculo[] Vehiculos
//     {
//         set { vehiculos = value; }
//         get { return vehiculos; }
//     }

// }

// class MetodosVehiculoSucursal
// {
//     private static (bool, int) RevisarEspacioVacio()
//     {
//         for (int i = 0; i < Program._vehiculosSucursal.Length; i++)
//         {
//             if (Program._vehiculosSucursal[i] is null)
//                 return(true, i);
//         }

//         return(false, -1);
//     }

//     private static bool validarSucursalId(int id)
//     {
//         foreach (Sucursal sucursal in Program._sucursales)
//         {
//             if (sucursal is not null)
//             {
//                 if (sucursal.Id == id)
//                 {
//                     return true;
//                 }
//             }
//         }

//         return false;
//     }

//     private static bool validarVehiculoId(string id)
//     {
//         foreach (Vehiculo vehiculo in Program._vehiculos)
//         {
//             if (vehiculo is not null)
//             {
//                 if (vehiculo.Id == id)
//                 {
//                     return true;
//                 }
//             }
//         }

//         return false;
//     }

//     public static void RegistrarAsignacion(int idSucursal, DateTime fecha, string idVehiculo)
//     {
//         for (int i = 0; i < Program._vehiculosSucursal.Length; i++)
//         {
//             if (Program._vehiculosSucursal[i] is null)
//             {
//                 if (Program._sucursales[i].Id == idSucursal)
//                 {
//                     asignacion.Sucursal = Program._sucursales[i];
//                 }
//             }
//         }

//         for (int i = 0; i < Program._vehiculosSucursal.Length; i++)
//         {
//             if (Program._vehiculosSucursal[i] is not null)
//             {
//                 if (idSucursal == Program._vehiculosSucursal[i].Sucursal)
//             }
//         }
//         VehiculoSucursal asignacion = new VehiculoSucursal();

//         asignacion.Fecha = fecha;
//         for (int i = 0; i < Program._sucursales.Length; i++)
//         {
//             if (Program._sucursales[i] is not null)
//             {
//                 if (Program._sucursales[i].Id == idSucursal)
//                 {
//                     asignacion.Sucursal = Program._sucursales[i];
//                 }
//             }
//         }
        
//     }

//     public static int RegistrarVehiculosSucursal()
//     {
//         DateTime fecha = DateTime.Today;
//         int sucursalId;
//         string sucursalIdString;
//         string vehiculoIdString;

//         validacionsucursalId:
//         Console.Clear();
//         MetodosSucursales.ConsultarSucursalesActivas();
//         Console.Write("Introduzca el ID de la sucursal a realizar la asignacion: ");
//         sucursalIdString = Console.ReadLine().ToLower();

//         if(!Int32.TryParse(sucursalIdString, out sucursalId))
//         {
//             Console.WriteLine($"{sucursalIdString} no es un entero valido, presione cualquier tecla para continuar");
//             Console.ReadKey();
//             goto validacionsucursalId;        
//         } else
//         {
//             Int32.TryParse(sucursalIdString, out sucursalId);
//             if (sucursalId == 0)
//             {
//                 Console.WriteLine("El ID de la sucursal no puede ser 0, presione cualquier tecla para continuar");
//                 Console.ReadKey();
//                 goto validacionsucursalId;
//             } else
//             {
//                 if(!validarSucursalId(sucursalId))
//                 {
//                     Console.WriteLine($"No existe sucursal con el ID {sucursalId}, presione cualquier tecla para continura");
//                     Console.WriteLine("");
//                     Console.ReadKey();
//                     goto validacionsucursalId;
//                 }
//             }
//         }

//         validacionVehiculoId:
//         Console.Clear();
//         MetodosVehiculo.ConsultarVehiculos();
//         Console.WriteLine($"Introduzca el id del vehiculo que desea asignar a la sucursal {sucursalId}");
//         vehiculoIdString = Console.ReadLine();
//         if(!validarVehiculoId(vehiculoIdString))
//         {
//             Console.WriteLine($"No existe vehiculo con el ID {sucursalId}, presione cualquier tecla para continuar");
//             Console.WriteLine("");
//             Console.ReadKey();
//             goto validacionVehiculoId;
//         }

//         RegistrarAsignacion(sucursalId, fecha, vehiculoIdString);

//     }
// }