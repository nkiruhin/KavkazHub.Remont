using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using KavkazHub.Remont.Web.Models;

namespace KavkazHub.Remont.Web.Command
{
    public class LoadImageFileRequest : IRequest<ClassificationResponse>
    {
        [Required]
        public IFormFile File { get; set; }
    }
}