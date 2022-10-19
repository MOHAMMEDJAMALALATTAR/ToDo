using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Controllers;
using ToDoList.Core.Managers.Interfaces;
using ToDoList.ViewModels.ViewModels;

namespace ToDoList.Controllers
{
    [ApiController]
    [Authorize]
    public class ToDoListController : BaseApi
    {
        private readonly IToDoListTask _toDoTask;
        public ToDoListController(IToDoListTask toDoTask)
        {
            _toDoTask = toDoTask;
        }

        [HttpGet]
        [Route("api/ToDoListTask/GetTasks")]
        public IActionResult GetTasks(int page = 1,
                                     int pageSize = 10,
                                     string sortColumn = "",
                                     string sortDirection = "ascending",
                                     string searchText = "")
        {
            var result = _toDoTask.GetTasks(page, pageSize, sortColumn, sortDirection, searchText);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/ToDoListTask/GetTaskById/{id}")]
        public IActionResult GetTaskById(int id)
        {
            var result = _toDoTask.GetTaskById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/ToDoListTask/AddTask")]
        public IActionResult AddTask(ToDoListRequest toDoRequest)
        {
            var result = _toDoTask.AddTask(TokenUser, toDoRequest);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/ToDoListTask/UpdateTask")]
        public IActionResult UpdateTask(ToDoListRequest toDoRequest)
        {
            var result = _toDoTask.UpdateTask(TokenUser, toDoRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/ToDoListTask/DeleteTask")]
        public IActionResult DeleteTask(int id)
        {
            _toDoTask.DeleteTask(id);
            return Ok();
        }
    }
}
