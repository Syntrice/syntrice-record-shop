using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Model.GenreModel;
using RecordShop.Services;
using RecordShop.Services.Generic;

namespace RecordShop.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : GenericMappingController<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO>
    {
        public GenresController(IGenresService genresService) : base(genresService) { }
    }
}
