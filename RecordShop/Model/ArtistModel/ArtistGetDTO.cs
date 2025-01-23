namespace RecordShop.Model.ArtistModel
{
    public class ArtistGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
