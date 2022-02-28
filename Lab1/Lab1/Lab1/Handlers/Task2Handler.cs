using System;
using System.Web;

namespace Lab1.Handlers
{
    public class Task2Handler : IHttpHandler
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
            response.Write($"POST-Http-KAA: ParmA = {request.Form.Get("ParmA")}, ParmB = {request.Form.Get("ParmB")}");
        }

        #endregion
    }
}
