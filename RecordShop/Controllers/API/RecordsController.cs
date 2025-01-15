using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Model;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : GenericMappingController<Record, RecordDTO, RecordDTO, RecordDTO>
    {
        public RecordsController(IRecordsService recordsService) : base(recordsService) { }
    }
}
