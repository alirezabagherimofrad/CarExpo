namespace CarExpo.ApiResponse
{
    public class ApiResponse
    {
        public string? Message { get; set; }
        public object? Content { get; set; }
        public ApiResponse(string message)
        {
            Message = message;
        }
        public ApiResponse(object content)
        {
            Content = content;
        }
        public ApiResponse(string message, object content)
        {
            Message = message;
            Content = content;
        }
    }
}
