using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarlo
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random rnd = new Random();
        double[] pi = new double[2];
        int count;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (count > 0)
            {
                int rX = rnd.Next(400);
                int rY = rnd.Next(400);
                double d = Math.Sqrt(Math.Pow(rX - 200, 2) + Math.Pow(rY - 200, 2));
                g.DrawRectangle(Pens.Red, rX, rY, 1, 1);
                if (d <= 200)
                {
                    pi[0]++;
                }
                pi[1]++;
                label2.Text = $"PI = {Math.Round((pi[0] / pi[1]) * 4, 5)}";
                count--;
                textBox1.Text = count.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawEllipse(Pens.Black, 0, 0, 400, 400);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pi[0] = 0; pi[1] = 0;
            g.Clear(Color.White);
            g.DrawEllipse(Pens.Black, 0, 0, 400, 400);
            try
            {
                count = int.Parse(textBox1.Text);
                timer1.Enabled = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("There must be an integer");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
