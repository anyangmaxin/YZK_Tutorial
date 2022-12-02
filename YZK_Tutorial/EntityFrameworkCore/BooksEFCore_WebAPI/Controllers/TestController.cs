using BooksEFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksEFCore_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly MyDbContext myDbContext;
        public TestController(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        [HttpGet]
        public ActionResult<int> GetCount()
        {
            return myDbContext.Books.Count();
        }
    }
}
