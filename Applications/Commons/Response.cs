using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Applications.Commons
{
    public class Response
    {
        private readonly HttpStatusCode _status;
        public int? StatusCode { get =>(int?) _status; }
        public string Status { get => _status.ToString(); }
        public string Message { get; set; }
        public object Result { get; set; }

        public Response(HttpStatusCode status, string message, object result)
        {
            this._status = status;
            this.Message = message;
            this.Result = result;
        }
        public Response(HttpStatusCode status, string message)
        {
            this._status = status;
            this.Message = message;
        }
    }
}
