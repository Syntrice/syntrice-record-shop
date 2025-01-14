using Microsoft.AspNetCore.Mvc;
using RecordShop.Model;
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
        public IActionResult GetGenres()
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostGenre(Genre genre)
        {
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenreById(int id)
        {
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult PutGenre(int id,  Genre genre)
        {
            return BadRequest();
        }
    }
}
