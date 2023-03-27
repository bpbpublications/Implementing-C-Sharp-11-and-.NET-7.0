namespace MvcDataApp.Models;

public record Employee : Person
{ 
    public DateTime StartDate { get; set; }
    public int JobId { get; set; }

    public Job Job { get; set; }
    public ICollection<Shift> Shifts { get; set; }
}
