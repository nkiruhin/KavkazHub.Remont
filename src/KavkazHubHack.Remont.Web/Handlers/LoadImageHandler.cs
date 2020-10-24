using KavkazHub.Remont.Core.Interfaces;
using KavkazHub.Remont.Web.Command;
using KavkazHub.Remont.Web.Models;
using MediatR;
using Microsoft.OpenApi.Extensions;
using System;
using System.IO;
using System.Linq;
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

        public Enum.ImageCategory GetCategoryByName(string name)
        {
            if (name == "без отделки") return Enum.ImageCategory.NoDecoration;
            if (name == "люкс") return Enum.ImageCategory.Luxe;
            if (name == "стандартный ремонт") return Enum.ImageCategory.Standart;
            return Enum.ImageCategory.NeedOfRepair;
        }

        public async Task<ClassificationResponse> Handle(LoadImageFileRequest request, CancellationToken cancellationToken)
        {
            var fileName = $"{Guid.NewGuid()}";
            using (FileStream fs = File.Create(fileName))
            {
                await request.File.OpenReadStream().CopyToAsync(fs);
            }
            var output = _service.Predict(new ML.ModelInput { ImageSource = fileName });
            return await Task.FromResult(new ClassificationResponse 
            {
                ImageCategory = GetCategoryByName(output.Prediction),
                ImageCategoryDescription = output.Prediction,
                ImageName = request.File.FileName
            });
        }
    }
}
