using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KavkazHub.Remont.Web.Enum
{
    public enum ImageCategory
    {
        [Display(Name = "Без отделки")]
        NoDecoration,
        [Display(Name = "Люкс")]
        Luxe,
        [Display(Name = "Стандартный ремонт")]
        Standart,
        [Display(Name = "Требует косметический ремонт")]
        NeedOfRepair
    }
}