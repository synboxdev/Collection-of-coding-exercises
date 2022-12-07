using Services;
using Services.Interfaces;

namespace Tests;

public class NumbersServiceTests
{
    private readonly NumbersService numbersService;

    public NumbersServiceTests()
    {
        numbersService = new NumbersService();
    }

    [Fact]
    public void CheckIfNumberIsPrime_CheckIfNumberIsPrimeWithNOTPrimeNumber_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsPrime(6));
    }

    [Fact]
    public void CheckIfNumberIsPrime_CheckIfNumberIsPrimeWithAPrimeNumber_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsPrime(29));
    }

    [Fact]
    public void FindSumOfDigitsOfAPositiveNumber_FindSumOfDigitsOfAPositiveNumberWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(9, numbersService.FindSumOfDigitsOfAPositiveNumber(18));
    }

    [Fact]
    public void FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit_FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigitWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(2, numbersService.FindSumOfDigitsOfAPositiveNumberParsingThroughEveryDigit(11));
    }

    [Fact]
    public void FindSumOfDigitsOfAPositiveNumberUsingLINQ_FindSumOfDigitsOfAPositiveNumberUsingLINQWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(10, numbersService.FindSumOfDigitsOfAPositiveNumberUsingLINQ(91));
    }

    [Fact]
    public void FindFactorialOfAPositiveNumber_FindFactorialOfAPositiveNumberWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(120, numbersService.FindFactorialOfAPositiveNumber(5));
    }

    [Fact]
    public void FindFactorialOfAPositiveNumberUsingRecursion_FindFactorialOfAPositiveNumberUsingRecursionWithValidParameter_ExitsRecursionAndReturnsNull()
    {
        Assert.Null(numbersService.FindFactorialOfAPositiveNumberUsingRecursion(null, null));
    }

    [Fact]
    public void FindFactorialOfAPositiveNumberUsingWhileLoop_FindSumOfDigitsOfAPositiveNumberUsingLINQWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(362880, numbersService.FindFactorialOfAPositiveNumberUsingWhileLoop(9));
    }
}