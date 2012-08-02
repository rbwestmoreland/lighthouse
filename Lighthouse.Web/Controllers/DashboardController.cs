﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lighthouse.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        public ActionResult Default()
        {
            return View();
        }
    }
}
