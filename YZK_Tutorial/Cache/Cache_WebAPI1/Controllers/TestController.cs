using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net.NetworkInformation;

namespace Cache_WebAPI1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;

        public TestController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public ActionResult<Book?> GetBookById(long id)
        {
            Book? result = MyDbContext.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"找不到ID={id}的书");
            }
            return result;
        }
    }
}
