using Tarefas.Communication.Enums;
using Tarefas.Communication.Requests;
using Tarefas.Communication.Responses;

namespace Tarefas.Application.UseCases.Task.CreateTask;

public class CreateTaskUseCase
{
    public (ResponseCreatedTaskJson, List<string> errors) Execute(RequestTaskJson request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            errors.Add("O nome não pode ser vazio.");
        }
        if (request.Name.Length > 100)
        {
            errors.Add("O nome deve ter no máximo 100 caracteres.");
        }
        if (request.Description.Length > 500)
        {
            errors.Add("A descrição deve ter no máximo 500 caracteres.");
        }
        if (request.DueDate <= DateTime.Now)
        {
            errors.Add("A data não pode estar no passado.");
        }
        if (!Enum.IsDefined(typeof(PriorityType), request.Priority))
        {
            errors.Add("Prioridade inválida.");
        }
        if (!Enum.IsDefined(typeof(StatusType), request.Status))
        {
            errors.Add("Status inválido.");
        }

        if (errors.Any())
        {
            return (null, errors);
        }

        var newTask = new ResponseCreatedTaskJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = request.Status
        };

        return (newTask, errors);
    }
}