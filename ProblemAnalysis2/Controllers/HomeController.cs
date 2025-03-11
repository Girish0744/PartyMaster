//Girish Bhuteja
//Bachelors of Computer Science (Honors)
//Conestoga College

using Microsoft.AspNetCore.Mvc;

namespace ProblemAnalysis2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
