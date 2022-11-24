using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //private readonly Calculator calculator;
        //private readonly TestService testService;

        //public TestController(Calculator calculator, TestService testService)
        //{
        //    this.calculator = calculator;
        //    this.testService = testService;
        //}


        private readonly Calculator calculator;

        public TestController(Calculator calculator)
        {
            this.calculator = calculator;
        }
        [HttpPost]
        public IActionResult Add(int x, int y)
        {
            //return calculator.Add(3, 5);
            return Ok(this.calculator.Add(x, y));
        }

        [HttpPost]
        public IActionResult Add2(int x, int y)
        {
            //return calculator.Add(3, 5);
            return Ok(this.calculator.Add(x, y));
        }

        //[HttpGet]
        //public IActionResult GetFileCount()
        //{
        //    return Ok(this.testService.Count());
        //}

        /// <summary>
        /// 需要用到的时候再构造相应服务，不影响全局加载
        /// </summary>
        /// <param name="testService"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFileCount([FromServices]TestService testService)
        {
            return Ok(testService.Count());
        }
    }
}
