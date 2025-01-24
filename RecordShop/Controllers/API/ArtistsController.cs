using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Common.Models.ArtistModel;
using RecordShop.Services;
using RecordShop.Services.Generic;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : GenericCRUDController<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>
    {
        public ArtistsController(IArtistsService service) : base(service)
        {
        }
    }
}
