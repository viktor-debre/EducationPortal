﻿using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EducationPortal.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserInformationService _userInformation;

        public HomeController(ILogger<HomeController> logger, IUserInformationService userInformation)
        {
            _logger = logger;
            _userInformation = userInformation;
        }

        public IActionResult Index()
        {
            return View(_userInformation.GetUserInfo("Viktor"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UserProfile()
        {
            return View(_userInformation.GetUserInfo("Viktor"));
        }
    }
}