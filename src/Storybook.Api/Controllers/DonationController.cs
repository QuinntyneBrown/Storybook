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
    public class DonationController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DonationController> _logger;

        public DonationController(IMediator mediator, ILogger<DonationController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get Donation by id.",
            Description = @"Get Donation by id."
        )]
        [HttpGet("{donationId:int}", Name = "getDonationById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDonationByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDonationByIdResponse>> GetById([FromRoute]int donationId, CancellationToken cancellationToken)
        {
            var request = new GetDonationByIdRequest() { DonationId = donationId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.Donation == null)
            {
                return new NotFoundObjectResult(request.DonationId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get Donations.",
            Description = @"Get Donations."
        )]
        [HttpGet(Name = "getDonations")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDonationsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDonationsResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetDonationsRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create Donation.",
            Description = @"Create Donation."
        )]
        [HttpPost(Name = "createDonation")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDonationResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDonationResponse>> Create([FromBody]CreateDonationRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateDonationRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get Donation Page.",
            Description = @"Get Donation Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getDonationsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDonationsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDonationsPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetDonationsPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update Donation.",
            Description = @"Update Donation."
        )]
        [HttpPut(Name = "updateDonation")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDonationResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDonationResponse>> Update([FromBody]UpdateDonationRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateDonationRequest),
                nameof(request.Donation.DonationId),
                request.Donation.DonationId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete Donation.",
            Description = @"Delete Donation."
        )]
        [HttpDelete("{donationId:int}", Name = "removeDonation")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDonationResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDonationResponse>> Remove([FromRoute]int donationId, CancellationToken cancellationToken)
        {
            var request = new RemoveDonationRequest() { DonationId = donationId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveDonationRequest),
                nameof(request.DonationId),
                request.DonationId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
