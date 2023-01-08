using Data.Models.AppSettings;
using Data.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Services;
using Services.Interfaces;

namespace Tests;

public class CommandServiceTests
{
    private readonly IOptions<AppSettings> _options;
    private readonly ILogger<CommandService> _logger;
    private readonly IStringsService _stringsService;
    private readonly INumbersService _numbersService;
    private readonly IArraysService _arraysService;
    private readonly IDataStructuresService _dataStructuresService;

    private readonly CommandService commandService;

    public CommandServiceTests()
    {
        _options = Mock.Of<IOptions<AppSettings>>();
        _logger = Mock.Of<ILogger<CommandService>>();
        _stringsService = Mock.Of<IStringsService>();
        _numbersService = Mock.Of<INumbersService>();
        _arraysService = Mock.Of<IArraysService>();
        _dataStructuresService = Mock.Of<IDataStructuresService>();

        commandService = new CommandService(_options,
                                            _logger,
                                            _stringsService,
                                            _numbersService,
                                            _arraysService,
                                            _dataStructuresService);
    }

    [Fact]
    public void TryExecutingInputCommand_TryExecutingNullInputCommand_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.TryExecutingInputCommand(null));
    }

    [Fact]
    public void TryExecutingInputCommand_TryExecutingNewInstanceOfInputCommand_ThrowsNullReferenceException()
    {
        // Arrange, Act & Assert
        Assert.Throws<NullReferenceException>(() =>
            commandService.TryExecutingInputCommand(new Data.Models.UserInput.InputCommand()));
    }

    [Fact]
    public void ExecuteHelpCommand_TryExecutingNullHelpCommand_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.ExecuteHelpCommand(null));
    }

    [Fact]
    public void ExecuteHelpCommand_TryExecutingNonExistantHelpCommand_ReturnsTrue()
    {
        // Arrange, Act & Assert
        Assert.True(commandService.ExecuteHelpCommand("Pizza"));
    }

    [Fact]
    public void ExecuteHelpCommand_TryExecutingQuitHelpCommand_ReturnsFalse()
    {
        // Arrange, Act & Assert
        Assert.False(commandService.ExecuteHelpCommand(HelpCommandName.Quit));
    }

    [Fact]
    public void CallServiceMethod_CallServiceMethodWithNullCategory_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.CallServiceMethod(null, "Pizza"));
    }

    [Fact]
    public void CallServiceMethod_CallServiceMethodWithNullMethodName_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.CallServiceMethod(new Data.Models.AppSettings.Collection.Category(), null));
    }

    [Fact]
    public void CallServiceMethod_CallServiceMethodWithNullParameters_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.CallServiceMethod(null, null));
    }

    [Fact]
    public void CallServiceMethod_CallServiceMethodWithValidParameters_ReturnsTrue()
    {
        // Arrange, Act & Assert
        Assert.True(commandService.CallServiceMethod(
            new Data.Models.AppSettings.Collection.Category()
            {
                Name = CategoryName.Strings
            }, "ReverseAString"));
    }

    [Fact]
    public void GetServiceByCategoryName_GetServiceByNullCategoryObject_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.GetServiceByCategoryName(null));
    }

    [Fact]
    public void GetServiceByCategoryName_GetServiceByCategoryWithoutName_ReturnsNull()
    {
        // Arrange, Act & Assert
        Assert.Null(commandService.GetServiceByCategoryName(new Data.Models.AppSettings.Collection.Category() { Name = null }));
    }

    [Fact]
    public void GetServiceByCategoryName_GetServiceByCategoryWithValidCategory_ReturnsNotNull()
    {
        // Arrange, Act & Assert
        Assert.NotNull(commandService.GetServiceByCategoryName(new Data.Models.AppSettings.Collection.Category() { Name = CategoryName.Strings }));
    }
}