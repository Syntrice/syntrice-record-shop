using RecordShop.Model;
using RecordShop.Repositories;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class GenresService : GenericNonMappingService<Genre>, IGenresService
    {
        public GenresService(IGenresRepository repository) : base(repository)
        {
        }
    }
}
