using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace Filter_WebAPI.Filter
{
    /// <summary>
    /// 自定义限流Filter
    /// </summary>
    public class RateLimitFilter : IAsyncActionFilter
    {
        private readonly IMemoryCache memoryCache;

        public RateLimitFilter(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //throw new NotImplementedException();
            string removeIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
            string cacheKey = $"LastVisitTick_{removeIP}";
            long? lastTick = this.memoryCache.Get<long?>(cacheKey);
            if (lastTick == null || Environment.TickCount64 - lastTick > 1000) //未找到存储的值 或者是上次请求到现在已经超过1秒
            {
                //设置本次请求的时间，以及10秒后删除多余的缓存 数据
                this.memoryCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
                //继续执行
                return next();
            }
            else
            {
                //返回状态码，不继续执行
                context.Result = new ContentResult() { StatusCode = 429, Content = "访问过于频繁" };
                return Task.CompletedTask;
            }
        }
    }
}
