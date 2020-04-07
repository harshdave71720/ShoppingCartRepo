using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Net;

namespace ShoppingSystemWebAPI.Filters
{
    public class ApiExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var request = actionExecutedContext.ActionContext.Request;
            var respone = request.CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message);
            //var response = new HttpResponseMessage();
            actionExecutedContext.Response = respone;
            //base.OnException(actionExecutedContext);
        }
    }
}