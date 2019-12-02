using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace CariBengkel.Website.Controllers {
    [Route ("[controller]")]
    public class SharedController : Controller {
        private static IHtmlLocalizer<HomeController> _localizer;
        public SharedController (IHtmlLocalizer<HomeController> localizer) {
            _localizer = localizer;
        }

        [Route ("localization")]
        [ResponseCache (Duration = 600, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Localization () {
            Response.ContentType = "application/javascript";
            var localization = _localizer.GetAllStrings ();
            string lang = "Vue.prototype.$lang";

            StringBuilder result = new StringBuilder ();
            result.AppendFormat ("{0} = new Object();", lang);

            foreach (var item in localization) {
                string val = System.Web.HttpUtility.JavaScriptStringEncode (item.Value);
                result.AppendFormat ($"{lang}.{item.Name.Replace("-","")}='{val}';");
            }

            return Content (result.ToString ());
        }

        [Route ("menu")]
        [ResponseCache (Duration = 600, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Menu () {
            Response.ContentType = "application/javascript";

            if (HttpContext.User.Identity.IsAuthenticated) {
                // get information user from session and passing to vuejs
            } else {

            }

            return Content ("");
        }
    }
}