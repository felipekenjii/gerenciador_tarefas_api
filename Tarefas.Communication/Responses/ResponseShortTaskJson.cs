using Tarefas.Communication.Enums;

namespace Tarefas.Communication.Responses;

public class ResponseShortTaskJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
