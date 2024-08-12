using PizzaSalesAPI.Models;
using PizzaSalesAPI.Repositories;

namespace PizzaSalesAPI.Services
{
    /// <summary>
    /// Implements the <see cref="IOrderService"/> interface to provide order management services.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">The repository used to access order data.</param>
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Asynchronously retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, with a result containing the <see cref="Orders"/> object.</returns>
        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        /// <summary>
        /// Asynchronously retrieves all orders.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, with a result containing an <see cref="IEnumerable{Orders}"/> of all orders.</returns>
        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }

        /// <summary>
        /// Asynchronously creates a new order.
        /// </summary>
        /// <param name="order">The <see cref="Orders"/> object representing the order to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateOrderAsync(Orders order)
        {
            await _orderRepository.CreateOrderAsync(order);
        }
    }
}
