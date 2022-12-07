namespace Services.Interfaces;

public interface INumbersService
{
    public bool CheckIfNumberIsPrime(int? number);
    public int FindSumOfDigitsOfAPositiveNumber(int number);
    public int FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit(int number);
    public int FindSumOfDigitsOfAPositiveNumberUsingLINQ(int number);
}