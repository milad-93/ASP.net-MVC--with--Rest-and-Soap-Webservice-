using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sektion1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NotFound() // web config aktiverad alla sidor som ej finns skickas till denna vyn
        {
            return View();
        }

        /*<customErrors mode="On">
      <error statusCode = "404" redirect="~/Home/PageNotFound"/>
         </customErrors>*/
       
    }
}