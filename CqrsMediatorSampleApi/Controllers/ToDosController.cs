using CqrsMediatorSampleApi.Commands;
using CqrsMediatorSampleApi.Models;
using CqrsMediatorSampleApi.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatorSampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GeToDos()
        {
            try
            {
                var todos = await _mediator.Send(new GetAllToDosQuery());
                return Ok(todos);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeToDo(Guid id)
        {
            try
            {
                var todos = await _mediator.Send(new GetToDoDetailQuery { Id = id });
                return Ok(todos);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(Guid id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteToDoCommand { Id = id }));
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveToDo([FromBody] CreateToDoCommand toDo)
        {
            try
            {
                return Ok(await _mediator.Send(toDo));
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo([FromBody] UpdateToDoCommand toDo, Guid id)
        {
            try
            {
                toDo.Id = id;
                return Ok(await _mediator.Send(toDo));
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}