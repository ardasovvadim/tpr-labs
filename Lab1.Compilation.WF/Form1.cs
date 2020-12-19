using ComplexMathLib;
using System;
using System.Windows.Forms;

namespace Lab1.Compilation.WF
{
	public partial class Form1 : Form
	{
		private SimpleMath simpleMath;
		private ComplexMath complexMath;
		private double a;
		private double b;
		private double c;
		private double d;
		private double simpleA;
		private double simpleB;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			simpleMath = new SimpleMath();
			complexMath = new ComplexMath();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CollectComplexNumbers();
			complexMath.Add(a, b, c, d, out var res1, out var res2);
			PrintResults(res1, res2);
		}

		private void PrintResults(double res1, double res2)
		{
			textBoxRes1.Text = res1.ToString();
			textBoxRes2.Text = res2.ToString();
		}

		private void CollectComplexNumbers()
		{
			a = double.Parse(textBoxA.Text);
			b = double.Parse(textBoxB.Text);
			c = double.Parse(textBoxC.Text);
			d = double.Parse(textBoxD.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			CollectComplexNumbers();
			complexMath.Substract(a, b, c, d, out var res1, out var res2);
			PrintResults(res1, res2);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			CollectComplexNumbers();
			complexMath.Multiply(a, b, c, d, out var res1, out var res2);
			PrintResults(res1, res2);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			CollectComplexNumbers();
			complexMath.Divide(a, b, c, d, out var res1, out var res2);
			PrintResults(res1, res2);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			CollectSimpleNumbers();
			Print(simpleMath.Add(simpleA, simpleB));
		}

		private void Print(double v)
		{
			simpleTextBoxC.Text = v.ToString();
		}

		private void CollectSimpleNumbers()
		{
			simpleA = double.Parse(simpleTextBoxA.Text);
			simpleB = double.Parse(simpleTextBoxB.Text);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			CollectSimpleNumbers();
			Print(simpleMath.Substract(simpleA, simpleB));
		}

		private void button6_Click(object sender, EventArgs e)
		{
			CollectSimpleNumbers();
			Print(simpleMath.Multiply(simpleA, simpleB));
		}

		private void button5_Click(object sender, EventArgs e)
		{
			CollectSimpleNumbers();
			Print(simpleMath.Divide(simpleA, simpleB));
		}

		private void button9_Click(object sender, EventArgs e)
		{
			var a = double.Parse(tTextBox.Text);
			tTextBoxRes.Text = simpleMath.Sin(a).ToString();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			var a = double.Parse(tTextBox.Text);
			tTextBoxRes.Text = simpleMath.Sinh(a).ToString();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			var a = double.Parse(tTextBox.Text);
			tTextBoxRes.Text = simpleMath.Cos(a).ToString();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			var a = double.Parse(tTextBox.Text);
			tTextBoxRes.Text = simpleMath.Cosh(a).ToString();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			var a = double.Parse(tTextBox.Text);
			tTextBoxRes.Text = simpleMath.Tan(a).ToString();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			var a = double.Parse(tTextBox.Text);
			tTextBoxRes.Text = simpleMath.Tanh(a).ToString();
		}
	}
}
