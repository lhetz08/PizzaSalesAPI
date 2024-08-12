namespace PizzaSalesAPI.DTO
{
    public class OrderDetailDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order details entry.
        /// </summary>
        public int Order_Details_Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the order to which these details belong.
        /// </summary>
        public int Order_Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the pizza included in the order.
        /// </summary>
        public string Pizza_Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the pizza ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the order associated with these details.
        /// </summary>
        public OrderDto Order { get; set; }

        /// <summary>
        /// Gets or sets the pizza associated with these details.
        /// </summary>
        public PizzaDto Pizza { get; set; }
    }
}
