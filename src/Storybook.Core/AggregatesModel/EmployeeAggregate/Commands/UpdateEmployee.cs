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

    public class UpdateEmployeeValidator: AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(request => request.Employee).NotNull();
            RuleFor(request => request.Employee).SetValidator(new EmployeeValidator());
        }
    
    }
    public class UpdateEmployeeRequest: IRequest<UpdateEmployeeResponse>
    {
        public EmployeeDto Employee { get; set; }
    }
    public class UpdateEmployeeResponse: ResponseBase
    {
        public EmployeeDto Employee { get; set; }
    }
    public class UpdateEmployeeHandler: IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<UpdateEmployeeHandler> _logger;
    
        public UpdateEmployeeHandler(IStorybookDbContext context, ILogger<UpdateEmployeeHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.SingleAsync(x => x.EmployeeId == request.Employee.EmployeeId);
            
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Employee = employee.ToDto()
            };
        }
        
    }

}
