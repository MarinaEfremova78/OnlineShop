using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class AdminProductInfo
    {
        [Required(ErrorMessage = "Не указано название фильма")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Не указана стоимость")]
        [Range(0, 5000, ErrorMessage = "Стоимость должна быть больше 0")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указана продолжительность фильма")]
        [Range(0, 320, ErrorMessage = "Продолжительность фильма должна быть больше 0")]
        public double Duration { get; set; }
    }
}
