namespace RecordShop.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public Record Record { get; set; } = null!;
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
