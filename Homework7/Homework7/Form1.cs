using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int depth = 10;
        double leng = 100;
        Pen pen = new Pen(Color.Black);
        int R=0; int G=0; int B=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            graphics = drawPanel.CreateGraphics();
            graphics.Clear(drawPanel.BackColor);

            drawCayleyTree(depth, drawPanel.Width / 2, drawPanel.Height, leng, -Math.PI / 2);
        }

        private void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PerRight_Scroll(object sender, EventArgs e)
        {
            per1 = PerRight.Value / (double)PerRight.Maximum;
        }

        private void PerLeft_Scroll(object sender, EventArgs e)
        {
            per2 = PerLeft.Value / (double)PerLeft.Maximum;
        }

        private void AngelRight_Scroll(object sender, EventArgs e)
        {
            th1 = AngelRight.Value * Math.PI / 180;
        }

        private void AngelLeft_Scroll(object sender, EventArgs e)
        {
            th2 = AngelLeft.Value * Math.PI / 180;
        }

        private void RecursiveDepth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = RecursiveDepth.Text;
                if (text == "")
                    return;
                depth = int.Parse(text);
                if(depth > 0 && depth <= 30)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("请输入介于0到30之间的整数！");
                    RecursiveDepth.Text = RecursiveDepth.Text.Remove(0, RecursiveDepth.Text.Length);
                    RecursiveDepth.SelectionStart = RecursiveDepth.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入介于0到30之间的整数！");
                RecursiveDepth.Text = RecursiveDepth.Text.Remove(0, RecursiveDepth.Text.Length);
                RecursiveDepth.SelectionStart = RecursiveDepth.Text.Length;
            }
        }

        private void TrunkLength_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = TrunkLength.Text;
                if (text == "")
                    return;
                leng = int.Parse(text);
                if (leng > 0 && leng <= 200)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("请输入介于0到200之间的整数！");
                    TrunkLength.Text = TrunkLength.Text.Remove(0, TrunkLength.Text.Length);
                    TrunkLength.SelectionStart = TrunkLength.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入介于0到200之间的整数！");
                TrunkLength.Text = TrunkLength.Text.Remove(0, TrunkLength.Text.Length);
                TrunkLength.SelectionStart = TrunkLength.Text.Length;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pen.Color = Color.Black;
                    break;
                case 1:
                    pen.Color = Color.Red;
                    break;
                case 2:
                    pen.Color = Color.Yellow;
                    break;
                case 3:
                    pen.Color = Color.Green;
                    break;
                case 4:
                    pen.Color = Color.Blue;
                    break;
                case 5:
                    pen.Color = Color.Purple;
                    break;
                case 6:
                    pen.Color = Color.FromArgb(R, G, B);
                    break;
            }
        }

        private void Red_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = Red.Text;
                R = int.Parse(text);
                if (R >= 0 && R < 256) return;
                else MessageBox.Show("请输入介于0到255之间的整数！");
            }
            catch (Exception) { MessageBox.Show("请输入介于0到256之间的整数！"); }
        }

        private void Green_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = Green.Text;
                G = int.Parse(text);
                if (G >= 0 && G < 256) return;
                else MessageBox.Show("请输入介于0到255之间的整数！");
            }
            catch (Exception) { MessageBox.Show("请输入介于0到256之间的整数！"); }
        }

        private void Blue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = Blue.Text;
                B = int.Parse(text);
                if (B >= 0 && B < 256) return;
                else MessageBox.Show("请输入介于0到255之间的整数！");
            }
            catch (Exception) { MessageBox.Show("请输入介于0到256之间的整数！"); }
        }
    }
}
