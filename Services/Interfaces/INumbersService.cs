using Data.Utility;

namespace Services.Interfaces;

public interface INumbersService
{
    public bool CheckIfNumberIsPrime(int? number);
    public int FindSumOfDigitsOfAPositiveNumber(int number);
    public int FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit(int number);
    public int FindSumOfDigitsOfAPositiveNumberUsingLINQ(int number);
    public int FindFactorialOfAPositiveNumber(int number);
    public int? FindFactorialOfAPositiveNumberUsingRecursion(int? number, int? factorialValue);
    public int FindFactorialOfAPositiveNumberUsingWhileLoop(int number);
    public int FibonacciSeriesCalculationAndDisplay(int numberOfElements);
    public int? FibonacciSeriesCalculationAndDisplayUsingRecursion(int? firstNumber, int? secondNumber, int? numberOfElements, int counter);
    public bool CheckIfNumberIsArmstrong(int? number);
    public bool CheckIfNumberIsArmstrongUsingRemainder(int? number);
    public bool NumberIsPalindrome(int? number);
    public bool NumberIsPalindromeUsingRemaider(int? number);
    public int? FindAngleBetweenClockArrows(int hours, int minutes);
    public List<int>? FindFactorsOfANumber(int? number);
    public int? FizzBuzzWordGame(int? lastNumber);
    public string? PrimeNumberStrength(int? number);
    public int? FindNthElementOfUlamSequence(int? number);
    public int? CollatzConjectureProblem(int? number);
    public string? IsNumberHarshadOrMoran(int? number);
    public bool? CheckIfNumberHasABreakpoint(int? number);
    public string? LookAndSaySequence(int? number, int? iterations);
    public int? KaprekarsConstantProblem(int? fourDigitNumber);
    public bool CheckIfNumberIsDisarium(int? number);
    public int NBonacciNumberSequenceCalculationAndDisplay(int numberOfElements, int numberOfTerms);
    public bool CheckIfNumberIsGapful(int? number);
    public bool CheckIfNumberIsAlternating(int? number);
    public int NumberPersistenceProblem(NumberPersistence? persistenceType, int? number);
    public bool CheckIfNumberIsPronic(int? number);
    public bool CheckIfNumberIsPandigital(int? number);
    public bool CheckIfNumberIsPandigitalUsingLINQ(int? number);
    public bool CheckIfNumberIsSlidey(int? number);
}