using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService recordService;

        public RecordsController(IRecordService recordService)
        {
            this.recordService = recordService;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello world!");
        }
    }
}
