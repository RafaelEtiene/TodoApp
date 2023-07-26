using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;
using ToDoApi.Data;
using ToDoApi.Model;

namespace ToDoApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContextDb _context = new ToDoContextDb();
        [Authorize]
        [HttpGet("GetAllTasks")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _context.Task.Select(e => e).ToListAsync();
                return Ok(tasks);
            }
            catch(Exception e)
            {
                return BadRequest(new Exception(e.Message));
            }
            
        }

        [HttpGet("GetTaskById/{idTask}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTaskById(int idTask)
        {
            try
            {
                var todoTask = await _context.Task.Where(i => i.idTask == idTask).Select(e => e).FirstAsync(); ;
                return Ok(todoTask);
            }
            catch (Exception e)
            {
                return BadRequest(new Exception(e.Message));
            }

        }

        [HttpPost("InsertTask")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertTask([FromBody]TaskToDo task)
        {
            try
            {
                var add = _context.Task.Add(task);

                await _context.SaveChangesAsync();
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest(new Exception(e.Message));
            }
        }

        [HttpPut("UpdateTask/{idTask}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateTask([FromBody] TaskToDo task, int idTask)
        {
            try
            {
                TaskToDo? taskUpdate = await _context.Task.FindAsync(idTask);
                if (taskUpdate == null)
                    return NotFound();

                taskUpdate.description = task.description;
                taskUpdate.date = task.date;
                taskUpdate.check = task.check;

                await _context.SaveChangesAsync();
                return Ok(taskUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(new Exception(e.Message));
            }
        }

        [HttpDelete("DeleteTask")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.NotFound)]

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
                return BadRequest(new Exception(e.Message));
            }
        }

    }
}