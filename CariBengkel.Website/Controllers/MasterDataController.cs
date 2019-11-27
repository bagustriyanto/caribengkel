using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers {
    [Route ("system/master")]
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

        [Route ("menu-role-map")]
        public IActionResult MenuRoleMap () {
            return View ();
        }

        [Route ("user-role-map")]
        public IActionResult UserRoleMap () {
            return View ();
        }
    }
}