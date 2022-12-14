using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filter_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v0")]
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
            try
            {
                Console.WriteLine("MyActionFilter1执行中：");
                return "MyActionFilter1";
            }
            catch (Exception ex)
            {
                Console.WriteLine("MyActionFilter1异常：" + ex.Message);
                return ex.Message;
            }
            finally
            {
                Console.WriteLine("MyActionFilter1  finally：");
            }

        }
    }
}
