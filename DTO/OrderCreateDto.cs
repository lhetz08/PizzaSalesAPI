using System.ComponentModel.DataAnnotations;

namespace PizzaSalesAPI.DTO
{
    public class OrderCreateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>        
        public int order_id { get; set; }
        /// <summary>
        /// Gets or sets the date when the order was placed.
        /// </summary>
        public DateOnly date { get; set; }

        /// <summary>
        /// Gets or sets the time when the order was placed.
        /// </summary>
        public TimeOnly time { get; set; }

        /// <summary>
        /// Gets or sets the collection of order details associated with the order.
        /// </summary>
        public ICollection<OrderDetailCreateDto> Order_Details { get; set; }
    }
}
