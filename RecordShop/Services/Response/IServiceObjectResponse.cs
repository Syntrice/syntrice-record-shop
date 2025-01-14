namespace RecordShop.Services.Response
{
    public interface IServiceObjectResponse<T> : IServiceResponse
    {
        T? Value { get; set; }
    }
}
