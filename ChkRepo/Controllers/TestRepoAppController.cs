using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChkRepo.Controllers
{
    public class TestRepoAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}