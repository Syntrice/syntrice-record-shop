using RecordShop.Model.ArtistModel;
using RecordShop.Model.Database;
using RecordShop.Repositories.Generic;

namespace RecordShop.Repositories
{
    public class ArtistsRepository : GenericCRUDRepository<Artist>, IArtistsRepository
    {
        public ArtistsRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
