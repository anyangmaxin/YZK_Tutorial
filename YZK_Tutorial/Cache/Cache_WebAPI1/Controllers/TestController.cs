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
        private readonly ILogger<TestController> logger;

        public TestController(IMemoryCache memoryCache, ILogger<TestController> logger)
        {
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Book?>> GetBookById(long id)
        {
            logger.LogInformation($"查找ID={id}的书籍");
            //先从缓存 拿，缓存 拿不到就调用回调函数从数据库中获取 然后再写入缓存 中
            Book? result = await this.memoryCache.GetOrCreateAsync($"Book{id}", async (e) =>
            {
                //设置缓存 10秒钟过期
                e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                logger.LogInformation($"从数据库中查找ID={id}的书籍");

                return await MyDbContext.GetByIdAsync(id);
            });
            logger.LogInformation($"查找ID={id}的书籍的结果{result}");

            if (result == null)
            {
                return NotFound($"找不到ID={id}的书");
            }
            return result;
        }
    }
}
