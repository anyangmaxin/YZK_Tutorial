using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Config_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 从系统获取用户环境变量值 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetSysPath()
        {
            return Environment.GetEnvironmentVariable("Path");
        }
    }
}
