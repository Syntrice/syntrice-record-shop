using Microsoft.EntityFrameworkCore;

namespace RecordShop.Model
{
    public class RecordShopDbContext : DbContext
    {
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }
    }
}
