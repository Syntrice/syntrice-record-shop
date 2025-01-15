using RecordShop.Model.ArtistModel;
using RecordShop.Model.GenreModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordShop.Model.RecordModel
{
    public class Record : IIdentifiable
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
