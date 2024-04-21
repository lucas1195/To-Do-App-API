using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using todo_API.DTOs;
using todo_API.Models;

namespace todo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly Contexto _context;

        public TaskController(Contexto context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Models.Task> GetAll()
        {
            return _context.Task.ToList();

        }

        [HttpPost("UpdateTask")]
        public Models.Task UpdateTask([FromBody] TaskDTO taskModified)
        {
            try
            {
                var taskBanco = _context.Task.FirstOrDefault(x => x.IdTask == taskModified.IdTask);

                if (taskBanco == null)
                {
                    throw new InvalidOperationException($"Task de ID [{taskModified.IdTask}] não pode ser encontrado.");
                }

                taskBanco.TituloTask = taskModified.TituloTask;
                taskBanco.DescricaoTask = taskModified.DescricaoTask;
                taskBanco.Prioridade = taskModified.Prioridade;


                _context.Task.Update(taskBanco);
                _context.SaveChanges();

                return taskBanco;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar a Task. {ex.Message}");
            }

        }

        [HttpDelete("DeleteTask/{IdTask}")]
        public ActionResult DeleteTask([FromRoute] int IdTask)
        {
            try
            {
                var taskBanco = _context.Task.FirstOrDefault(x => x.IdTask == IdTask);

                if (taskBanco == null)
                {
                    throw new InvalidOperationException($"Task de ID [{IdTask}] não pode ser encontrada.");
                }

                _context.Task.Remove(taskBanco);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao remover a Task. {ex.Message}");
            }

        }

        [HttpPost("InsertTask")]
        public ActionResult InsertTask([FromBody] TaskDTO taskParametros)
        {
            try
            {
                var novaTask = new Models.Task
                {
                    TituloTask = taskParametros.TituloTask,
                    DescricaoTask = taskParametros.DescricaoTask,
                    DataVencimento = taskParametros.DataVencimento,
                    Prioridade = taskParametros.Prioridade,
                    DataInicio = DateTime.Now,
                    IsCompleted = false
                };

                _context.Task.Add(novaTask);
                _context.SaveChanges();

                return Ok(novaTask);

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir a nova Task. {ex.Message}");
            }

        }
    }
}
