namespace repo.Models
{
    public record Command(string title, string info, List<Switch> switches);
}
