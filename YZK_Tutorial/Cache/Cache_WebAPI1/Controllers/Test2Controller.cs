using Cache_WebAPI1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cache_WebAPI1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        private readonly ILogger<Test2Controller> logger;
        private readonly TestService testService;

        public Test2Controller(ILogger<Test2Controller> logger, TestService testService)
        {
            this.logger = logger;
            this.testService = testService;
        }

        [HttpGet]
        public ActionResult<List<int>> GetItems()
        {
            var result = testService.GetItems();
            logger.LogInformation("开始读取");

            return result.ToList();
        }

        [HttpGet]
        public ActionResult<List<int>> GetItems2()
        {
            var result = testService.GetItems().ToList();
            logger.LogInformation("开始读取");


            return result;
        }
    }
}
