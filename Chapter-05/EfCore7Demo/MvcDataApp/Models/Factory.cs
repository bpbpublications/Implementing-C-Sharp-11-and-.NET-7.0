using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDataApp.Models;

public record Factory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FactoryId { get; set; }
    public string FactoryName { get; set; }
    public string Location { get; set; }

    public ICollection<Shift> Shifts { get; set; }

}
