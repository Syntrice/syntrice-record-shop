using RecordShop.Model;
using RecordShop.Repositories;

namespace RecordShop.Services
{
    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _genreRepository;

        public GenresService(IGenresRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
    }
}
