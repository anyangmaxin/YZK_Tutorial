using DI_Lib1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {

        private readonly Class1 class1;

        public Test2Controller(Class1 class1)
        {
            this.class1 = class1;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok(this.class1.Hello());
        }
    }
}
