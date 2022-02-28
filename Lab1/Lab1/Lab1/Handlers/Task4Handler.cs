using System;
using System.Web;

namespace Lab1.Handlers
{
    public class Task4Handler : IHttpHandler
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

            if (request.HttpMethod == "GET")
            {
                response.ContentType = "text/html";
                response.WriteFile("form4.html");
            }
            else if (request.HttpMethod == "POST")
            {
                try
                {
                    int x = int.Parse(request.Form.Get("X")), y = int.Parse(request.Form.Get("Y"));

                    response.ContentType = "text/plain";
                    response.Write($"X = {x}, Y = {y}, sum = {x + y}");
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
