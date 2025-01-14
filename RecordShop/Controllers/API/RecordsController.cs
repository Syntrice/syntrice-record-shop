using Microsoft.AspNetCore.Mvc;
using RecordShop.Model;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsService recordService;

        public RecordsController(IRecordsService recordService)
        {
            this.recordService = recordService;
        }

        [HttpGet]
        public IActionResult GetRecords()
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetRecordById(int id)
        {
            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostRecord(Record record)
        {
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecordById(int id)
        {
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutGenre(int id, Record record)
        {
            return BadRequest();
        }
    }
}
