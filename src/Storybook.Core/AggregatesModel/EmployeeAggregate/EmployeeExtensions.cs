using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Storybook.Core
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto ToDto(this Employee employee)
        {
            return new ()
            {
                EmployeeId = employee.EmployeeId,
            };
        }
        
        public static async Task<List<EmployeeDto>> ToDtosAsync(this IQueryable<Employee> employees, CancellationToken cancellationToken)
        {
            return await employees.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<EmployeeDto> ToDtos(this IEnumerable<Employee> employees)
        {
            return employees.Select(x => x.ToDto()).ToList();
        }
        
    }
}
