using System;
using System.Web;

namespace Lab1.Handlers
{
    public class Task5Handler : IHttpHandler
    {
        #region Члены IHttpHandler

        private string file = "Task5page.html";
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            if (request.HttpMethod == "GET")
            {
                response.ContentType = "text/html";
                response.WriteFile(file);
            }
            else if (request.HttpMethod == "POST")
            {
                try
                {
                    int x = int.Parse(request.Params.Get("X")),y = int.Parse(request.Params.Get("Y"));

                    response.ContentType = "text/plain";
                    response.Write(x * y);
                }
                catch (Exception ex)
                {
                    response.Write(ex.Message);
                }
            }
        }

        #endregion
    }
}
