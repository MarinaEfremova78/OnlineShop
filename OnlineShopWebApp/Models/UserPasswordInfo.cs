using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserPasswordInfo
    {
        public string UserId { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Не подтверждён пароль")]
        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
