using Microsoft.AspNetCore.Mvc;

namespace TextWave.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Pricing() => View();
        public IActionResult Blog() => View();
        public IActionResult Contact() => View();
        public IActionResult Privacy() => View();
        public IActionResult Terms() => View();
    }
}