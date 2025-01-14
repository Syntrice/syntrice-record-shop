namespace RecordShop.Model
{
    public class Record : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
