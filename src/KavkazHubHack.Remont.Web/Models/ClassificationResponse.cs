using KavkazHub.Remont.Web.Enum;

namespace KavkazHub.Remont.Web.Models
{
    public class ClassificationResponse
    {
        public string ImageName { get; set; }
        public ImageCategory ImageCategory { get; set; }
        public string ImageCategoryDescription { get; set; }
    }
}