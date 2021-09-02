namespace EasyException.Models
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public Error[] Details { get; set; }
        public InnerErrorModel InnerError { get; set; }
    }
}
