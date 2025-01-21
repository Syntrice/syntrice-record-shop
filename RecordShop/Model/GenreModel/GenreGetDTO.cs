using RecordShop.Model.RecordModel;

namespace RecordShop.Model.GenreModel
{
    public class GenreGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
