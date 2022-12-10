using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filter_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Demo2Controller : ControllerBase
    {
        private readonly MyDbContext myDbContext;

        public Demo2Controller(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        [HttpPost]
        public String Test2()
        {
            myDbContext.Books.Add(new Model.Book { Id = 1, Title = "我最棒" });
            myDbContext.SaveChangesAsync();
            return "";
        }
    }
}
