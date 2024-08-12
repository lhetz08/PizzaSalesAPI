using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.Models
{
    /// <summary>
    /// Represents an order in the pizza sales system.
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        [Key]
        public int Order_Id { get; set; }

        /// <summary>
        /// Gets or sets the date when the order was placed.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the time when the order was placed.
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Gets or sets the total price of the order.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Navigation property: Gets or sets the collection of order details associated with the order.
        /// </summary>
        public ICollection<OrderDetails> Order_Details { get; set; }
    }
}
