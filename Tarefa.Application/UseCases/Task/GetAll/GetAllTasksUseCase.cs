using Tarefas.Communication.Responses;

namespace Tarefas.Application.UseCases.Task.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTaskJson Execute()
    {
        return new ResponseAllTaskJson
        {
            Tasks = new List<ResponseShortTaskJson>
            {
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Alisson",
                    Description = "Estudar para a prova de matemática."
                },

                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Maria",
                    Description = "Fazer exercícios de física."
                },

                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "João",
                    Description = "Revisar conteúdo de história."
                }
            }
        };
    }
}
