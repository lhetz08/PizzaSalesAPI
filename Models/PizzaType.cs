using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.Models
{
    /// <summary>
    /// Represents the type of pizza, including its name, category, and ingredients.
    /// </summary>
    public class PizzaType
    {
        /// <summary>
        /// Gets or sets the unique identifier for the pizza type.
        /// </summary>
        [Key]
        public string Pizza_Type_Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the pizza type (e.g., Margherita, Pepperoni).
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the pizza type (e.g., Vegetarian, Meat Lover).
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the list of ingredients for the pizza type.
        /// </summary>
        public string Ingredients { get; set; }
    }
}
