using RecordShop.Model.ArtistModel;
using RecordShop.Model.Database;
using RecordShop.Repositories.Generic;

namespace RecordShop.Repositories
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
