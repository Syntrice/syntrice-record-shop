namespace RecordShop.Model.ArtistModel
{
    public class Artist : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
