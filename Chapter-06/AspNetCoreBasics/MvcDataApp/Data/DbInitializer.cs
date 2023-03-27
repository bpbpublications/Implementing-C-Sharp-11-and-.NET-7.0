using MvcDataApp.Models;

namespace MvcDataApp.Data;

public class DbInitializer
{
    public static void Initialize(FactoryManagerContext context)
    {
        context.Database.EnsureCreated();

        if (context.Jobs.Any())
        {
            return;
        }

        var jobs = new Job[]
        {
            new Job
            {
                JobTitle = "Manager",
                Compensation = 50000
            },
            new Job
            {
                JobTitle = "Laborer",
                Compensation = 25000
            }
        };
        foreach (var j in jobs)
        {
            context.Jobs.Add(j);
        }
        context.SaveChanges();

        var employees = new Employee[]
        {
            new Employee
            {
                Id = 2,
                FirstName="Alexander",
                LastName="Marshall",
                DateOfBirth=DateTime.Parse("1982-09-12"),
                StartDate=DateTime.Parse("2017-09-01"),
                JobId = 2,
            },
            new Employee
            {
                Id = 3,
                FirstName="Michael",
                LastName="Davidson",
                DateOfBirth=DateTime.Parse("1989-05-11"),
                StartDate=DateTime.Parse("2010-09-01"),
                JobId = 2,
            },
        };
        foreach (var e in employees)
        {
            context.Employees.Add(e);
        }
        context.SaveChanges();

        var supervisors = new Supervisor[]
        {
            new Supervisor
            {
                Id = 1,
                FirstName="John",
                LastName="Smith",
                DateOfBirth=DateTime.Parse("1992-10-01"),
                StartDate=DateTime.Parse("2020-09-01"),
                JobId = 1,
            },
        };
        foreach (var s in supervisors)
        {
            context.Employees.Add(s);
        }
        context.SaveChanges();

        var factories = new Factory[]
        {
            new Factory
            {
                FactoryName = "Best Cookies",
                Location = "New York"
            }
        };
        foreach (var f in factories)
        {
            context.Factories.Add(f);
        }
        context.SaveChanges();

        var shifts = new Shift[]
        {
            new Shift
            {
                WeekDay = 1,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 1
            },
            new Shift
            {
                WeekDay = 2,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 1
            },
            new Shift
            {
                WeekDay = 3,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 1
            },
            new Shift
            {
                WeekDay = 4,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 1
            },
            new Shift
            {
                WeekDay = 5,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 1
            },
            new Shift
            {
                WeekDay = 1,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 2
            },
            new Shift
            {
                WeekDay = 2,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 2
            },
            new Shift
            {
                WeekDay = 3,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 2
            },
            new Shift
            {
                WeekDay = 4,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 2
            },
            new Shift
            {
                WeekDay = 5,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 2
            },
            new Shift
            {
                WeekDay = 1,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 3
            },
            new Shift
            {
                WeekDay = 2,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 3
            },
            new Shift
            {
                WeekDay = 3,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 3
            },
            new Shift
            {
                WeekDay = 4,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 3
            },
            new Shift
            {
                WeekDay = 5,
                StartTime = new TimeSpan(9,0,0),
                EndTime = new TimeSpan(17,0,0),
                FactoryId = 1,
                EmployeeId = 3
            }
        };
        foreach (var s in shifts)
        {
            context.Shifts.Add(s);
        }
        context.SaveChanges();
    }
}
