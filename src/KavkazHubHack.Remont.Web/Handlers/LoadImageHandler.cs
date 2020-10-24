using KavkazHub.Remont.Web.Command;
using KavkazHub.Remont.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace KavkazHub.Remont.Web.Handlers
{
    public class LoadImageHandler : IRequestHandler<LoadImageFileRequest, ClassificationResponse>
    {
        public async Task<ClassificationResponse> Handle(LoadImageFileRequest request, CancellationToken cancellationToken)
        {
            
            return await Task.FromResult(new ClassificationResponse());
        }
    }
}
