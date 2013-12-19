using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chm3
{
    class Solve
    {
        public double func(double x, double u, double u1, double u2)
        {
            //return 2*x+u2;
            return 0;
            //return 0;
            //return 24 * x + 6;
        }

        public double y(double x)
        {
            //return 1 / 3.0 * (-x * x * x - 3 * x * x + Math.E * x + 9 * x - Math.Pow(Math.E, x) + 1);
            return x * x;
            //return x + 1;
            //return x * x * x * x + x * x * x + x * x + x + 1;
        }

        public double y1(double x, double u)
        {
            //return 1 / 3.0 * (-3 * x * x - 6 * x + Math.E + 9 - Math.Pow(Math.E, x));
            return 2 * x;
            //return 1;
            //return 4 * x * x * x + 3 * x * x + 2 * x + 1;
        }

        public double y2(double x, double u, double u1)
        {
            //return 1 / 3.0 * (-6 * x - 6 - Math.Pow(Math.E, x));
            return 2;
            //return 0;
            //return 12 * x * x + 6 * x + 2;
        }

        public void Euler(double x, double w0, double v0, double u0, double h, ref double w1, ref double v1, ref double u1)
        {
            w1 = w0 + h * func(x, u0, v0, w0);
            v1 = v0 + h * w0;
            u1 = u0 + h * v0;
        }

        public void solve(double b, int N, double x, ref double w0, ref double v0, ref double u0, double h, ref double w1, ref double v1, ref double u1)
        {
            for (int i = 1; i <= N; i++)
            {
                Euler(x, w0, v0, u0, h, ref w1, ref v1, ref u1);
                w0 = w1;
                v0 = v1;
                u0 = u1;
                x = b + i * h;
            }
        }
    }
}