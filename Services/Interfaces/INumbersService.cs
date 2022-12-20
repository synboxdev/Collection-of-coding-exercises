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
}