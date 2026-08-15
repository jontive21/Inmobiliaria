# Inmobiliaria

Sistema de gestión de alquileres temporales, desarrollado como proyecto de la cátedra de Desarrollo de Aplicaciones Web 

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


