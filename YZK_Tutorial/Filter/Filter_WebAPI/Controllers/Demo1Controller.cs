using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filter_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Demo1Controller : ControllerBase
    {
        /// <summary>
        /// 用于测试返回异常信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetFile()
        {
            string s = System.IO.File.ReadAllText("f:1.txt");
            return s;
        }

        /// <summary>
        /// 用于测试MyActionFilter1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string TestMyActionFilter1()
        {
            Console.WriteLine("MyActionFilter1执行中：");
            return "MyActionFilter1";
        }
    }
}
