using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers {
    public class AuthenticationController : Controller {
        [Route ("Login")]
        public IActionResult Login () {
            return View ();
        }

        [Route ("Register")]
        public IActionResult Register () {
            return View ();
        }

        [Route ("Forgot")]
        public IActionResult ForgotPassword () {
            return View ();
        }

        [Route ("Reset")]
        public IActionResult ResetPassword () {
            return View ();
        }
    }
}