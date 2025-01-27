using RecordShop.Common.Models;

namespace RecordShop.Common.Models.GenreModel
{
    public class GenreGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
