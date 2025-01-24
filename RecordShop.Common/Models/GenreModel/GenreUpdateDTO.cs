using RecordShop.Common.Models;

namespace RecordShop.Common.Models.GenreModel
{
    public class GenreUpdateDTO : IUpdateDTO
    {
        public string Name { get; set; } = null!;
    }
}
