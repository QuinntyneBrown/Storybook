using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class GetEmployeesRequest: IRequest<GetEmployeesResponse> { }
    public class GetEmployeesResponse: ResponseBase
    {
        public List<EmployeeDto> Employees { get; set; }
    }
    public class GetEmployeesHandler: IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetEmployeesHandler> _logger;
    
        public GetEmployeesHandler(IStorybookDbContext context, ILogger<GetEmployeesHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Employees = await _context.Employees.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
