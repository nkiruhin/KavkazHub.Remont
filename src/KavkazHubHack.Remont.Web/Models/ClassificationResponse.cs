using KavkazHub.Remont.Web.Enum;

namespace KavkazHub.Remont.Web.Models
{
    public class Score
    {
        public string NoDecoration { get; set; }
        public string Luxe { get; set; }
        public string Standart { get; set; }
        public string NeedOfRepair { get; set; }
    }
    public class ClassificationResponse
    {
        public string ImageName { get; set; }
        public ImageCategory ImageCategory { get; set; }
        public string ImageCategoryDescription { get; set; }
        public Score PredictionValues { get; set; }
    }
}