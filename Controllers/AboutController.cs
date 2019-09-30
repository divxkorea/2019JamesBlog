using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JamesBlog.Controllers
{
    [Route("About")]
    public class AboutController : Controller
    {
       
        [Route("Me")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}