namespace RecordShop.Services.Response
{
    public interface IServiceResponse
    {
        ServiceResponseType ResponseType { get; }
        string? Message { get; }
    }
}
