using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            Response.StatusCode = 404;
            ViewBag.message = Server.GetLastError() == null ? "" : Server.GetLastError().Message;
            ViewBag.uri = Request.QueryString.Get("aspxerrorpath");
            ViewBag.method = Request.HttpMethod;

            return View();
        }
    }
}