using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
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
    }
}
