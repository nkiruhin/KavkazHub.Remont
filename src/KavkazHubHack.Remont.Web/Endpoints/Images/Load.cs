using Ardalis.ApiEndpoints;
using KavkazHub.Remont.Web.Command;
using KavkazHub.Remont.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IO;
using System.Linq;
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
            Description = "Load new image to recognize renovation state",
            OperationId = "",
            Tags = new[] { "LoadImageEndpoints" })
        ]
        public override async Task<ActionResult<ClassificationResponse>> HandleAsync([FromForm] LoadImageFileRequest request, CancellationToken cancellationToken = default)
        {
            ///Ограничение на размер файла 10МБ
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("Message", $"Превышен допустимый размер файла изображения");
                return BadRequest(ModelState);
            };
            ///Проверка расширения файла
            string[] permittedExtensions = { ".jpg", ".png", ".bmp" };
            var ext = Path.GetExtension(request.File.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                ModelState.AddModelError("Message", $"Не верный формат файла");
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
