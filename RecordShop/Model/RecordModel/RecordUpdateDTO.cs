namespace RecordShop.Model.RecordModel
{
    public class RecordUpdateDTO : IUpdateDTO
    {
        public string Title { get; set; } = null!;
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
