using Microsoft.AspNetCore.Mvc;

namespace ClinicaPetCare.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
