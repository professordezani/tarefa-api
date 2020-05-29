using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.Models;
using TarefasBackEnd.Repositories;
using System;
using Microsoft.AspNetCore.Authorization;

namespace TarefasBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        // [AllowAnonymous]
        public IActionResult Read([FromServices]ITarefaRepository repository) 
        { 
            var id = new Guid(User.Identity.Name);
            var tarefas = repository.Read(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Tarefa model, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            model.UsuarioId = new Guid(User.Identity.Name);

            repository.Create(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]Tarefa model, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();                
                
            repository.Update(new Guid(id), model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices]ITarefaRepository repository)
        {       
            repository.Delete(new Guid(id));
            return Ok();
        }
    }
}