using RecordShop.Database;
using RecordShop.Common.Models.ArtistModel;
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
