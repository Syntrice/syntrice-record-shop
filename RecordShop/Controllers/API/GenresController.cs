using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genreService;

        public GenresController(IGenresService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello world!");
        }
    }
}
