using Cache_Redis.Model;
using Cache_Redis.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Cache_Redis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IDistributedCache distributedCache;
        private readonly BookService bookService;

        public TestController(ILogger<TestController> logger, IDistributedCache distributedCache, BookService bookService)
        {
            _logger = logger;
            this.distributedCache = distributedCache;
            this.bookService = bookService;
        }


        [HttpGet]
        public ActionResult<string> Index()
        {
            return "Redis分布式缓存 ";
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetItemById(long id)
        {
            Book? result;
            //从redis中读取数据
            string? cacheResult = await distributedCache.GetStringAsync("Book" + id);
            if (cacheResult == null)
            {
                _logger.LogInformation($"从数据库中查询ID={id}的书");
                //从数据库中获取数据 
                result = await bookService.GetItems(id);
                //存入redis
                await distributedCache.SetStringAsync("Book" + id, JsonSerializer.Serialize(result));
            }
            else
            {
                _logger.LogInformation($"从缓存中查询ID={id}的书");
                result = JsonSerializer.Deserialize<Book?>(cacheResult);
            }

            if (result != null)
            {
                return result;
            }
            return NotFound(value: $"未找到ID={id}的书");
        }
    }
}
