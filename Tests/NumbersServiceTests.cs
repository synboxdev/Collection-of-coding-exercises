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
}