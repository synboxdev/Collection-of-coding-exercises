namespace Data.Models.AppSettings.Collection;

public class Exercise
{
    public string? Description { get; set; }
    public List<Solution>? Solutions { get; set; } = new List<Solution>();
}