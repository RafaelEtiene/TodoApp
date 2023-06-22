using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using ToDoApi.Data;
using ToDoApi.Model;

namespace ToDoApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContextDb _context = new ToDoContextDb();

        [HttpGet("GetAllTasks", Name = "GetAllTasks")]
        public List<TaskToDo> GetAllTasks()
        {
            try
            {
                List<TaskToDo> tasks = new List<TaskToDo>();
                var task = _context.Task.Select(e => e).ToList();
                return task;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        [HttpGet("GetTaskByUser", Name = "GetTaskByUser")]
        public List<TaskToDo> GetTaskById(int idUser)
        {
            try
            {
                List<TaskToDo> tasks = new List<TaskToDo>();
                var task = _context.Task.Where(i => i.idUser == idUser).Select(e => e).ToList();
                Console.WriteLine("legal");
                return task;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}