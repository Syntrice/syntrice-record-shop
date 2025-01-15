using RecordShop.Model;

namespace RecordShop.Tests.Utility
{
    internal class MockDTO : IIdentifiable
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
