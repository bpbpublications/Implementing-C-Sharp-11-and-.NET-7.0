using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDataApp.Models;

public record Job
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobId { get; set; }
    public string JobTitle { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Compensation { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
