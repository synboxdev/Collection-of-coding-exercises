using Data.Models.AppSettings;
using Data.Models.AppSettings.Collection;
using Data.Models.UserInput;
using Data.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using Services.Utility;
using System.Reflection;

namespace Services;

public class CommandService : ICommandService
{
    private readonly AppSettings _options;
    private readonly ILogger<CommandService> _logger;
    private readonly IStringsService _stringsService;
    private readonly INumbersService _numbersService;
    private readonly IArraysService _arraysService;
    private readonly IDataStructuresService _dataStructuresService;

    public CommandService(IOptions<AppSettings> options,
                          ILogger<CommandService> logger,
                          IStringsService stringsService,
                          INumbersService numbersService,
                          IArraysService arraysService,
                          IDataStructuresService dataStructuresService)
    {
        _logger = logger;
        _options = options.Value;
        _stringsService = stringsService;
        _numbersService = numbersService;
        _arraysService = arraysService;
        _dataStructuresService = dataStructuresService;
    }

    /// <summary>
    /// Method which acts as the entry and exit point of the application. Announced start and end times, and continually calls TryParsingUserInput method, until it returns FALSE boolean value.
    /// </summary>
    public void Run()
    {
        StartAndExit(true);
        while (true)
        {
            if (!TryParsingUserInput())
            {
                StartAndExit(false);
                break;
            }
        }
    }

    /// <summary>
    /// Method which continually (until the application is stopped) requests user for input, attempts to parse and execute the user input.
    /// </summary>
    /// <returns>TRUE if method should be re-called, due to invalid input, or after user input was successfully executed. FALSE if application should be stopped.</returns>
    public bool TryParsingUserInput()
    {
        Console.WriteLine("Provide some input..");
        // Read user input, remove all non-alphanumeric characters. If cleared user input is null or empty - call helper method.
        string? userInput = Console.ReadLine()?.ToAlphaNumeric();

        if (string.IsNullOrEmpty(userInput))
        {
            _logger.LogInformation($"Input was either invalid or empty.");
            return (bool)ExecuteHelpCommand("help");
        }

        // Try forming a user input command from somewhat parsed user input.
        InputCommand inputCommand;
        try
        {
            inputCommand = new InputCommand()
            {
                MainCommand = userInput.Split("-")[0].ToLower(),
                ExerciseSolutionIndexes = userInput.Split('-').Skip(1).Select(x => Convert.ToInt32(x)).ToArray()
            };
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to parse user input. Exception: {ex.Message}");
            return true;
        }

        // Try executing the input command.
        return (bool)TryExecutingInputCommand(inputCommand);
    }

