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
}