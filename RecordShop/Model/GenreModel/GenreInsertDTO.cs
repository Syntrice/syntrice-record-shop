using RecordShop.Model.RecordModel;

namespace RecordShop.Model.GenreModel
{
    public class GenreInsertDTO : IInsertDTO
    {
        public string Name { get; set; } = null!;
    }
}
