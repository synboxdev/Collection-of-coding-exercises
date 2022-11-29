using Data.Models.AppSettings.Collection;
using Data.Models.UserInput;

namespace Services;

public interface ICommandService
{
    public void Run();
    public bool TryParsingUserInput();
    public bool? TryExecutingInputCommand(InputCommand inputCommand);
    public bool? ExecuteHelpCommand(string? helpCommand);
    public bool? CallServiceMethod(Category? category, string? methodName);
    public object? GetServiceByCategoryName(Category? category);
}