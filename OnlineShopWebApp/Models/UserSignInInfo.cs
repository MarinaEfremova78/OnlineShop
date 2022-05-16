using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserSignInInfo
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Введите действительный email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        public bool IsSaved { get; set; }
    }
}
