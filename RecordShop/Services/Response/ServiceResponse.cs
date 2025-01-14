namespace RecordShop.Services.Response
{
    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponseType ResponseType { get; }
        public string? Message { get; }

        public ServiceResponse(ServiceResponseType type, string? message)
        {
            ResponseType = type;
            Message = message;
        }
    }


}
