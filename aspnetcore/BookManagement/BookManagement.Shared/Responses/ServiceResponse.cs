using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Shared.Responses
{
    public abstract class ServiceResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public ServiceResponse(HttpStatusCode statusCode, object result) 
        {
            this.StatusCode = statusCode;
            this.Result = result;
        }
    }
    public class OkResponse(object result) : ServiceResponse(HttpStatusCode.OK,result);
    public class FailResponse(string message) : ServiceResponse(HttpStatusCode.InternalServerError,message);
}
