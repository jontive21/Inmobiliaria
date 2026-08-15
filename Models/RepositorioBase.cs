using Inmobiliaria.Data;
using MySqlConnector;

namespace Inmobiliaria.Models
{
    // Clase base para todos los repositorios: guarda la cadena de conexión
    // y expone un método para obtener una conexión nueva ya abierta.
    public class RepositorioBase
    {
        protected readonly string connectionString;

        public RepositorioBase()
        {
            connectionString = Conexion.Cadena
                ?? throw new InvalidOperationException(
                    "No se configuró la cadena de conexión (Conexion.Cadena).");
        }

        protected MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }
    }
}