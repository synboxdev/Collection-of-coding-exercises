using Services;

namespace Tests;

public class StringsServiceTests
{
    private readonly StringsService stringsService;

    public StringsServiceTests()
    {
        stringsService = new StringsService();
    }

    [Fact]
    public void ReverseAString_ReverseAStringWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAString("Hello world!"));
    }

    [Fact]
    public void ReverseAString_ReverseAStringWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAString(null));
    }

    [Fact]
    public void ReverseAStringUsingArrayReverse_ReverseAStringUsingArrayReverseWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingArrayReverse("Hello world!"));
    }

    [Fact]
    public void ReverseAStringUsingArrayReverse_ReverseAStringUsingArrayReverseWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingArrayReverse(null));
    }

    [Fact]
    public void ReverseAStringUsingLINQ_ReverseAStringUsingLINQWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingLINQ("Hello world!"));
    }

    [Fact]
    public void ReverseAStringUsingLINQ_ReverseAStringUsingLINQWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("!dlrow olleH", stringsService.ReverseAStringUsingLINQ(null));
    }
}