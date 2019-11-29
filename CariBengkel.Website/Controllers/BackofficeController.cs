using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers {
    [Authorize (AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route ("system")]
    public class BackofficeController : Controller {
        public IActionResult Index () {
            return View ();
        }

    }
}