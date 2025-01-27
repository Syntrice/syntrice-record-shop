using RecordShop.Database;
using RecordShop.Common.Models.RecordModel;
using RecordShop.Repositories.Generic;

namespace RecordShop.Repositories
{
    public class RecordsRepository : GenericCRUDRepository<Record>, IRecordsRepository
    {
        public RecordsRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
