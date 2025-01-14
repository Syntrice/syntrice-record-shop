using RecordShop.Model;

namespace RecordShop.Repository
{

    public class GenresRepository : GenericRepository<Genre>, IGenresRepository
    {
        public GenresRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
