using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab2.Data
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; } = 0;
		public double Price { get; set; } = 0.0;
		public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
	}
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
	}
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public virtual Customer Customer { get; set; }
		public int CustomerId { get; set; }
		public DateTime OrderTime { get; set; } = DateTime.Now;
		public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
	}
	public class OrderProduct
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Quantity { get; set; } = 0;
	}
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderProduct> OrderProducts { get; set; }
		public AppDbContext() : base("DbConnection")
		{
			Database.SetInitializer(new AppDbInitializer());
		}

	}
	public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext>
	{
		protected override void Seed(AppDbContext context)
		{
			var seedProducts = new List<Product>
			{
				new Product{Name = "Product1", Quantity = 10, Price = 1.1},
				new Product{Name = "Product2", Quantity = 20, Price = 5},
				new Product{Name = "Product3", Quantity = 5, Price = 14.99},
				new Product{Name = "Product4", Quantity = 15, Price = 9.99},
				new Product{Name = "Product5", Quantity = 10, Price = 6.45}
			};

			context.Products.AddRange(seedProducts);

			var seedCustomers = new List<Customer>
			{
				new Customer{Name = "Customer1", Number = "+380951234567"},
				new Customer{Name = "Customer2", Number = "+380955678458"},
				new Customer{Name = "Customer3", Number = "+380959612548"},
			};

			context.Customers.AddRange(seedCustomers);

			context.SaveChanges();

			var seedOrder = new Order
			{
				Customer = seedCustomers.First()
			};
			context.Orders.Add(seedOrder);
			context.SaveChanges();

			var seedOrderProducts = new List<OrderProduct>
			{
				new OrderProduct{Order = seedOrder, Product = seedProducts.First(), Quantity = 3},
				new OrderProduct{Order = seedOrder, Product = seedProducts.Last(), Quantity = 1}
			};

			context.OrderProducts.AddRange(seedOrderProducts);
			context.SaveChanges();

			base.Seed(context);
		}
	}
}
