using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Model.RecordModel;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : GenericMappingController<Record, RecordGetDTO, RecordGetDTO, RecordGetDTO>
    {
        public RecordsController(IRecordsService recordsService) : base(recordsService) { }
    }
}
