using CsvHelper.Configuration;
using CsvHelper;
using PizzaSalesAPI.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace PizzaSalesAPI.Services
{
    /// <summary>
    /// Provides functionality for importing orders from a CSV file into the database.
    /// </summary>
    public class CsvImportService
    {
        private readonly PizzaSalesContext _context; // Dependency injection of the database context
        private const int BatchSize = 1000; // Define the batch size for processing records

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvImportService"/> class.
        /// </summary>
        /// <param name="context">The context used to access the database.</param>
        public CsvImportService(PizzaSalesContext context)
        {
            _context = context; // Initialize the context
        }

        /// <summary>
        /// Asynchronously imports orders from a CSV file into the database.
        /// </summary>
        /// <param name="filePath">The path to the CSV file containing the orders.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task ImportCsvAsync(string filePath)
        {
            // Configuration for reading CSV files with case-insensitive headers
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(), // Convert headers to lowercase for matching
                MissingFieldFound = null // Ignore missing fields in the CSV
            };

            // Open the file for reading
            using (var reader = new StreamReader(filePath))
            // Initialize the CSV reader with the configuration
            using (var csv = new CsvReader(reader, config))
            {
                var records = new List<Orders>(); // Initialize a list to hold the records

                // Asynchronously read records from the CSV file
                await foreach (var record in csv.GetRecordsAsync<Orders>())
                {
                    records.Add(record); // Add the current record to the list

                    // Check if the batch size limit is reached
                    if (records.Count >= BatchSize)
                    {
                        await SaveBatchAsync(records); // Save the current batch to the database
                        records.Clear(); // Clear the list for the next batch
                    }
                }

                // Save any remaining records that did not fill a complete batch
                if (records.Any())
                {
                    await SaveBatchAsync(records);
                }
            }
        }

        /// <summary>
        /// Asynchronously saves a batch of order records to the database.
        /// </summary>
        /// <param name="records">The list of <see cref="Orders"/> objects to save.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task SaveBatchAsync(List<Orders> records)
        {
            decimal totalPrice = 0;
            foreach (var record in records)
            {
                // Create a new order entity with the provided data
                var order = new Orders
                {
                    Date = record.Date,
                    Order_Details = new List<OrderDetails>()
                };

                foreach (var o in record.Order_Details)
                {
                    // Check if the pizza already exists in the database
                    var pizza = await _context.Pizzas
                        .FirstOrDefaultAsync(p => p.Pizza_Id == o.Pizza_Id);

                    // If the pizza does not exist, create a new pizza entity
                    if (pizza == null)
                    {
                        pizza = new Pizza // Create a new pizza entity
                        {
                            Pizza_Id = o.Pizza_Id,
                            // Other properties should be set appropriately
                        };
                        await _context.Pizzas.AddAsync(pizza); // Add the new pizza to the database
                    }

                    order.Order_Details.Add(new OrderDetails
                    {
                        Pizza = pizza,
                        Quantity = o.Quantity,
                    });

                    totalPrice += (o.Quantity * pizza.Price);
                }

                order.TotalPrice = totalPrice;

                await _context.Orders.AddAsync(order); // Add the new order to the database
            }

            await _context.SaveChangesAsync(); // Save changes to the database
        }
    }

}
