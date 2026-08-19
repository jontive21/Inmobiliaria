using MySqlConnector;

namespace Inmobiliaria.Models
{
    public class RepositorioInquilino : RepositorioBase, IRepositorioInquilino
    {
        public int Alta(Inquilino p)
        {
            int id = 0;
            string sql = @"INSERT INTO Inquilino (Nombre, Apellido, Dni, Email, Telefono)
                            VALUES (@nombre, @apellido, @dni, @email, @telefono);
                            SELECT LAST_INSERT_ID();";

            using (var connection = ObtenerConexion())
            {
                var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nombre", p.Nombre);
                command.Parameters.AddWithValue("@apellido", p.Apellido);
                command.Parameters.AddWithValue("@dni", p.Dni);
                command.Parameters.AddWithValue("@email", (object?)p.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@telefono", (object?)p.Telefono ?? DBNull.Value);

                connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            p.IdInquilino = id;
            return id;
        }

        public bool Baja(int id)
        {
            int filasAfectadas = 0;
            string sql = "DELETE FROM Inquilino WHERE IdInquilino = @id";

            using (var connection = ObtenerConexion())
            {
                var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                filasAfectadas = command.ExecuteNonQuery();
            }
            return filasAfectadas > 0;
        }

        public bool Modificacion(Inquilino p)
        {
            int filasAfectadas = 0;
            string sql = @"UPDATE Inquilino
                            SET Nombre = @nombre,
                                Apellido = @apellido,
                                Dni = @dni,
                                Email = @email,
                                Telefono = @telefono
                            WHERE IdInquilino = @id";

            using (var connection = ObtenerConexion())
            {
                var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nombre", p.Nombre);
                command.Parameters.AddWithValue("@apellido", p.Apellido);
                command.Parameters.AddWithValue("@dni", p.Dni);
                command.Parameters.AddWithValue("@email", (object?)p.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@telefono", (object?)p.Telefono ?? DBNull.Value);
                command.Parameters.AddWithValue("@id", p.IdInquilino);

                connection.Open();
                filasAfectadas = command.ExecuteNonQuery();
            }
            return filasAfectadas > 0;
        }

        public IList<Inquilino> ObtenerTodos()
        {
            var lista = new List<Inquilino>();
            string sql = @"SELECT IdInquilino, Nombre, Apellido, Dni, Email, Telefono
                            FROM Inquilino
                            ORDER BY Apellido, Nombre";

            using (var connection = ObtenerConexion())
            {
                var command = new MySqlCommand(sql, connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearInquilino(reader));
                    }
                }
            }
            return lista;
        }

        public Inquilino? ObtenerPorId(int id)
        {
            Inquilino? p = null;
            string sql = @"SELECT IdInquilino, Nombre, Apellido, Dni, Email, Telefono
                            FROM Inquilino
                            WHERE IdInquilino = @id";

            using (var connection = ObtenerConexion())
            {
                var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = MapearInquilino(reader);
                    }
                }
            }
            return p;
        }

        private static Inquilino MapearInquilino(MySqlDataReader reader)
        {
            return new Inquilino
            {
                IdInquilino = reader.GetInt32("IdInquilino"),
                Nombre = reader.GetString("Nombre"),
                Apellido = reader.GetString("Apellido"),
                Dni = reader.GetString("Dni"),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString("Telefono"),
            };
        }
    }
}