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
    public void ReverseOrderOfWordsInSentence_ReverseOrderOfWordsInSentenceWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("exercises coding of  Collection  ", stringsService.ReverseOrderOfWordsInSentence(null));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentence_ReverseOrderOfWordsInSentenceWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("great!  is Pizza", stringsService.ReverseOrderOfWordsInSentence("Pizza is  great!"));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder_ReverseOrderOfWordsInSentenceWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("exercises coding of    Collection  ", stringsService.ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder("  Collection    of coding exercises"));
    }

    [Fact]
    public void ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder_ReverseOrderOfWordsInSentenceWithValidParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("great!  is Pizza", stringsService.ReverseOrderOfWordsInSentenceUsingSplitAndStringBuilder("Pizza is  great!"));
    }

    [Fact]
    public void ReverseEachWordInAString_ReverseEachWordInAStringWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal("noitcelloC fo   gnidoc sesicrexe", stringsService.ReverseEachWordInAString(null));
    }

    [Fact]
    public void ReverseEachWordInAString_ReverseEachWordInAStringWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("sihT   ecnetnes si rof    tinu tset  ", stringsService.ReverseEachWordInAString("This   sentence is for    unit test  "));
    }

    [Fact]
    public void ReverseEachWordInAStringUsingSplitAndStringBuilder_ReverseEachWordInAStringWithNullParameter_ReturnsDefaultReversedString()
    {
        Assert.Equal(" noitcelloC   fo   sesicrexe  ", stringsService.ReverseEachWordInAStringUsingSplitAndStringBuilder(null));
    }

    [Fact]
    public void ReverseEachWordInAStringUsingSplitAndStringBuilder_ReverseEachWordInAStringWithValidParameter_ReturnsReversedString()
    {
        Assert.Equal("sihT   ecnetnes si rof    tinu tset  ", stringsService.ReverseEachWordInAStringUsingSplitAndStringBuilder("This   sentence is for    unit test  "));
    }
}