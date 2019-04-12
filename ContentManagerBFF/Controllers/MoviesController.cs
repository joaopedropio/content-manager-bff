using Microsoft.AspNetCore.Mvc;

namespace ContentManagerBFF.Controllers
{
    [Produces("application/json")]
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