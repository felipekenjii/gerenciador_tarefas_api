using Microsoft.AspNetCore.Mvc;
using Tarefas.Application.UseCases.Task.CreateTask;
using Tarefas.Application.UseCases.Task.DeleteById;
using Tarefas.Application.UseCases.Task.GetAll;
using Tarefas.Application.UseCases.Task.GetById;
using Tarefas.Application.UseCases.Task.Update;
using Tarefas.Communication.Requests;
using Tarefas.Communication.Responses;

namespace Tarefas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    // HTTP Post (Criar tarefa)
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult CreateTask([FromBody] RequestTaskJson request)
    {
        var useCase = new CreateTaskUseCase();

        var (response, errors) = useCase.Execute(request);

        if (response == null)
        {
            return BadRequest(new ResponseErrorsJson { Errors = errors });
        }

        return Created(string.Empty, response);
    }

    // HTTP Get (Apresentar todas as tarefas)
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase();

        var response = useCase.Execute();

        if (response.Tasks.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    // HTTP Get (Apresentar tarefa por ID)
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var useCase = new GetTaskByIdUseCase();

        var response = useCase.Execute(id);

        if (response == null)
        {
            var error = new ResponseErrorsJson
            {
                Errors = new List<string>
                {
                    $"Tarefa com ID {id} não foi encontrada."
                }
            };

            return NotFound(error);
        }

        return Ok(response);
    }

    // HTTP Put (Atualizar uma tarefa por ID)
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();

        var response = useCase.Execute(id, request);

        if(response == false)
        {
            var error = new ResponseErrorsJson
            {
                Errors = new List<string>
                {
                    $"Tarefa com ID {id} não foi encontrada."
                }
            };

            return NotFound(error);
        }

        return NoContent();
    }

    // HTTP Delete (Deletar tarefa por ID)
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var useCase = new DeleteTaskByIdUseCase();

        var response = useCase.Execute(id);

        if (response == false)
        {
            var error = new ResponseErrorsJson
            {
                Errors = new List<string>
                {
                    $"Tarefa com ID {id} não foi encontrada."
                }
            };

            return NotFound(error);
        }

        return NoContent();
    }
}