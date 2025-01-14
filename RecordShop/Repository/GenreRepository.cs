using RecordShop.Model;

namespace RecordShop.Repository
{

    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
