using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Common.Models.RecordModel;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : GenericCRUDController<Record, RecordGetDTO, RecordInsertDTO, RecordUpdateDTO>
    {
        public RecordsController(IRecordsService recordsService) : base(recordsService) { }
    }
}
