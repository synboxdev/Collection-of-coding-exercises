using Services;

namespace Tests;

public class EulerServiceTests
{
    private readonly EulerService eulerService;

    public EulerServiceTests()
    {
        eulerService = new EulerService();
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
}