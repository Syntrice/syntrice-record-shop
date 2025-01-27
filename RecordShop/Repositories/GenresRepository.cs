using RecordShop.Database;
using RecordShop.Common.Models.GenreModel;
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
