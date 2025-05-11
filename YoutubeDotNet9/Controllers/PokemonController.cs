using Microsoft.AspNetCore.Mvc;

namespace YoutubeDotNet9.Controllers
{
    public class PokemonController : Controller
    {
        // GET: PokemonController
        public ActionResult Index()
        {
            return View();
        }

    }
}
