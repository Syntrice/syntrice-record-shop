using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Model.ArtistModel;
using RecordShop.Services;
using RecordShop.Services.Generic;

namespace RecordShop.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : GenericMappingController<Artist, ArtistGetDTO, ArtistInsertDTO, ArtistUpdateDTO>
    {
        public ArtistsController(IArtistsService service) : base(service)
        {
        }
    }
}
