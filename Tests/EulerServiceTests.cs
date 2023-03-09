using Services;
using Services.Interfaces;

namespace Tests;

public class EulerServiceTests
{
    private readonly INumbersService numbersService;
    private readonly EulerService eulerService;

    public EulerServiceTests()
    {
        numbersService = new NumbersService();
        eulerService = new EulerService(numbersService);
    }

    [Fact]
    public void MultiplesOf3And5_MultiplesOf3And5_ReturnsValidResult()
    {
        Assert.Equal(233168, eulerService.MultiplesOf3And5());
    }

    [Fact]
    public void MultiplesOf3And5UsingLINQ_MultiplesOf3And5UsingLINQ_ReturnsValidResult()
    {
        Assert.Equal(233168, eulerService.MultiplesOf3And5UsingLINQ());
    }

    [Fact]
    public void EvenFibonacciNumbers_EvenFibonacciNumbers_ReturnsValidResult()
    {
        Assert.Equal(7049152, eulerService.EvenFibonacciNumbers());
    }

    [Fact]
    public void LargestPrimeFactor_LargestPrimeFactor_ReturnsValidResult()
    {
        Assert.Equal(6857, eulerService.LargestPrimeFactor());
    }

    [Fact]
    public void LargestPalindromeProduct_LargestPalindromeProduct_ReturnsValidResult()
    {
        Assert.Equal(906609, eulerService.LargestPalindromeProduct());
    }

    [Fact]
    public void LargestPalindromeProductUsingLINQ_LargestPalindromeProductUsingLINQ_ReturnsValidResult()
    {
        Assert.Equal(906609, eulerService.LargestPalindromeProductUsingLINQ());
    }

    [Fact]
    public void SmallestMultiple_SmallestMultiple_ReturnsValidResult()
    {
        Assert.Equal(232792560, eulerService.SmallestMultiple());
    }

    [Fact]
    public void SumSquareDifference_SumSquareDifference_ReturnsValidResult()
    {
        Assert.Equal(25164150, eulerService.SumSquareDifference());
    }

    [Fact]
    public void Get10001stPrime_Get10001stPrime_ReturnsValidResult()
    {
        Assert.Equal(104743, eulerService.Get10001stPrime());
    }

    [Fact]
    public void LargestProductInASeries_LargestProductInASeries_ReturnsValidResult()
    {
        Assert.Equal(new int[] { 5, 5, 7, 6, 6, 8, 9, 6, 6, 4, 8, 9, 5 },
            eulerService.LargestProductInASeries());
    }

    [Fact]
    public void SpecialPythagoreanTriplet_SpecialPythagoreanTriplet_ReturnsValidResult()
    {
        Assert.Equal(31875000, eulerService.SpecialPythagoreanTriplet());
    }

    [Fact]
    public void SummationOfPrimes_SummationOfPrimes_ReturnsValidResult()
    {
        Assert.Equal(142913828922, eulerService.SummationOfPrimes());
    }

    [Fact]
    public void LargestProductInAGrid_LargestProductInAGrid_ReturnsValidResult()
    {
        Assert.Equal(70600674, eulerService.LargestProductInAGrid());
    }

    [Fact]
    public void HighlyDivisibleTriangularNumber_HighlyDivisibleTriangularNumber_ReturnsValidResult()
    {
        Assert.Equal(76576500, eulerService.HighlyDivisibleTriangularNumber());
    }

    [Fact]
    public void LargeSum_LargeSum_ReturnsValidResult()
    {
        Assert.Equal("5537376230", eulerService.LargeSum());
    }

    [Fact]
    public void LongestCollatzSequence_LongestCollatzSequence_ReturnsValidResult()
    {
        Assert.Equal(837799, eulerService.LongestCollatzSequence());
    }

    [Fact]
    public void LatticePaths_LatticePaths_ReturnsValidResult()
    {
        Assert.Equal(137846528820, eulerService.LatticePaths());
    }

    [Fact]
    public void PowerDigitSum_PowerDigitSum_ReturnsValidResult()
    {
        Assert.Equal(1366, eulerService.PowerDigitSum());
    }

    [Fact]
    public void NumberLetterCounts_NumberLetterCounts_ReturnsValidResult()
    {
        Assert.Equal(21124, eulerService.NumberLetterCounts());
    }

    [Fact]
    public void MaximumPathSumI_MaximumPathSumI_ReturnsValidResult()
    {
        Assert.Equal(1074, eulerService.MaximumPathSumI());
    }

    [Fact]
    public void CountingSundays_CountingSundays_ReturnsValidResult()
    {
        Assert.Equal(171, eulerService.CountingSundays());
    }

    [Fact]
    public void FactorialDigitSum_FactorialDigitSum_ReturnsValidResult()
    {
        Assert.Equal(648, eulerService.FactorialDigitSum());
    }
}