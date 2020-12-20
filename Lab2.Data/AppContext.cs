using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Lab2.Data
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; } = 0;
	}
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
	}
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public virtual ICollection<Customer> Customers { get; set; }
		public DateTime OrderTime { get; set; } = DateTime.Now;
	}
	public class OrderProduct
	{
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Quantity { get; set; } = 0;
	}
	public class AppContext : DbContext
	{
	}
}
