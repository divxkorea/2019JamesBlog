using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JamesBlog.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}