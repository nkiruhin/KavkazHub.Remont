using KavkazHub.Remont.Web.Enum;
using System.Collections.Generic;

namespace KavkazHub.Remont.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassificationResponse
    {
        /// <summary>
        /// Имя файла изображения
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// Класс отделки
        /// </summary>
        public ImageCategory ImageCategory { get; set; }
        /// <summary>
        /// Отображемое имя
        /// </summary>
        public string ImageCategoryDescription { get; set; }
        /// <summary>
        /// Результаты обработки
        /// </summary>
        public Dictionary<string, string> Scores { get; set; }
    }
}