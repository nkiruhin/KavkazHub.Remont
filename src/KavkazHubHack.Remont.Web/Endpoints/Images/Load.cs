using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using KavkazHub.Remont.Core.Command;
using KavkazHub.Remont.Core.Model;
using System.Threading;
using System.Threading.Tasks;

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
            Description = "Creates a new ToDoItem",
            OperationId = "",
            Tags = new[] { "LoadImageEndpoints" })
        ]
        public override async Task<ActionResult<ClassificationResponse>> HandleAsync([FromForm] LoadImageFileRequest request, CancellationToken cancellationToken = default)
        {

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
