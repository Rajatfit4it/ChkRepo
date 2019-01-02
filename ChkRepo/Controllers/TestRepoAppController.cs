using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChkRepoBLL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChkRepo.Controllers
{
    public class TestRepoAppController : Controller
    {
        private readonly IToDoProcess _toDoProcess;
        public TestRepoAppController(IProcessFactory processFactory)
        {
            _toDoProcess = processFactory.GetProcess<IToDoProcess>();
        }

        public async Task<IActionResult> Index()
        {
            var items = await _toDoProcess.GetAllAsync();
            return View(items);
        }

    }
}