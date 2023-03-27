using Microsoft.EntityFrameworkCore.Diagnostics;
using MvcDataApp.Models;
using System.Collections.Concurrent;

namespace MvcDataApp.Data;

public class EmployeeCachingInterceptor : IMaterializationInterceptor
{
    private static readonly ConcurrentDictionary<string, Employee> EmployeeCache = new();

    public InterceptionResult<object> CreatingInstance(
        MaterializationInterceptionData materializationData,
        InterceptionResult<object> result)
    {
        if (materializationData.EntityType.ClrType == typeof(Employee))
        {
            var employeeName = materializationData.GetPropertyValue<string>(nameof(Employee.FullName));
            if (EmployeeCache.TryGetValue(employeeName, out var country))
            {
                Console.WriteLine($"Got employee '{country.FullName}' from the cache.");
                return InterceptionResult<object>.SuppressWithResult(country);
            }
        }

        return result;
    }
}
