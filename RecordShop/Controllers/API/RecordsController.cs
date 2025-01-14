using Microsoft.AspNetCore.Mvc;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello world!");
        }
    }
}
