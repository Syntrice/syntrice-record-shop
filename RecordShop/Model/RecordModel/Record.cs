namespace RecordShop.Model.RecordModel
{
    public class Record : IIdentifiable
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        // Foreign Mappings
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
