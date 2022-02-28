using System;
using System.Web;

namespace Lab1.Handlers
{
    public class Task1Handler : IHttpHandler
    {
        #region Члены IHttpHandler

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            response.ContentType = "text/plain";
            response.Write($"GET-Http-KAA: ParmA = {request.QueryString.Get("ParmA")}, ParmB = {request.QueryString.Get("ParmB")}");
        }

        #endregion
    }
}
