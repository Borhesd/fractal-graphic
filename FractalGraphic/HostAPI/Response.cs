
namespace HostAPI
{
    public class Response
    {
        public string Message { get; set; }
        public object Value { get; set; }

        public Response(object value, string message = null)
        {
            Value = value;
            Message = message;
        }

        public Response(string message)
        {
            Value = null;
            Message = message;
        }

        public Response()
        {
            Value = null;
            Message = null;
        }

    }
}
