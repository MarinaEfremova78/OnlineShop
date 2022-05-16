using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, ErrorMessage = "Имя должно содержать не меньше 2 и не больше 25 символов", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(25, ErrorMessage = "Фамилия должна содержать не меньше 2 и не больше 25 символов", MinimumLength = 2)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан адрес доставки")]
        public string Address { get; set; }
        public string Comment { get; set; }
    }
}
