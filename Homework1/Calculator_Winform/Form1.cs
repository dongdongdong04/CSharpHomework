using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double temp1, temp2;
        short pos = 0;
        string temp1_string = "";
        string temp2_string = "";
        double result = 0;

        public void add_sign(char sign)
        {
            textBox1.Text = textBox1.Text + sign;
            if (pos == 0)
            {
                temp1_string = temp1_string + sign;
            }
            if (pos != 0)
            {
                temp2_string = temp2_string + sign;
            }
        }

        public static double DoOperation(double num1, double num2, short op)
        {
            double result = double.NaN;

            switch (op)
            {
                case (short)'+':
                    result = num1 + num2;
                    break;
                case (short)'-':
                    result = num1 - num2;
                    break;
                case (short)'*':
                    result = num1 * num2;
                    break;
                case (short)'/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonNum0_Click(object sender, EventArgs e)
        {
            add_sign('0');
        }

        private void ButtonNum1_Click(object sender, EventArgs e)
        {
            add_sign('1');
        }

        private void ButtonNum2_Click(object sender, EventArgs e)
        {
            add_sign('2');
        }

        private void ButtonNum3_Click(object sender, EventArgs e)
        {
            add_sign('3');
        }

        private void ButtonNum4_Click(object sender, EventArgs e)
        {
            add_sign('4');
        }

        private void ButtonNum5_Click(object sender, EventArgs e)
        {
            add_sign('5');
        }

        private void ButtonNum6_Click(object sender, EventArgs e)
        {
            add_sign('6');
        }

        private void ButtonNum7_Click(object sender, EventArgs e)
        {
            add_sign('7');
        }

        private void ButtonNum8_Click(object sender, EventArgs e)
        {
            add_sign('8');
        }

        private void ButtonNum9_Click(object sender, EventArgs e)
        {
            add_sign('9');
        }

        private void ButtonPoint_Click(object sender, EventArgs e)
        {
            add_sign('.');
        }

        private void PosAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " + ";
            pos = (short)'+';
        }

        private void PosSub_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " - ";
            pos = (short)'-';
        }

        private void PosMul_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " * ";
            pos = (short)'*';
        }

        private void PosDiv_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " / ";
            pos = (short)'/';
        }

        private void PosIs_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + " = ";

            temp1 = Convert.ToDouble(temp1_string);
            temp2 = Convert.ToDouble(temp2_string);

            result = DoOperation(temp1, temp2, pos);
            if (double.IsNaN(result))
            {
                textBox1.Text = "This operation will result in a mathematical error.";
            }
            else textBox1.Text = textBox1.Text + result.ToString();

        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            temp1 = 0;
            temp2 = 0;
            pos = 0;
            temp1_string = "";
            temp2_string = "";
        }
    }
}
