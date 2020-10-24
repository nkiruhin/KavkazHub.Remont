using System.ComponentModel.DataAnnotations;

namespace KavkazHub.Remont.Web.Enum
{
    /// <summary>
    /// Классы отделки
    /// </summary>
    public enum ImageCategory
    {
        /// <summary>
        /// Без отделки
        /// </summary>
        [Display(Name = "Без отделки")]
        NoDecoration,
        /// <summary>
        /// Люкс
        /// </summary>
        [Display(Name = "Люкс")]
        Luxe,
        /// <summary>
        /// Стандартный ремонт
        /// </summary>
        [Display(Name = "Стандартный ремонт")]
        Standart,
        /// <summary>
        /// Требуется косметический ремонт
        /// </summary>
        [Display(Name = "Требуется косметический ремонт")]
        NeedOfRepair,
        /// <summary>
        /// Неизвестно
        /// </summary>
        [Display(Name = "Неизвестно")]
        Unknown = 999
    }
}