using RecordShop.Common.Models;

namespace RecordShop.Common.Models.ArtistModel
{
    public class ArtistInsertDTO : IInsertDTO
    {
        public string Name { get; set; } = null!;
    }
}
