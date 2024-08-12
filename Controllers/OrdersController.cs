using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using PizzaSalesAPI.DTO;
using PizzaSalesAPI.Models;
using PizzaSalesAPI.Services;
using System.Globalization;

namespace PizzaSalesAPI.Controllers
{
    /// <summary>
    /// The OrdersController class handles HTTP requests related to pizza orders.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersController"/> class.
        /// </summary>
        /// <param name="orderService">The service responsible for order operations.</param>
        /// <param name="mapper">The mapper used for mapping between entities and DTOs.</param>
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves the details of a specific order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>An <see cref="ActionResult{OrderDto}"/> containing the order information.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        /// <summary>
        /// Retrieves a list of all orders.
        /// </summary>
        /// <returns>An <see cref="ActionResult{IEnumerable{OrderDto}}"/> containing all orders.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(orderDtos);
        }

        /// <summary>
        /// Creates a new order based on the provided data.
        /// </summary>
        /// <param name="orderCreateDto">The data transfer object containing order details.</param>
        /// <returns>The created order's details.</returns>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Orders>(orderCreateDto);
            await _orderService.CreateOrderAsync(order);
            var orderDto = _mapper.Map<OrderDto>(order);
            return CreatedAtAction(nameof(GetOrder), new { id = orderDto.Order_Id }, orderDto);
        }

        /// <summary>
        /// Uploads a CSV file and imports the data into the database.
        /// </summary>
        /// <param name="file">The CSV file to upload.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (!file.FileName.EndsWith(".csv"))
            {
                return BadRequest("Please upload a valid CSV file.");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Optional: Configure CSV reader settings here
                MissingFieldFound = null, // Ignore missing fields
                BadDataFound = null, // Ignore bad data
                HasHeaderRecord = true // Specify that the first row is a header
            }))
            {
                var records = csv.GetRecords<OrderCreateDto>(); // Adjust to your DTO

                // Process the records (e.g., save to the database)
                foreach (var record in records)
                {
                    var order = _mapper.Map<Orders>(record);
                    await _orderService.CreateOrderAsync(order);
                }
            }

            return Ok("File uploaded and data imported successfully.");
        }
    }
}

