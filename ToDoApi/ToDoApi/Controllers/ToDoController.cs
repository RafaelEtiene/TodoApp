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
        public async Task<List<TaskToDo>> GetAllTasks()
        {
            try
            {
                var tasks = await _context.Task.Select(e => e).ToListAsync();
                return tasks;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        [HttpGet("GetTaskByUser/{idUser}", Name = "GetTaskByUser")]
        public async Task<List<TaskToDo>> GetTaskById(int idUser)
        {
            try
            {
                var tasks = await _context.Task.Where(i => i.idUser == idUser).Select(e => e).ToListAsync();
                return tasks;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost("InsertTask", Name = "InsertTask")]
        public async Task<TaskToDo> InsertTask([FromBody]TaskToDo task)
        {
            try
            {
                var add = _context.Task.Add(task);

                await _context.SaveChangesAsync();
                return task;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("DeleteTask", Name = "DeleteTask")]
        public async Task<IActionResult> DeleteTask(int idTask)
        {
            try
            {
                TaskToDo task = await _context.Task.Where(t => t.idTask == idTask).Select(e => e).FirstAsync();
                if (task == null)
                    return NotFound();

                var remove = _context.Task.Remove(task);

                await _context.SaveChangesAsync();
                return Ok();
                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}