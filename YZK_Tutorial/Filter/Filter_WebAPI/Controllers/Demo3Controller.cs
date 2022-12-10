using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filter_WebAPI.Controllers
{
    /// <summary>
    /// 用于测试限流
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class Demo3Controller : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Index()
        {
            return "OK";
        }
    }
}
