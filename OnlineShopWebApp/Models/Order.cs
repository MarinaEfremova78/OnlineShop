using System;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public string CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public string Date { get; }
        public string Time { get; }
        public Guid Id { get; set; }
        public Cart Cart { get; set; }
        public UserDeliveryInfo User { get; set; }
        public OrderStatuses Status { get; set; }

        public static int OrderNumberCounter = 1;       

        public Order()
        {
            OrderNumber = OrderNumberCounter;
            Id = Guid.NewGuid();
            Date = DateTime.Now.ToString("dd.MM.yyyy");
            Time = DateTime.Now.ToString("HH:mm");

            OrderNumberCounter++;
        }

    }
}
