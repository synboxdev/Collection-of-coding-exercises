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
}