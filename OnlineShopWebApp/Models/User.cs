using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, ErrorMessage = "Имя должно содержать не меньше 2 и не больше 25 символов", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(25, ErrorMessage = "Фамилия должно содержать не меньше 2 и не больше 25 символов", MinimumLength = 2)]
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Введите действительный email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public bool IsSaved { get; set; }
    }
}
