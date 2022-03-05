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
    public class CampaignController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(IMediator mediator, ILogger<CampaignController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get Campaign by id.",
            Description = @"Get Campaign by id."
        )]
        [HttpGet("{campaignId:int}", Name = "getCampaignById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCampaignByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCampaignByIdResponse>> GetById([FromRoute]int campaignId, CancellationToken cancellationToken)
        {
            var request = new GetCampaignByIdRequest() { CampaignId = campaignId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.Campaign == null)
            {
                return new NotFoundObjectResult(request.CampaignId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get Campaigns.",
            Description = @"Get Campaigns."
        )]
        [HttpGet(Name = "getCampaigns")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCampaignsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCampaignsResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCampaignsRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create Campaign.",
            Description = @"Create Campaign."
        )]
        [HttpPost(Name = "createCampaign")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCampaignResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCampaignResponse>> Create([FromBody]CreateCampaignRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateCampaignRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get Campaign Page.",
            Description = @"Get Campaign Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getCampaignsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCampaignsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCampaignsPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetCampaignsPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update Campaign.",
            Description = @"Update Campaign."
        )]
        [HttpPut(Name = "updateCampaign")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCampaignResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCampaignResponse>> Update([FromBody]UpdateCampaignRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateCampaignRequest),
                nameof(request.Campaign.CampaignId),
                request.Campaign.CampaignId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete Campaign.",
            Description = @"Delete Campaign."
        )]
        [HttpDelete("{campaignId:int}", Name = "removeCampaign")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCampaignResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCampaignResponse>> Remove([FromRoute]int campaignId, CancellationToken cancellationToken)
        {
            var request = new RemoveCampaignRequest() { CampaignId = campaignId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveCampaignRequest),
                nameof(request.CampaignId),
                request.CampaignId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
