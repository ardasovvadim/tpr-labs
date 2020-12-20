using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2.Data;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace Lab3.App.WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var app = new Microsoft.Office.Interop.Excel.Application() {Visible = true};
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

        private void AddWordDocEndl(Document document)
        {
            document.Content.Paragraphs.Add(document.Bookmarks.get_Item("\\endofdoc").Range);
        }

        private void SetBorders(params Cell[] cells)
        {
            cells.ToList().ForEach(cell =>
            {
                cell.Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                cell.Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                cell.Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                cell.Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var app = new Microsoft.Office.Interop.Word.Application {Visible = true};
            var document = app.Documents.Add();
            var paragraph = document.Content.Paragraphs.Add();
            paragraph.Range.Text = "Products";
            AddWordDocEndl(document);
            using (var context = new AppDbContext())
            {
                var products = context.Products.ToList();
                var tableParagraph = document.Content.Paragraphs.Add();
                var table = document.Tables.Add(tableParagraph.Range, products.Count + 1, 4);
                table.Cell(1, 1).Range.Text = "Product Id";
                table.Cell(1, 2).Range.Text = "Product Name";
                table.Cell(1, 3).Range.Text = "Quantity";
                table.Cell(1, 4).Range.Text = "Price";
                SetBorders(table.Cell(1, 1), table.Cell(1, 2), table.Cell(1, 3), table.Cell(1, 4));
                for (var i = 0; i < products.Count; i++)
                {
                    table.Cell(2 + i, 1).Range.Text = products[i].Id.ToString();
                    table.Cell(2 + i, 2).Range.Text = products[i].Name;
                    table.Cell(2 + i, 3).Range.Text = products[i].Quantity.ToString();
                    table.Cell(2 + i, 4).Range.Text = products[i].Price.ToString();
                    SetBorders(table.Cell(2 + i, 1), table.Cell(2 + i, 2), table.Cell(2 + i, 3), table.Cell(2 + i, 4));
                }
            }
        }
    }
}