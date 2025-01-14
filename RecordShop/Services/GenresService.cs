using RecordShop.Repository;

namespace RecordShop.Services
{
    public class GenresService : IGenreService
    {
        private readonly IGenresRepository _genreRepository;

        public GenresService(IGenresRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
    }
}
