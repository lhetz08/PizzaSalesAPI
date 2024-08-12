using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaSalesAPI.Models
{
    /// <summary>
    /// Represents the details of an order, including the specific pizza and quantity.
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order details entry.
        /// </summary>
        [Key]
        public int Order_Details_Id { get; set; }

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
        public int Quantity { get; set; }

        /// <summary>
        /// Navigation property: Gets or sets the order associated with these details.
        /// </summary>
        [ForeignKey("Order_Id")]
        public Orders Order { get; set; }

        /// <summary>
        /// Navigation property: Gets or sets the pizza associated with these details.
        /// </summary>
        [ForeignKey("Pizza_Id")]
        public Pizza Pizza { get; set; }
    }
}
