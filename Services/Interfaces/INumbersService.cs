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
}