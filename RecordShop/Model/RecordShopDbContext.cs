using Microsoft.EntityFrameworkCore;
using RecordShop.Model.RecordModel;

namespace RecordShop.Model
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }
    }
}
