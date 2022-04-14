using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab5b.Controllers
{
    public class СHResearchController : Controller
    {
        static DateTime date = DateTime.Now;

        [HttpGet]
        [Route("CHResearch/AD")]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 5)]
        public string AD()
        {
            date = DateTime.Now;
            return $"{date}";
        }

        [HttpPost]
        [Route("CHResearch/AP")]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 7, VaryByParam = "x;y")]
        public ActionResult AP()
        {
            var x = Request.QueryString.Get("x");
            var y = Request.QueryString.Get("y");

            date = DateTime.Now;
            return Content($"{date}: {x} - {y}");
        }
    }
}