using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class GetEmployeesPageRequest: IRequest<GetEmployeesPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetEmployeesPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<EmployeeDto> Entities { get; set; }
    }
    public class GetEmployeesPageHandler: IRequestHandler<GetEmployeesPageRequest, GetEmployeesPageResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetEmployeesPageHandler> _logger;
    
        public GetEmployeesPageHandler(IStorybookDbContext context, ILogger<GetEmployeesPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetEmployeesPageResponse> Handle(GetEmployeesPageRequest request, CancellationToken cancellationToken)
        {
            var query = from employee in _context.Employees
                select employee;
            
            var length = await _context.Employees.AsNoTracking().CountAsync();
            
            var employees = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = employees
            };
        }
        
    }

}
