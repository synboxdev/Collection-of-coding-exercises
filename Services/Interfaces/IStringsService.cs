namespace Services.Interfaces;

public interface IStringsService
{
    public string ReverseAString(string? inputString);
    public string ReverseAStringUsingArrayReverse(string? inputString);
    public string ReverseAStringUsingLINQ(string? inputString);
}