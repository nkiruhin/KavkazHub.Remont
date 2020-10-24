using Ardalis.ApiEndpoints;
using KavkazHub.Remont.Web.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using KavkazHub.Remont.Web.Models;

namespace KavkazHub.Remont.Web.Endpoints.Images
{
    public class Load : BaseAsyncEndpoint<LoadImageFileRequest, ClassificationResponse>
    {

        private readonly IMediator _mediator;
        public Load(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/loadImage")]
        [SwaggerOperation(
            Summary = "Load new image",
            Description = "Load new image to recognize renovation state",
            OperationId = "",
            Tags = new[] { "LoadImageEndpoints" })
        ]
        public override async Task<ActionResult<ClassificationResponse>> HandleAsync([FromForm] LoadImageFileRequest request, CancellationToken cancellationToken = default)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
