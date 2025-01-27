using RecordShop.Common.Models;

namespace RecordShop.Common.Models.ArtistModel
{
    public class ArtistUpdateDTO : IUpdateDTO
    {
        public string Name { get; set; } = null!;
    }
}
