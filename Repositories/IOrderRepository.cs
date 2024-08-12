using PizzaSalesAPI.Models;

namespace PizzaSalesAPI.Repositories
{
    /// <summary>
    /// Defines the contract for the order repository, providing methods to interact with order data.
    /// </summary>
    public interface IOrderRepository
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
        /// Asynchronously creates a new order in the repository.
        /// </summary>
        /// <param name="order">The <see cref="Orders"/> object representing the order to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreateOrderAsync(Orders order);

        /// <summary>
        /// Asynchronously saves all changes made to the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task SaveChangesAsync();
    }
}
