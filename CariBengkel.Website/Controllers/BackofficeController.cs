using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers {
    public class BackofficeController : Controller {
        public IActionResult Index () {
            if (HttpContext.User.Identity.IsAuthenticated) {
                return View ();
            } else {
                return Redirect ("/login");
            }
        }
    }
}