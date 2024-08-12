using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.DTO
{
    public class OrderDetailCreateDto
    {
        /// <summary>
        /// Gets or sets the identifier of the order to which these details belong.
        /// </summary>
        [Required]
        public int Order_Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the pizza included in the order.
        /// </summary>
        [Required]
        public string Pizza_Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the pizza ordered.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
