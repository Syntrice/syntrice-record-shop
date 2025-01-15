namespace RecordShop.Model.RecordModel
{
    public class RecordUpdateDTO
    {
        public string Title { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
