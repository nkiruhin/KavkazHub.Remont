using KavkazHub.Remont.Core.Interfaces;
using KavkazHub.Remont.ML;
using KavkazHub.Remont.Web.Command;
using KavkazHub.Remont.Web.Enum;
using KavkazHub.Remont.Web.Models;
using MediatR;
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

        private ImageCategory GetCategoryByName(string name)
        {
            return name switch
            {
                "без отделки" => ImageCategory.NoDecoration,
                "люкс" => ImageCategory.Luxe,
                "стандартный ремонт" => ImageCategory.Standart,
                "требуется косметический ремонт" => ImageCategory.NeedOfRepair,
                _ => ImageCategory.Unknown
            };
        }

        public async Task<ClassificationResponse> Handle(LoadImageFileRequest request, CancellationToken cancellationToken)
        {
            var fileName = $"{Guid.NewGuid()}";
            using (FileStream stream = File.Create(fileName))
            {
                await request.ImageFile.OpenReadStream().CopyToAsync(stream);
            }
            var output = _service.Predict(new ModelInput
            {
                ImageSource = fileName
            });

            File.Delete(fileName);
            var result = new ClassificationResponse
            {
                ImageCategory = GetCategoryByName(output.Prediction),
                ImageCategoryDescription = output.Prediction,
                ImageName = request.ImageFile.FileName,
                Scores = output.Score.Select((x, i) => new { key = (ImageCategory)i, Value = $"{Math.Round(x, 4) * 100}%" })
                        .ToDictionary(x => x.key.ToString(), x => x.Value)
            };
            return result;
        }
    }
}
