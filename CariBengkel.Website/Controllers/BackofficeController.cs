using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers {
    [Route ("system")]
    public class BackofficeController : Controller {
        public IActionResult Index () {
            return View ();
        }

    }
}