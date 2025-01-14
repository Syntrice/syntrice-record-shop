using RecordShop.Model;
using RecordShop.Repositories.Generic;

namespace RecordShop.Repositories
{
    public class RecordsRepository : GenericRepository<Record>, IRecordsRepository
    {
        public RecordsRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
