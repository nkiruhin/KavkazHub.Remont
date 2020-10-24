using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KavkazHub.Remont.Core.Enum
{
    public enum ImageCategory
    {
        [Display(Name = "Стандарт")]
        Standart,
        [Display(Name = "Люкс")]
        Luxe,
        [Display(Name ="Без отделки")]
        NoDecoration,
        [Display(Name = "Требует ремонта")]
        NeedOfRepiar
    }
}