namespace RecordShop.Model
{
    public class Genre : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
