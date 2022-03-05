using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Storybook.Core;
using MediatR;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Storybook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get Employee by id.",
            Description = @"Get Employee by id."
        )]
        [HttpGet("{employeeId:int}", Name = "getEmployeeById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeeByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeeByIdResponse>> GetById([FromRoute]int employeeId, CancellationToken cancellationToken)
        {
            var request = new GetEmployeeByIdRequest() { EmployeeId = employeeId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.Employee == null)
            {
                return new NotFoundObjectResult(request.EmployeeId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get Employees.",
            Description = @"Get Employees."
        )]
        [HttpGet(Name = "getEmployees")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeesResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeesResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetEmployeesRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create Employee.",
            Description = @"Create Employee."
        )]
        [HttpPost(Name = "createEmployee")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateEmployeeResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateEmployeeResponse>> Create([FromBody]CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateEmployeeRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get Employee Page.",
            Description = @"Get Employee Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getEmployeesPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEmployeesPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEmployeesPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetEmployeesPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update Employee.",
            Description = @"Update Employee."
        )]
        [HttpPut(Name = "updateEmployee")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateEmployeeResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateEmployeeResponse>> Update([FromBody]UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateEmployeeRequest),
                nameof(request.Employee.EmployeeId),
                request.Employee.EmployeeId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete Employee.",
            Description = @"Delete Employee."
        )]
        [HttpDelete("{employeeId:int}", Name = "removeEmployee")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveEmployeeResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveEmployeeResponse>> Remove([FromRoute]int employeeId, CancellationToken cancellationToken)
        {
            var request = new RemoveEmployeeRequest() { EmployeeId = employeeId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveEmployeeRequest),
                nameof(request.EmployeeId),
                request.EmployeeId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
