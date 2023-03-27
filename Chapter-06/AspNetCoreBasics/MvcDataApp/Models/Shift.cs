using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDataApp.Models;

public record Shift
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ShiftId { get; set; }
    [Range(1, 7)]
    public int WeekDay { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int FactoryId { get; set; }
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; }
    public Factory Factory { get; set; }
}
