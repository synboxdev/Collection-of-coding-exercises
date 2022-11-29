namespace Data.Models.AppSettings.Collection;

public class Category
{
    public string? Name { get; set; }
    public List<Exercise>? Exercises { get; set; } = new List<Exercise>();
}