﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolarMag.com.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Les hivers vs les panneaux solaire, est-ce fonctionnel ?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Vous pouvez nous joindre facilement";

            return View();
        }
    }
}