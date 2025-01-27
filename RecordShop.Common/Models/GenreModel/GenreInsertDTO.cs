using RecordShop.Common.Models;

namespace RecordShop.Common.Models.GenreModel
{
    public class GenreInsertDTO : IInsertDTO
    {
        public string Name { get; set; } = null!;
    }
}
