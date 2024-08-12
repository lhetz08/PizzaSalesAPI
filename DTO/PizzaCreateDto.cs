using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.DTO
{
    public class PizzaCreateDto
    {
        /// <summary>
        /// Gets or sets the identifier for the type of pizza (e.g., Margherita, Pepperoni).
        /// </summary>
        [Required]
        public string Pizza_Type_Id { get; set; }

        /// <summary>
        /// Gets or sets the size of the pizza (e.g., Small, Medium, Large).
        /// </summary>
        [Required]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the price of the pizza.
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
