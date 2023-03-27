using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDataApp.Models;

public abstract record Person
{
    public int Id { get; set; }
    [StringLength(20)]
    public string FirstName { get; set; }
    [StringLength(20)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    [NotMapped]
    public string FullName => FirstName + " " + LastName;
}
