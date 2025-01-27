using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Models.ArtistModel;
using RecordShop.Common.Models.GenreModel;
using RecordShop.Common.Models.RecordModel;

namespace RecordShop.Database
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }
    }

}
