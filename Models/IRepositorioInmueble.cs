using System.Collections.Generic;

namespace Inmobiliaria.Models
{
    public interface IRepositorioInmueble
    {
        int Alta(Inmueble i);
        bool Baja(int id);
        bool Modificacion(Inmueble i);
        IList<Inmueble> ObtenerTodos(); // Devolverá la lista con los nombres de propietario y tipo ya unidos
        Inmueble? ObtenerPorId(int id);
    }
}