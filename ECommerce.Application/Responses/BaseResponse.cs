namespace ECommerce.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse() => Success = true;

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; } = default!;
        public string Message { get; set; } = default!;

        public List<string>? ValidationsErrors { get; set; } = default!;
    }
}
