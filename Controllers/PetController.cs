using Microsoft.AspNetCore.Mvc;
using ClinicaPetCare.Data;
using ClinicaPetCare.Models;

namespace ClinicaPetCare.Controllers
{
    public class PetController : Controller
    {
        // Primero mostramos la lista de mascotas
        public IActionResult Index()
        {
            var mascotas = PetRepo.ObtenerTodos();
            return View(mascotas);
        }

        // Mustramos el formulario para agregar una nueva mascota
        public IActionResult Create()
        {
            return View(new Pet());
        }

        // Recibe el formulario enviado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pet model)
        {
            // Si el modelo tiene errores de validación, se vuelve a mostrar el formulario
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Si todo está bien, se agrega la mascota
            PetRepo.Agregar(model);

            // Mensaje temporal para mostrar en la vista principal
            TempData["Mensaje"] = $"Mascota '{model.NombreMascota}' registrada correctamente.";

            // Redirige al listado
            return RedirectToAction(nameof(Index));
        }
    }
}