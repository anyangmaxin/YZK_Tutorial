using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Config_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public TestController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        /// <summary>
        /// 从系统获取用户环境变量值 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetSysPath()
        {
            return Environment.GetEnvironmentVariable("Path");
        }

        /// <summary>
        /// 通过注入的IWebHostEnvironment内置属性来获取配置参数,就是app.Environment
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public ActionResult<string> GetEnvValue()
        {
            return _environment.EnvironmentName;
        }
    }
}
