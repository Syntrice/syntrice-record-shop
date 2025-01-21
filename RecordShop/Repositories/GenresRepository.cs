using RecordShop.Model.Database;
using RecordShop.Model.GenreModel;
using RecordShop.Repositories.Generic;

namespace RecordShop.Repositories
{

    public class GenresRepository : GenericCRUDRepository<Genre>, IGenresRepository
    {
        public GenresRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
