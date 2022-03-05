using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class RemoveEmployeeRequest: IRequest<RemoveEmployeeResponse>
    {
        public int EmployeeId { get; set; }
    }
    public class RemoveEmployeeResponse: ResponseBase
    {
        public EmployeeDto Employee { get; set; }
    }
    public class RemoveEmployeeHandler: IRequestHandler<RemoveEmployeeRequest, RemoveEmployeeResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<RemoveEmployeeHandler> _logger;
    
        public RemoveEmployeeHandler(IStorybookDbContext context, ILogger<RemoveEmployeeHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveEmployeeResponse> Handle(RemoveEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeId);
            
            _context.Employees.Remove(employee);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Employee = employee.ToDto()
            };
        }
        
    }

}
