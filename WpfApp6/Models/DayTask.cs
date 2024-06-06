namespace WpfApp6.Models;

public class DayTask
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}