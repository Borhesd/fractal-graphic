using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HostAPI
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public object Value { get; set; }

        public Response(HttpStatusCode statusCode, object value, string message = null)
        {
            StatusCode = statusCode;
            Value = value;
            Message = message;
        }

        public Response(HttpStatusCode statusCode, string message = null)
        {
            StatusCode = statusCode;
            Value = null;
            Message = message;
        }

        public Response(object value, string message = null)
        {
            StatusCode = HttpStatusCode.OK;
            Value = value;
            Message = message;
        }

        public Response(string message)
        {
            StatusCode = HttpStatusCode.OK;
            Value = null;
            Message = message;
        }

        public Response()
        {
            StatusCode = HttpStatusCode.OK;
            Value = null;
            Message = null;
        }

    }
}
