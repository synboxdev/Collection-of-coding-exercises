using Services;

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

    [Fact]
    public void FibonacciSeriesCalculationAndDisplay_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(8, numbersService.FibonacciSeriesCalculationAndDisplay(6));
    }

    [Fact]
    public void CheckIfNumberIsArmstrong_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsArmstrong(371));
    }

    [Fact]
    public void CheckIfNumberIsArmstrong_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsArmstrong(333));
    }

    [Fact]
    public void CheckIfNumberIsArmstrongUsingRemainder_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.CheckIfNumberIsArmstrongUsingRemainder(371));
    }

    [Fact]
    public void CheckIfNumberIsArmstrongUsingRemainder_FibonacciSeriesCalculationAndDisplayWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.CheckIfNumberIsArmstrongUsingRemainder(333));
    }

    [Fact]
    public void NumberIsPalindrome_NumberIsPalindromeWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.NumberIsPalindrome(636));
    }

    [Fact]
    public void NumberIsPalindrome_NumberIsPalindromeWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.NumberIsPalindrome(123));
    }

    [Fact]
    public void NumberIsPalindromeUsingRemaider_NumberIsPalindromeUsingRemaiderWithValidParameter_ReturnsTrue()
    {
        Assert.True(numbersService.NumberIsPalindromeUsingRemaider(636));
    }

    [Fact]
    public void NumberIsPalindromeUsingRemaider_NumberIsPalindromeUsingRemaiderWithValidParameter_ReturnsFalse()
    {
        Assert.False(numbersService.NumberIsPalindromeUsingRemaider(123));
    }

    [Fact]
    public void FindAngleBetweenClockArrows_FindAngleBetweenClockArrowsWithValidParameter_ReturnsTrue()
    {
        Assert.Equal(108 ,numbersService.FindAngleBetweenClockArrows(15, 36));
    }

    [Fact]
    public void FindFactorsOfANumber_FindFactorsOfANumberWithValidParameter_ReturnsTrue()
    {
        Assert.Equal(new List<int>() { 1, 2, 3, 5, 6, 10, 15, 30 }, 
            numbersService.FindFactorsOfANumber(30));
    }
}