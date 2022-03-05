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

    public class GetEmployeeByIdRequest: IRequest<GetEmployeeByIdResponse>
    {
        public int EmployeeId { get; set; }
    }
    public class GetEmployeeByIdResponse: ResponseBase
    {
        public EmployeeDto Employee { get; set; }
    }
    public class GetEmployeeByIdHandler: IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetEmployeeByIdHandler> _logger;
    
        public GetEmployeeByIdHandler(IStorybookDbContext context, ILogger<GetEmployeeByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Employee = (await _context.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.EmployeeId == request.EmployeeId)).ToDto()
            };
        }
        
    }

}
