using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace chm3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int IER = 0;
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            if (a >= b)
            {
                IER = 2;
            }
            else
            {
                double A = Convert.ToDouble(textBox3.Text);
                double B = Convert.ToDouble(textBox4.Text);
                double C = Convert.ToDouble(textBox5.Text);
                int N = Convert.ToInt32(textBox6.Text);
                double h = -((b - a) / N);
                double eps = Convert.ToDouble(textBox7.Text);
                int Kmax = Convert.ToInt32(textBox8.Text);
                double alfai = Convert.ToDouble(textBox9.Text);
                double alfai1 = 0;
                double x = b;
                double fi = 0;
                int k = 0;
                bool end = false;

                double w0 = alfai;
                double v0 = C;
                double u0 = B;

                double w1 = 0;
                double v1 = 0;
                double u1 = 0;
                
                Solve s = new Solve();
                FindAlpha fa = new FindAlpha();

                s.solve(b, N, x, ref w0, ref v0, ref u0, h, ref w1, ref v1, ref u1);
                fi = u0 - A;
                if (Math.Abs(fi) < eps)
                {
                    end = true;
                }
                else
                {
                    while ((!end)&&k<=Kmax)
                    {
                        u0 = 0;
                        v0 = 0;
                        w0 = 1;
                        fa.solve(b, N, ref w0, ref v0, ref u0, h, ref w1, ref v1, ref u1);
                        alfai1 = alfai - (fi / u0);
                        k++;
                        x = b;
                        w0 = alfai1;
                        v0 = C;
                        u0 = B;
                        s.solve(b, N, x, ref w0, ref v0, ref u0, h, ref w1, ref v1, ref u1);
                        fi = u0 - A;
                        if (Math.Abs(fi) < eps)
                        {
                            end = true;
                        }
                    }
                }

                x = b;
                w0 = alfai1;
                v0 = C;
                u0 = B;
                for (int i = 0; i <= N; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(x);
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(u0);
                    dataGridView1.Rows[i].Cells[2].Value = Convert.ToString(v0);
                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToString(w0);
                    dataGridView1.Rows[i].Cells[4].Value = Convert.ToString(Math.Abs(u0 - s.y(x)));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Abs(v0 - s.y1(x, u0)));
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Abs(w0 - s.y2(x, u0, v0)));
                    s.Euler(x, w0, v0, u0, h, ref w1, ref v1, ref u1);
                    w0 = w1;
                    v0 = v1;
                    u0 = u1;
                    x = x + h;
                }
                textBox10.Text = Convert.ToString(alfai1);
                textBox11.Text = Convert.ToString(k);
                if (k > Kmax)
                {
                    IER = 1;
                }
            }
            textBox12.Text = Convert.ToString(IER);
        }        
    }
}