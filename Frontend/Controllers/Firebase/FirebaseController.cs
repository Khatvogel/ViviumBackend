using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers.Firebase
{
    public class FirebaseController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}