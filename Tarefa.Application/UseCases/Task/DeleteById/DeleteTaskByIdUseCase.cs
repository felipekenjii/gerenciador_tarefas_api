using Tarefas.Communication.Enums;
using Tarefas.Communication.Responses;

namespace Tarefas.Application.UseCases.Task.DeleteById;

public class DeleteTaskByIdUseCase
{
    private static List<ResponseTaskJson> _tasks = new()
    {
        new ResponseTaskJson
        {
            Id = 1,
            Name = "Jefferson",
            Description = "Arrumar a casa",
            Priority = PriorityType.Medium,
            DueDate = new DateTime(2025, 12, 25),
            Status = StatusType.InProgress
        },
        new ResponseTaskJson
        {
            Id = 2,
            Name = "Maria",
            Description = "Estudar C#",
            Priority = PriorityType.High,
            DueDate = new DateTime(2025, 11, 30),
            Status = StatusType.Pending
        }
    };

    public bool Execute(int id)
    {
        var task = _tasks.Find(task => task.Id == id);

        if (task == null)
        {
            return false;
        }

        _tasks.Remove(task);

        return true;
    }
}
