using Microsoft.EntityFrameworkCore;
using PizzaSalesAPI.Models;

namespace PizzaSalesAPI.Repositories
{
    /// <summary>
    /// Implements the <see cref="IOrderRepository"/> interface to manage order data using the context.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaSalesContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="context">The context used to access the database.</param>
        public OrderRepository(PizzaSalesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, with a result containing the <see cref="Orders"/> object.</returns>
        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Order_Details)
                    .ThenInclude(od => od.Pizza)
                .FirstOrDefaultAsync(o => o.Order_Id == id);
        }

        /// <summary>
        /// Asynchronously retrieves all orders.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, with a result containing an <see cref="IEnumerable{Orders}"/> of all orders.</returns>
        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Order_Details)
                    .ThenInclude(od => od.Pizza)
                .ToListAsync();
        }

        /// <summary>
        /// Asynchronously adds a new order to the repository.
        /// </summary>
        /// <param name="order">The <see cref="Orders"/> object representing the order to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateOrderAsync(Orders order)
        {
            await _context.Orders.AddAsync(order);
        }

        /// <summary>
        /// Asynchronously saves all changes made to the context.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
