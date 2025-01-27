using RecordShop.Common.Models;

namespace RecordShop.Common.Models.ArtistModel
{
    public class Artist : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
