namespace Inmobiliaria.Models
{
    public interface IRepositorioInquilino
    {
        int Alta(Inquilino p);
        bool Baja(int id);
        bool Modificacion(Inquilino p);
        IList<Inquilino> ObtenerTodos();
        Inquilino? ObtenerPorId(int id);
    }
}