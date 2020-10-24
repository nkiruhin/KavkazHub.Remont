using MediatR;
using Microsoft.AspNetCore.Http;
using KavkazHub.Remont.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace KavkazHub.Remont.Core.Command
{
    public class LoadImageFileRequest : IRequest<ClassificationResponse>
    {
        [Required]
        public IFormFile File { get; set; }
    }
}