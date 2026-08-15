namespace Inmobiliaria.Data
{
    // Guarda la cadena de conexión leída una sola vez al arrancar la app (Program.cs)
    // para que cualquier repositorio pueda usarla sin pedirla por inyección de dependencias.
    public static class Conexion
    {
        public static string? Cadena { get; set; }
    }
}