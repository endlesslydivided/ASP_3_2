using System;
using System.Web;

namespace Lab1.Handlers
{
    public class Task6Handler : IHttpHandler
    {
        #region Члены IHttpHandler

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            if(request.HttpMethod == "GET")
            {
                response.ContentType = "text/html";
                response.WriteFile("form6.html");
            }
            else if (request.HttpMethod =="POST")
            {
                try
                {
                    int x = int.Parse(request.Form.Get("x")),
                        y = int.Parse(request.Form.Get("y"));

                    response.ContentType = "text/plain";
                    response.Write(x * y);
                }
                catch(Exception ex)
                {
                    response.Write(ex.Message);
                }
            }
        }

        #endregion
    }
}
