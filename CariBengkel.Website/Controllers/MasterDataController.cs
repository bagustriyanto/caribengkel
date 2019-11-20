using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers {
    [Route ("master")]
    public class MasterDataController : Controller {
        [Route ("user")]
        public IActionResult Users () {
            return View ("User");
        }

        [Route ("role")]
        public IActionResult Role () {
            return View ();
        }

        [Route ("menu")]
        public IActionResult Menu () {
            return View ();
        }
    }
}