namespace RecordShop.Services.Response
{
    public class ServiceObjectResponse<T> : ServiceResponse, IServiceObjectResponse<T>
    {
        public T? Value { get; set; }
        public ServiceObjectResponse(ServiceResponseType type, string? message, T? value) : base(type, message)
        {
            Value = value;
        }
    }
}
