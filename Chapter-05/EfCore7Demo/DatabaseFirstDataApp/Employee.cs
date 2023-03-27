namespace DatabaseFirstDataApp
{
    public partial class Employee
    {
        public Employee()
        {
            Shifts = new HashSet<Shift>();
        }

        public EmployeeKey EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public int JobId { get; set; }

        public virtual Job Job { get; set; } = null!;
        public virtual ICollection<Shift> Shifts { get; set; }
    }

    public class EmployeeKey
    {
        public EmployeeKey(Func<int> generator) => EmployeeId = generator();
        public EmployeeKey(int id) => EmployeeId = id;
        public int EmployeeId { get; private set; }
    }
}
