using Microsoft.EntityFrameworkCore;
using PizzaSalesAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PizzaSalesAPI
{
    /// <summary>
    /// Represents the database context for the pizza sales application, managing the Orders, Pizza, and OrderDetails entities.
    /// </summary>
    public class PizzaSalesContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PizzaSalesContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the database context.</param>
        public PizzaSalesContext(DbContextOptions<PizzaSalesContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet for orders in the database.
        /// </summary>
        public DbSet<Orders> Orders { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for pizzas in the database.
        /// </summary>
        public DbSet<Pizza> Pizzas { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for order details in the database.
        /// </summary>
        public DbSet<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Configures the entity relationships and constraints using the model builder.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the entity relationships.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            modelBuilder.Entity<Orders>()
                .HasKey(o => o.Order_Id);

            modelBuilder.Entity<Pizza>()
                .HasKey(p => p.Pizza_Id);

            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => od.Order_Details_Id);

            // Configure relationships
            modelBuilder.Entity<Orders>()
                .HasMany(o => o.Order_Details)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.Order_Id);

            modelBuilder.Entity<Pizza>()
                .HasMany(p => p.OrderDetails)
                .WithOne(od => od.Pizza)
                .HasForeignKey(od => od.Pizza_Id);

            // Configure indexes
            modelBuilder.Entity<Orders>()
                .HasIndex(o => o.Date);
        }
    }
}
