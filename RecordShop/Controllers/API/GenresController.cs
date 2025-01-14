using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;

namespace RecordShop.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
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
