using RecordShop.Model.RecordModel;

namespace RecordShop.Model.GenreModel
{
    public class GenreUpdateDTO : IUpdateDTO
    {
        public string Name { get; set; } = null!;
    }
}
