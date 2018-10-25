using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChkRepoBLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace ChkRepo.Controllers
{
    [Produces("application/json")]
    [Route("api/test")]
    public class TestRepoServiceController : Controller
    {
        private readonly IToDoProcess _toDoProcess;
        public TestRepoServiceController(IToDoProcess toDoProcess)
        {
            _toDoProcess = toDoProcess;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_toDoProcess.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            var result = _toDoProcess.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create([FromBody]TodoItemVM item)
        {
            var result = _toDoProcess.Add(item);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]TodoItemVM item)
        {
            var result = _toDoProcess.Update(id, item);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _toDoProcess.Delete(id);
            if (!result)
                return NotFound();
            return Ok();
        }

    }
}