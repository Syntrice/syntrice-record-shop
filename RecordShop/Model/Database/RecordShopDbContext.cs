using Microsoft.EntityFrameworkCore;
using RecordShop.Model.GenreModel;
using RecordShop.Model.RecordModel;

namespace RecordShop.Model.Database
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }
    }

}
