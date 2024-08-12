using PizzaSalesAPI.Models;

namespace PizzaSalesAPI.Services
{
    /// <summary>
    /// Defines the contract for the order service, providing methods to manage order data.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Asynchronously retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, with a result containing the <see cref="Orders"/> object.</returns>
        Task<Orders> GetOrderByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves all orders.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, with a result containing an <see cref="IEnumerable{Orders}"/> of all orders.</returns>
        Task<IEnumerable<Orders>> GetOrdersAsync();

        /// <summary>
        /// Asynchronously creates a new order.
        /// </summary>
        /// <param name="order">The <see cref="Orders"/> object representing the order to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreateOrderAsync(Orders order);
    }
}
