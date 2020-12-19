using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1ATLLib;

namespace Lab1.WF
{
	public partial class Form1 : Form
	{
		private Lab1ATLLib.Math math;
		private int a;
		private int b;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			math = new Lab1ATLLib.Math();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CollectNubmers();
			PrintResult(math.Add(a, b));
		}

		private void PrintResult(int result) => textBox3.Text = result.ToString();

		private void CollectNubmers()
		{
			this.a = int.Parse(textBox1.Text);
			this.b = int.Parse(textBox2.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			CollectNubmers();
			PrintResult(math.Substract(a, b));
		}

		private void button3_Click(object sender, EventArgs e)
		{
			CollectNubmers();
			PrintResult(math.Multiply(a, b));
		}

		private void button4_Click(object sender, EventArgs e)
		{
			CollectNubmers();
			PrintResult(math.Divide(a, b));
		}
	}
}
