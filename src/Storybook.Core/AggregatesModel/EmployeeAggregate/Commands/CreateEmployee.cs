using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class CreateEmployeeValidator: AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(request => request.Employee).NotNull();
            RuleFor(request => request.Employee).SetValidator(new EmployeeValidator());
        }
    
    }
    public class CreateEmployeeRequest: IRequest<CreateEmployeeResponse>
    {
        public EmployeeDto Employee { get; set; }
    }
    public class CreateEmployeeResponse: ResponseBase
    {
        public EmployeeDto Employee { get; set; }
    }
    public class CreateEmployeeHandler: IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<CreateEmployeeHandler> _logger;
    
        public CreateEmployeeHandler(IStorybookDbContext context, ILogger<CreateEmployeeHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = new Employee();
            
            _context.Employees.Add(employee);
            
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Employee = employee.ToDto()
            };
        }
        
    }

}