    /// <summary>
    /// Method which attempts to execute input command which was formed from user input.
    /// </summary>
    /// <param name="inputCommand">Formed input command which consists of MainCommand and CollectionIndexes</param>
    /// <returns>TRUE if command was successfully executed and method called. FALSE if application should be stopped.</returns>
    public bool? TryExecutingInputCommand(InputCommand inputCommand)
    {
        if (inputCommand == null)
        {
            _logger.LogError("Input command may not be null!");
            return null;
        }

        if (_options.HelpCommandCollection.HelpCommands.Any(x => x.Name == inputCommand.MainCommand))
            return (bool)ExecuteHelpCommand(inputCommand.MainCommand);

        try
        {
            var exerciseCollectionEntry = _options.ExerciseCollection?.Categories?
                                            .FirstOrDefault(x => x.Name == inputCommand.MainCommand)?
                                            .Exercises?[inputCommand.ExerciseSolutionIndexes[0] - 1]?
                                            .Solutions?[inputCommand.ExerciseSolutionIndexes[1] - 1];

            if (exerciseCollectionEntry != null)
                return (bool)CallServiceMethod(_options.ExerciseCollection.Categories.FirstOrDefault(x => x.Name == inputCommand.MainCommand), exerciseCollectionEntry.MethodName);
            else
            {
                _logger.LogError($"Invalid input command! Refer to [{HelpCommandName.List}] and [{HelpCommandName.How}] help commands!");
                return true;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError($"Unable to execute input command. Exception: {ex.Message}");
            _logger.LogInformation($"Refer to [{HelpCommandName.List}] and [{HelpCommandName.How}] help commands!");
            return true;
        }
    }

    /// <summary>
    /// Method which executes a help command
    /// </summary>
    /// <param name="helpCommand">Help command which indicated that a 'helper' method should be executed.</param>
    /// <returns>TRUE if helper method was successfully executed and called. FALSE if application should be stopped.</returns>
    public bool? ExecuteHelpCommand(string? helpCommand)
    {
        if (string.IsNullOrEmpty(helpCommand))
        {
            _logger.LogError("Help command may not be null!");
            return null;
        }

        _logger.LogInformation($"\n[{helpCommand}] has been called.");
        switch (helpCommand)
        {
            case HelpCommandName.Help:
                {
                    Console.WriteLine("Listing all available help commands and their descriptions:");
                    _options.HelpCommandCollection.HelpCommands.ForEach(x =>
                        Console.WriteLine($"\t[{x.Name}]\t{x.Description}"));
                    break;
                }
            case HelpCommandName.Quit:
                {
                    return false;
                }
            case HelpCommandName.List:
                {
                    Console.WriteLine($"Project currently contains " +
                                      $"[{_options.ExerciseCollection.Categories.Sum(x => x.Exercises.Sum(e => e.Solutions.Count))}] solutions, " +
                                      $"to [{_options.ExerciseCollection.Categories.Sum(x => x.Exercises.Count)}] of exercises " +
                                      $"in [{_options.ExerciseCollection.Categories.Count}] different categories!");
                    Console.WriteLine($"Listing all available exercise collection selections that you can invoke:");
                    foreach (Category category in _options.ExerciseCollection.Categories)
                    {
                        Console.WriteLine($"Category [{category.Name}] has the following exercises:");
                        foreach (Exercise exercise in category.Exercises)
                        {
                            Console.WriteLine($"\t#{category.Exercises.IndexOf(exercise) + 1} - " +
                                                   $"Exercise [{exercise.Description}] has the following solutions:");
                            foreach (Solution solution in exercise.Solutions)
                            {
                                Console.WriteLine($"\t\t#{exercise.Solutions.IndexOf(solution) + 1} - " +
                                                       $"{solution.Description}");
                            }
                        }
                        Console.WriteLine();
                    }
                    break;
                }
            case HelpCommandName.How:
                {
                    Console.WriteLine(
                        $"You can call any solution, of any exercise displayed in [{HelpCommandName.List}] by typing the following:\n" +
                         "CategoryName -ListIndexOfExercise -ListIndexOfSolution\n" +
                         "For example: 'strings -1 -2' Will yield you 'strings' category, Exercise #1, Solution #2");
                    break;
                }
            case HelpCommandName.Clear:
                {
                    Console.Clear(); break;
                }
            default:
                {
                    _logger.LogError($"No such command exists. :(");
                    break;
                }
        }
        return true;
    }

    /// <summary>
    /// Method that attempts to call a specific service's method via reflection.
    /// </summary>
    /// <param name="category">A specific category whose method should be called.</param>
    /// <param name="methodName">Name of the method that should be called via reflection.</param>
    public bool? CallServiceMethod(Category? category, string? methodName)
    {
        if (category == null || string.IsNullOrEmpty(methodName))
        {
            _logger.LogError("Category and method name must be provided!");
            return null;
        }

        object serviceObject = GetServiceByCategoryName(category);

        if (serviceObject != null)
        {
            MethodInfo? methodInfo = serviceObject.GetType().GetMethod(methodName);
            methodInfo.Invoke(serviceObject, new object[methodInfo.GetParameters().Count()]);
        }
        else
        {
            _logger.LogError($"Input command was valid, but no such solution exists.");
            _logger.LogInformation($"Refer to [{HelpCommandName.List}] and [{HelpCommandName.How}] help commands!");
        }

        return true;
    }

    /// <summary>
    /// Method which returns a service for a given category.
    /// </summary>
    /// <param name="category">Category class object, which should include Name variable, by which a valid Service will be returned.</param>
    /// <returns>A valid service based on a given category, which contains all exercises and solution of that category.</returns>
    public object? GetServiceByCategoryName(Category? category)
    {
        if (category == null) return null;

        switch (category.Name)
        {
            case CategoryName.Strings:
                return _stringsService;
            case CategoryName.Numbers:
                return _numbersService;
            case CategoryName.Arrays:
                return _arraysService;
            case CategoryName.DataStructures:
                return _dataStructuresService;
            default: return null;
        }
    }

    private void StartAndExit(bool IsStarting)
    {
        Console.WriteLine($"Application is {(IsStarting ? "starting" : "exiting")} at {DateTime.Now}");

        if (IsStarting)
        {
            Console.WriteLine("As you may already tell, this is a command-line based project, which a collection of solutions, " +
                "to a variety of different exercises in different subjects/areas that one might encounter during an " +
                "exam, technical interview or perhaps in pursuit of some extra programming practice.");
        }
        else
            Console.WriteLine("Thank you for using the project. Farewell!");
    }
}