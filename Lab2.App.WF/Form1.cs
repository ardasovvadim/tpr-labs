using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Lab2.Data;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Lab2.App.WF
{
    public class OrderRow
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
    }

    public partial class Form1 : Form
    {
        private List<OrderRow> rows;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            using (var context = new AppDbContext())
            {
                var orderRows = context.OrderProducts
                    .Select(o => new OrderRow
                    {
                        OrderId = o.OrderId,
                        ProductName = o.Product.Name,
                        Quantity = o.Quantity,
                        OrderTime = o.Order.OrderTime,
                        CustomerName = o.Order.Customer.Name
                    })
                    .ToList();
                
                dataGridView1.DataSource = orderRows;
                rows = orderRows;
            }
        }

        private void oleDbConnection1_InfoMessage(object sender, OleDbInfoMessageEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rows == null || !rows.Any())
                return;

            var app = new Application {Visible = true};
            var wb = app.Workbooks.Add(1);
            var ws = (Worksheet) wb.Sheets.Item[1];
            ws.Cells[1, 1] = "OrderId";
            ws.Cells[1, 2] = "ProductName";
            ws.Cells[1, 3] = "CustomerName";
            ws.Cells[1, 4] = "Quantity";
            ws.Cells[1, 5] = "OrderTime";
            for (var i = 0; i < rows.Count; i++)
            {
                ws.Cells[i + 2, 1] = rows[i].OrderId;
                ws.Cells[i + 2, 2] = rows[i].ProductName;
                ws.Cells[i + 2, 3] = rows[i].CustomerName;
                ws.Cells[i + 2, 4] = rows[i].Quantity;
                ws.Cells[i + 2, 5] = rows[i].OrderTime.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var textParts = textBox1.Text.Split(' ');

            if (textParts.Length != 4)
            {
                MessageBox.Show("Wrong data format");
                return;
            }

            var orderId = 0;
            var productName = "";
            var customerName = "";
            var quantity = 0;
            try
            {
                orderId = int.Parse(textParts[0]);
                productName = textParts[1];
                customerName = textParts[2];
                quantity = int.Parse(textParts[3]);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong data format");
                return;
            }

            using (var context = new AppDbContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Name == productName);
                if (product == null)
                {
                    MessageBox.Show($"There is no such product {productName}");
                    return;
                }

                var customer = context.Customers.FirstOrDefault(p => p.Name == customerName);
                if (customer == null)
                {
                    MessageBox.Show($"There is no such customer {customerName}");
                    return;
                }

                if (product.Quantity - quantity < 0)
                {
                    MessageBox.Show($"There is not enough products ({product.Quantity})");
                    return;
                }

                var order = context.Orders.FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    order = new Order
                    {
                        Id = orderId,
                        Customer = customer
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();
                }

                context.OrderProducts.Add(new OrderProduct
                {
                    Order = order,
                    Product = product,
                    Quantity = quantity
                });
                product.Quantity -= quantity;
                context.SaveChanges();
            }

            ReloadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var app = new Application {Visible = true};
            var wb = app.Workbooks.Add(1);
            var ws = (Worksheet) wb.Sheets.get_Item(1);
            ws.Cells[1, 1] = "ProductId";
            ws.Cells[1, 2] = "ProductName";
            ws.Cells[1, 3] = "Quantity sold";
            ws.Cells[1, 4] = "Price";
            ws.Cells[1, 5] = "Total income";
            ws.Cells[1, 6] = "Amount of deals";
            ws.Cells[1, 7] = "Stock";
            using (var context = new AppDbContext())
            {
                var products = context.Products.ToList();
                for (var i = 0; i < products.Count; i++)
                {
                    ws.Cells[i + 2, 1] = products[i].Id;
                    ws.Cells[i + 2, 2] = products[i].Name;
                    var productId = products[i].Id;
                    var collection = context.OrderProducts.Where(p => p.ProductId == productId).ToList();
                    var quantitySold = collection.Sum(p => p.Quantity); 
                    ws.Cells[i + 2, 3] = quantitySold;
                    ws.Cells[i + 2, 4] = products[i].Price;
                    ws.Cells[i + 2, 5] = products[i].Price * quantitySold;
                    ws.Cells[i + 2, 6] = collection.Count;
                    ws.Cells[i + 2, 7] = products[i].Quantity;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var app = new Application {Visible = true};
            var wb = app.Workbooks.Add(1);
            var ws = (Worksheet) wb.Sheets.get_Item(1);
            ws.Cells[1, 1] = "ProductId";
            ws.Cells[1, 2] = "ProductName";
            ws.Cells[1, 3] = "Stock";
            ws.Cells[1, 4] = "Price";
            using (var context = new AppDbContext())
            {
                var products = context.Products.ToList();
                for (var i = 0; i < products.Count; i++)
                {
                    ws.Cells[i + 2, 1] = products[i].Id;
                    ws.Cells[i + 2, 2] = products[i].Name;
                    ws.Cells[i + 2, 3] = products[i].Quantity;
                    ws.Cells[i + 2, 4] = products[i].Price;
                }
            }
        }
    }
}