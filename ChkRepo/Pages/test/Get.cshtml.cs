using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChkRepoBLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModel;

namespace ChkRepo.Pages.test
{
    public class GetModel : PageModel
    {
        private readonly IToDoProcess _toDoProcess;
        public List<TodoItemVM> list;
        public GetModel(IToDoProcess toDoProcess)
        {
            _toDoProcess = toDoProcess;
        }

        public void OnGet()
        {
            list = _toDoProcess.GetAll();
        }
    }
}