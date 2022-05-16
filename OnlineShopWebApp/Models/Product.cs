using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp
{
    public class Product
    {
        private static int IdCounter = 0;
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название фильма")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите цену фильма")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Введите описание фильма")]
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Введите продолжительность фильма")]
        public double Duration { get; set; }

        public Product(string name, decimal cost, string description, string imagePath, double duration)
        {
            Id = IdCounter;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
            Duration = duration;

            IdCounter++;
        }
        public Product()
        {
            Id = IdCounter;

            IdCounter++;
        }

    }
}
