using MediatR;
using KavkazHub.Remont.Core.Command;
using KavkazHub.Remont.Core.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KavkazHub.Remont.Core.Handlers
{
    public class LoadImageHandler : IRequestHandler<LoadImageFileRequest, ClassificationResponse>
    {
        public async Task<ClassificationResponse> Handle(LoadImageFileRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ClassificationResponse());
        }
    }
}
