using RecordShop.Model;
using RecordShop.Repositories.Generic;

namespace RecordShop.Repositories
{

    public class GenresRepository : GenericRepository<Genre>, IGenresRepository
    {
        public GenresRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
