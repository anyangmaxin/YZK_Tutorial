using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly Calculator calculator;
        private readonly TestService testService;

        public TestController(Calculator calculator, TestService testService)
        {
            this.calculator = calculator;
            this.testService = testService;
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

        [HttpGet]
        public IActionResult GetFileCount()
        {
            return Ok(this.testService.Count());
        }
    }
}
