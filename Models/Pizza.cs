using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.Models
{
    /// <summary>
    /// Represents a pizza available in the pizza sales system.
    /// </summary>
    public class Pizza
    {
        /// <summary>
        /// Gets or sets the unique identifier for the pizza.
        /// </summary>
        [Key]
        public string Pizza_Id { get; set; }

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

        /// <summary>
        /// Gets or sets the collection of order details associated with this pizza.
        /// </summary>
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

}
