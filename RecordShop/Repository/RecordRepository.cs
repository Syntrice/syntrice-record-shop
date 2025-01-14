using RecordShop.Model;

namespace RecordShop.Repository
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        public RecordRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
