using RecordShop.Common.Models;
using RecordShop.Common.Models.ArtistModel;
using RecordShop.Common.Models.GenreModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordShop.Common.Models.RecordModel
{
    public class Record : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        // Foreign Mappings
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; } = null!;
    }
}
