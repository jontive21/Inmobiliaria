# Inmobiliaria

Sistema de gestión de alquileres temporales, desarrollado como proyecto de la cátedra de Desarrollo de Aplicaciones Web (ULP).

## Descripción

Permite administrar propietarios, inmuebles, inquilinos, reservas y pagos de una inmobiliaria dedicada a alquileres temporales. Una de las reglas centrales del sistema es que un inmueble no puede tener dos reservas que se superpongan en el tiempo.

## Tecnologías

- **.NET 10** (LTS)
- **C# 14**
- **ASP.NET Core MVC**
- **ADO.NET** con **MySqlConnector** para el acceso a datos
- **MySQL** como motor de base de datos
- **Bootstrap** para el front-end

## Entidades del dominio

| Entidad | Descripción |
|---|---|
| Propietario | Dueño de uno o más inmuebles |
| Inquilino | Quien reserva un inmueble |
| Inmueble | La propiedad: dirección, tipo, ambientes, precio |
| Reserva | Un período de alquiler: desde, hasta y monto |
| Pago | Cada cuota abonada de una reserva |
| Usuario | Quien opera el sistema (administrador o empleado) |

## Requisitos previos

- [SDK de .NET 10](https://dotnet.microsoft.com/download)
- MySQL Server (o XAMPP con MySQL habilitado)
- Visual Studio Code con la extensión **C# Dev Kit**, Visual Studio 2026, o Rider

## Configuración

1. Cloná el repositorio:
   ```bash
   git clone <url-del-repositorio>
   cd Inmobiliaria
   ```

2. Restauré los paquetes NuGet:
   ```bash
   dotnet restore
   ```

3. Configurá la cadena de conexión a la base de datos en `appsettings.json` (o mejor, en `appsettings.Development.json` / user-secrets, para no versionar credenciales):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Port=3306;Database=inmobiliaria;User=root;Password=;SslMode=none"
   }
   ```

4. Creá la base de datos `inmobiliaria` y ejecutá el script SQL correspondiente (ver carpeta `/Database` cuando esté disponible).

5. Confiá el certificado de desarrollo HTTPS (una sola vez por máquina):
   ```bash
   dotnet dev-certs https --trust
   ```

## Ejecución

```bash
dotnet run
```

La aplicación queda disponible en `http://localhost:5000` (o el puerto que indique la consola).

## Estructura del proyecto

```
Inmobiliaria/
├── Controllers/     # Controladores MVC
├── Models/           # Entidades del dominio
├── Views/             # Vistas Razor (.cshtml)
├── Repositorios/    # Acceso a datos con ADO.NET (patrón repositorio)
├── wwwroot/         # Archivos estáticos (CSS, JS, imágenes)
├── appsettings.json
└── Program.cs        # Punto de entrada: servicios y middleware
```

## Estado del proyecto

🚧 En desarrollo — trabajo práctico de la cátedra.

## Autor

Proyecto Inmobiliaria · ULP · .NET 10 LTS
