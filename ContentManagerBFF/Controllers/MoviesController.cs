using Microsoft.AspNetCore.Mvc;

namespace ContentManagerBFF.Controllers
{
    [Route("/dashtest")]
    public class DashTestController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}