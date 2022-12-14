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
        Assert.Equal(108, numbersService.FindAngleBetweenClockArrows(15, 36));
    }

    [Fact]
    public void FindFactorsOfANumber_FindFactorsOfANumberWithValidParameter_ReturnsTrue()
    {
        Assert.Equal(new List<int>() { 1, 2, 3, 5, 6, 10, 15, 30 },
            numbersService.FindFactorsOfANumber(30));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameter_ReturnsNull()
    {
        Assert.Null(numbersService.PrimeNumberStrength(66));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameterBalancedPrime_ReturnsValidAnswer()
    {
        Assert.Equal("Balanced", numbersService.PrimeNumberStrength(5));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameterWeakPrime_ReturnsValidAnswer()
    {
        Assert.Equal("Weak", numbersService.PrimeNumberStrength(83));
    }

    [Fact]
    public void NumberPrimeStrength_NumberPrimeStrengthWithValidParameterStrongPrime_ReturnsValidAnswer()
    {
        Assert.Equal("Strong", numbersService.PrimeNumberStrength(37));
    }

    [Fact]
    public void FindNthElementOfUlamSequence_FindNthElementOfUlamSequenceWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(16, numbersService.FindNthElementOfUlamSequence(9));
    }

    [Fact]
    public void CollatzConjectureProblem_CollatzConjectureProblemWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(17, numbersService.CollatzConjectureProblem(15));
        Assert.Equal(111, numbersService.CollatzConjectureProblem(27));
    }

    [Fact]
    public void IsNumberHarshadOrMoran_IsNumberHarshadOrMoranWithValidParameter_ReturnsMoran()
    {
        Assert.Equal("Moran", numbersService.IsNumberHarshadOrMoran(133));
    }

    [Fact]
    public void IsNumberHarshadOrMoran_IsNumberHarshadOrMoranWithValidParameter_ReturnsHarshad()
    {
        Assert.Equal("Harshad", numbersService.IsNumberHarshadOrMoran(102));
    }

    [Fact]
    public void IsNumberHarshadOrMoran_IsNumberHarshadOrMoranWithValidParameter_ReturnsNeither()
    {
        Assert.Equal("Neither", numbersService.IsNumberHarshadOrMoran(32));
    }

    [Fact]
    public void CheckIfNumberHasABreakpoint_CheckIfNumberHasABreakpointWithValidParameter_ReturnsHasBreakpoint()
    {
        Assert.True(numbersService.CheckIfNumberHasABreakpoint(159780));
    }

    [Fact]
    public void CheckIfNumberHasABreakpoint_CheckIfNumberHasABreakpointWithValidParameter_ReturnsDoesntHaveBreakpoint()
    {
        Assert.False(numbersService.CheckIfNumberHasABreakpoint(10));
    }

    [Fact]
    public void LookAndSaySequence_LookAndSaySequenceWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal("132117132110", numbersService.LookAndSaySequence(70, 4));
        Assert.Equal("13112221", numbersService.LookAndSaySequence(1, 6));
    }

    [Fact]
    public void KaprekarsConstantProblem_KaprekarsConstantProblemWithValidParameter_ReturnsValidAnswer()
    {
        Assert.Equal(3, numbersService.KaprekarsConstantProblem(4159));
    }
}