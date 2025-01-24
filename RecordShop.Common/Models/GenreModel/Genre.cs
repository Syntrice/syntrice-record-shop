using RecordShop.Common.Models;
using RecordShop.Common.Models.RecordModel;

namespace RecordShop.Common.Models.GenreModel
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Record> Records { get; } = new List<Record>();
    }
}
