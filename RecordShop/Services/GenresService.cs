using RecordShop.Model;
using RecordShop.Repositories;
using RecordShop.Repositories.Generic;
using RecordShop.Services.Generic;

namespace RecordShop.Services
{
    public class GenresService : GenericService<Genre>, IGenresService
    {
        public GenresService(IGenericRepository<Genre> repository) : base(repository)
        {
        }
    }
}
