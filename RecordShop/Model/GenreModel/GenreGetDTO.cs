using RecordShop.Model.RecordModel;

namespace RecordShop.Model.GenreModel
{
    public class GenreGetDTO : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
