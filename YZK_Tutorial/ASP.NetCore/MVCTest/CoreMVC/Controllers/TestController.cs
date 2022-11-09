using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo1()
        {
            var model = new Person("Iron Man", true, new DateTime(1999, 9, 9));
            return View(model);
        }
    }
}
