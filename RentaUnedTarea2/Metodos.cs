using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rentaUned
{
    internal class Metodos
    {
        // Helper para convertir string de genero a char
        public static char convertirGenero(string genero)
        {
            if (genero.ToLower() == "masculino" || genero.ToLower() == "")
            {
                return 'm';
            }
            else
            {
                return 'f';
            }
        }
        
        // Helper para convertir char de genero a string
        public static string convertirGenero(char genero)
        {
            if (genero == 'm')
            {
                return "masculino";
            }
            else
            {
                return "femenino";
            }

        }

        // Helper para convertir activo/inactivo a booleano, default (cuando estado es "") es activo
        public static bool stringToBool(string estadoString)
        {

            if (estadoString.ToLower() == "activo" || estadoString.ToLower() == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Helper para convertir de bool a string con el proposito de monstrarlo en el UI al consultar un objecto con este campo
        public static string boolToString(bool estado)
        {
            if (estado)
            {
                return "activo";
            }
            else
            {
                return "inactivo";
            }
        }


        // Registrar objecto en base a los argumentos que este mismo traiga (Overload)
        // Registrar Sucursal
        public static int Registrar(
            int id,
            string nombre,
            string telefono,
            string direccion,
            bool estado)
        {

            for (int i = 0; i < MainArrays.sucursalArray.Length; i++)
            {
                if (MainArrays.sucursalArray[i] is null)
                {
                    MainArrays.sucursalArray[i] = new Sucursal(
                        id,
                        nombre,
                        direccion,
                        estado,
                        telefono);
                    return i;
                }
            }
            return 0;
        }

        // Registrar Cliente
        public static int Registrar(
            string id,
            string nombre,
            string primerApellido,
            string segundoApellido,
            DateTime fechaNacimiento,
            char genero
        )
        {
            for (int i = 0; i < MainArrays.clienteArray.Length; i++)
            {
                if (MainArrays.clienteArray[i] is null)
                {
                    MainArrays.clienteArray[i] = new Cliente(
                        id,
                        nombre,
                        primerApellido,
                        segundoApellido,
                        fechaNacimiento,
                        genero);
                    return i;
                }
            }

            return 0;
        }

        // Registrar Tipo Vehiculo
        public static int Registrar(
            string id,
            string descripcion,
            bool estado
        )
        {
            for (int i = 0; i < MainArrays.tipoVehiculoArray.Length; i++)
            {
                if (MainArrays.tipoVehiculoArray[i] is null)
                {
                    MainArrays.tipoVehiculoArray[i] = new TipoVehiculo(
                        id,
                        descripcion,
                        estado);
                    return i;
                }
            }

            return 0;
        }


        // Registrar Vehiculo
        public static int Registrar(
            string id,
            string marca,
            string modelo,
            string tipoVehiculoId,
            int alquilerDiario,
            int kilometraje
        )
        {
            TipoVehiculo tipo = new TipoVehiculo();

            foreach (TipoVehiculo tipoVehiculo in MainArrays.tipoVehiculoArray)
            {
                if (tipoVehiculo != null)
                {
                    if (tipoVehiculo.Id == tipoVehiculoId)
                    {
                        tipo = tipoVehiculo;
                    }
                }
            }

            for (int i = 0; i < MainArrays.vehiculoArray.Length; i++)
            {
                if (MainArrays.vehiculoArray[i] is null)
                {
                    MainArrays.vehiculoArray[i] = new Vehiculo(
                        id,
                        marca,
                        modelo,
                        tipo,
                        alquilerDiario,
                        kilometraje);
                    return i;
                }
            }
            return 0;
        }

        // Registrar Vehiculo por Sucursal (Toma el Id de la sucursal como el Id de la asignacion)
        public static int Registrar(
           Sucursal sucursal
        )
        {
            for (int i = 0; i < MainArrays.vehiculoSucursalArray.Length; i++)
            {
                if (MainArrays.vehiculoSucursalArray[i] != null && MainArrays.vehiculoSucursalArray[i].Sucursal == sucursal)
                {
                    return i;
                }
            }

            for (int i = 0; i < MainArrays.vehiculoSucursalArray.Length; i++)
            {
                if (MainArrays.vehiculoSucursalArray[i] == null)
                {
                    Vehiculo[] vehiculos = new Vehiculo[10];
                    MainArrays.vehiculoSucursalArray[i] = new VehiculoSucursal(
                        sucursal.Id,
                        DateTime.Now,
                        sucursal,
                        vehiculos);
                    return i;
                }
            }
            return -1;
        }

        // Regisrar Cobertura
        public static int Registrar(
            string id,
            string descripcion,
            bool estado,
            int monto,
            string tipoVehiculoId)
        {
            TipoVehiculo tipo = new TipoVehiculo();

            foreach (TipoVehiculo tipoVehiculo in MainArrays.tipoVehiculoArray)
            {
                if (tipoVehiculo != null && tipoVehiculo.Id == tipoVehiculoId)
                {
                    tipo = tipoVehiculo;
                }
            }

            for (int i = 0; i < MainArrays.coberturaArray.Length; i++)
            {
                if (MainArrays.coberturaArray[i] is null)
                {
                    MainArrays.coberturaArray[i] = new Cobertura(
                        id,
                        descripcion,
                        tipo,
                        estado,
                        monto);
                    return i;
                }
            }
            return 0;
        }

        public static bool RevisarEspacioVacio(object array)
        {
            switch (array)
            {
                case Sucursal[] sucursalArray:
                    return sucursalArray.Contains(null);
                case Cliente[] clienteArray:
                    return clienteArray.Contains(null);
                case Vehiculo[] vehiculoArray:
                    return vehiculoArray.Contains(null);
                case TipoVehiculo[] tipoVehiculoArray:
                    return tipoVehiculoArray.Contains(null);
                case Cobertura[] coberturaArray:
                    return coberturaArray.Contains(null);
                // Este default nunca se va a utilizar ya que este metodo no se usa para llamados dinamicas
                // Esta aqui para satisfacer la estructura de un switch-case
                default:
                    throw new Exception();
            }
        }
        public static bool ValidarSucursalRepetida(int id)
        {
            foreach (Sucursal sucursal in MainArrays.sucursalArray)
            {
                if (sucursal != null)
                {
                    if (sucursal.Id == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool ValidarClienteRepetido(string id)
        {
            foreach (Cliente cliente in MainArrays.clienteArray)
            {
                if (cliente != null)
                {
                    if (cliente.Id == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool ValidarTipoVehiculoRepetido(string id)
        {
            foreach (TipoVehiculo tipoVehiculo in MainArrays.tipoVehiculoArray)
            {
                if (tipoVehiculo != null)
                {
                    if (tipoVehiculo.Id == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool ValidarVehiculoRepetido(string id)
        {
            foreach (Vehiculo vehiculo in MainArrays.vehiculoArray)
            {
                if (vehiculo != null)
                {
                    if (vehiculo.Id == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool ValidarCoberturaRepetida(string id)
        {
            foreach (Cobertura cobertura in MainArrays.coberturaArray)
            {
                if (cobertura != null)
                {
                    if (cobertura.Id == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static bool RevisarSucursalExistenteAsignacion(Sucursal sucursal)
        {
            for (int i = 0; i < MainArrays.vehiculoSucursalArray.Length; i++)
            {
                if (MainArrays.vehiculoSucursalArray[i] != null && MainArrays.vehiculoSucursalArray[i].Sucursal == sucursal)
                {
                    return true;
                }
            }
            return false;
        }

        public static Vehiculo getVehiculoIndex(string vehiculoId)
        {
            for (int i = 0; i < MainArrays.vehiculoArray.Length; i++)
            {
                if (MainArrays.vehiculoArray[i] != null && MainArrays.vehiculoArray[i].Id == vehiculoId)
                {
                    return MainArrays.vehiculoArray[i];
                }
            }
            return null;
        }

        public static void markVehiculoAssigned(Vehiculo vehiculo)
        {
            for (int i = 0; i < MainArrays.vehiculoArray.Length; i++)
            {
                if (MainArrays.vehiculoArray[i] != null && MainArrays.vehiculoArray[i].Id == vehiculo.Id)
                {
                    MainArrays.vehiculoArray[i].Asignado = true;
                }
            }
        }
    }
}
