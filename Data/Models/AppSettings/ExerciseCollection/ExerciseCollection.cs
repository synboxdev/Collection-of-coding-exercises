using Data.Models.AppSettings.Collection;

namespace Data.Models;

public class ExerciseCollection
{
    public List<Category>? Categories { get; set; } = new List<Category>();
}