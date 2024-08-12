namespace PizzaSalesAPI.DTO
{
    public class PizzaDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the pizza.
        /// </summary>
        public string Pizza_Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the type of pizza (e.g., Margherita, Pepperoni).
        /// </summary>
        public string Pizza_Type_Id { get; set; }

        /// <summary>
        /// Gets or sets the size of the pizza (e.g., Small, Medium, Large).
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the price of the pizza.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the collection of order details associated with this pizza.
        /// </summary>
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
