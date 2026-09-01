using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inmobiliaria.Models;
using System.Linq;
namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly IRepositorioInmueble repositorioInmueble;
        private readonly IRepositorioPropietario repositorioPropietario;
        // Nota: cuando tu compañero tenga listo el repositorio de TipoInmueble, 
        // agregaremos aquí su interfaz. Por ahora usaremos una lista estática.

        public InmueblesController(IRepositorioInmueble repositorioInmueble, IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioInmueble = repositorioInmueble;
            this.repositorioPropietario = repositorioPropietario;
        }

        // GET: Inmuebles
        public IActionResult Index()
        {
            var lista = repositorioInmueble.ObtenerTodos();
            return View(lista);
        }

        // GET: Inmuebles/Details/5
        public IActionResult Details(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            if (i == null)
            {
                return NotFound();
            }
            return View(i);
        }

        // GET: Inmuebles/Create
        public IActionResult Create()
        {
            CargarDropdowns();
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inmueble i)
        {
            if (!ModelState.IsValid)
            {
                CargarDropdowns();
                return View(i);
            }

            try
            {
                repositorioInmueble.Alta(i);
                TempData["Mensaje"] = "Inmueble creado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo crear el inmueble: " + ex.Message;
                CargarDropdowns();
                return View(i);
            }
        }

        // GET: Inmuebles/Edit/5
        public IActionResult Edit(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            if (i == null)
            {
                return NotFound();
            }
            CargarDropdowns();
            return View(i);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Inmueble i)
        {
            if (id != i.IdInmueble)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                CargarDropdowns();
                return View(i);
            }

            try
            {
                repositorioInmueble.Modificacion(i);
                TempData["Mensaje"] = "Inmueble modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "No se pudo modificar el inmueble: " + ex.Message;
                CargarDropdowns();
                return View(i);
            }
        }

        // GET: Inmuebles/Delete/5
        public IActionResult Delete(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            if (i == null)
            {
                return NotFound();
            }
            return View(i);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                repositorioInmueble.Baja(id);
                TempData["Mensaje"] = "Inmueble eliminado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No se pudo eliminar el inmueble: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // Método privado para cargar los dropdowns de Propietario y TipoInmueble
        private void CargarDropdowns()
{
    // Dropdown de Propietarios - Concatenamos Nombre y Apellido
    var propietarios = repositorioPropietario.ObtenerTodos();
    var listaPropietarios = propietarios.Select(p => new SelectListItem
    {
        Value = p.IdPropietario.ToString(),
        Text = $"{p.Nombre} {p.Apellido}"
    }).ToList();
    ViewBag.Propietarios = listaPropietarios;

    // Dropdown de Tipos de Inmueble
    ViewBag.Tipos = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Casa" },
        new SelectListItem { Value = "2", Text = "Departamento" },
        new SelectListItem { Value = "3", Text = "Monoambiente" },
        new SelectListItem { Value = "4", Text = "Loft" }
    };
}
    }
}    