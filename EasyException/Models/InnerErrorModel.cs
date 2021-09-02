namespace EasyException.Models
{
    public class InnerErrorModel
    {
        public string Code { get; set; }
        public InnerErrorModel InnerError { get; set; }

    }
}
