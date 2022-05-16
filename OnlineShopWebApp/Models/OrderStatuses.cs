using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public enum OrderStatuses
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        AwaitingShipment,

        [Display(Name = "В пути")]
        Shipped,

        [Display(Name = "Отменён")]
        Cancelled,

        [Display(Name = "Доставлен")]
        Delivered
    }
}
