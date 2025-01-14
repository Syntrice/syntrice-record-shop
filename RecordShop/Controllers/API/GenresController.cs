using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Model;
using RecordShop.Services;
using RecordShop.Services.Generic;

namespace RecordShop.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : GenericController<Genre>
    {
        public GenresController(IGenresService genresService) : base(genresService) { }
    }
}
