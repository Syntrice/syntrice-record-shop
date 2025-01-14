using RecordShop.Model;

namespace RecordShop.Repository
{
    public class RecordsRepository : GenericRepository<Record>, IRecordsRepository
    {
        public RecordsRepository(RecordShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
