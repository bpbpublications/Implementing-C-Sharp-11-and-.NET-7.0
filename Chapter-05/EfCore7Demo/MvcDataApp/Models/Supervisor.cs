namespace MvcDataApp.Models;

public record Supervisor : Employee
{
    public int TeamSize { get; set; }
}
