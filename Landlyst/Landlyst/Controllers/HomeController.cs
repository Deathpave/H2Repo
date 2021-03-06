﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landlyst.Models;
using Landlyst.DataHandling;
using Landlyst.DataHandling.Managers;
using Landlyst.DataHandling.DataModel;

namespace Landlyst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Booking()
        {
            return View(HotelManager.Instance.GetRooms());
        }

        [HttpPost]
        public IActionResult Booking(string search)
        {
            return View(HotelManager.Instance.GetRooms(search));
        }

        public IActionResult ConfirmBooking(string selected)
        {
            return View(HotelManager.Instance.GetRooms(HotelManager.Instance.SplitNumbers(selected)));
        }

        public IActionResult BookingSuccess(string data, string rooms)
        {
            HotelManager.Instance.BookRooms(data, rooms);
            return View();
        }

        public IActionResult TermsofService()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (HotelManager.Instance.ConfirmUser(user.Initials, user.Password))
            {
                // editt redirect to "homepage" for the group 
                switch (HotelManager.Instance.GetUserPosition())
                {
                    case 1:
                        return RedirectToAction("Privacy", "Owners");
                    case 2:
                        return RedirectToAction("Privacy", "Receptionists");
                    case 3:
                        return RedirectToAction("Privacy", "Cleaners");
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
