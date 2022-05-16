using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Не указана новая роль")]
        public string Name { get; set; }
    }
}
