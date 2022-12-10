using Filter_WebAPI.Model;
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

        [HttpGet]
        public Book GetBook(long id)
        {
            var model = myDbContext.Books.FirstOrDefault(x => x.Id == id);
            return model;
        }


        [HttpPost]
        public async Task<string> AddBook()
        {
            myDbContext.Books.Add(new Model.Book { Title = "我最棒" + DateTime.Now });
            await myDbContext.SaveChangesAsync();
            return "OK";
        }
    }
}
