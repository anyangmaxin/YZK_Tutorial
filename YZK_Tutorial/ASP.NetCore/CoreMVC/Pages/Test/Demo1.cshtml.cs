using CoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreMVC.Pages
{
    public class Demo1Model : PageModel
    {
        public Person Person { get; set; }

        public void OnGet()
        {
            Person = new Person("Zack", true, new DateTime(1999, 9, 9));
        }


        //public IActionResult Demo1()
        //{

        //    var model = new Person("Zack", true, new DateTime(1999, 9, 9));
        //    return View(model);
        //}


    }
}
