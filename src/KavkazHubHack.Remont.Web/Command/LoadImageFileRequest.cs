using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using KavkazHub.Remont.Web.Models;

namespace KavkazHub.Remont.Web.Command
{
    /// <summary>
    /// Параметры метода загрузки файла изображения
    /// </summary>
    public class LoadImageFileRequest : IRequest<ClassificationResponse>
    {
        /// <summary>
        /// Файл изображения
        /// </summary>
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}