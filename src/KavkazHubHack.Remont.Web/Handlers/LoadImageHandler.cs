using KavkazHub.Remont.Core.Interfaces;
using KavkazHub.Remont.Web.Command;
using KavkazHub.Remont.Web.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KavkazHub.Remont.Web.Handlers
{
    public class LoadImageHandler : IRequestHandler<LoadImageFileRequest, ClassificationResponse>
    {
        private readonly IMLRemontService _service;

        public LoadImageHandler(IMLRemontService service)
        {
            _service = service;
        }

        public async Task<ClassificationResponse> Handle(LoadImageFileRequest request, CancellationToken cancellationToken)
        {
            _service.Predict(new ML.ModelInput { ImageSource = @"c:\Temp\image.jpg" });
            return await Task.FromResult(new ClassificationResponse());
        }
    }
}
