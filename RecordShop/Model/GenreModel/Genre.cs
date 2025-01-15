using RecordShop.Model.RecordModel;

namespace RecordShop.Model.GenreModel
{
    public class Genre : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Record> Records { get; } = new List<Record>();
    }
}
