using Microsoft.AspNetCore.Mvc;
using RecordShop.Controllers.API.Generic;
using RecordShop.Common.Models.GenreModel;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : GenericCRUDController<Genre, GenreGetDTO, GenreInsertDTO, GenreUpdateDTO>
    {
        public GenresController(IGenresService genresService) : base(genresService) { }
    }
}
