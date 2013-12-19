using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chm3
{
    class FindAlpha
    {
        public double func(double u, double v, double w)
        {
            //return 0 * u + 0 * v + 1 * w;
            return 0 * u + 0 * v + 0 * w; 
        }

        public void Euler(double w0, double v0, double u0, double h, ref double w1, ref double v1, ref double u1)
        {
            w1 = w0 + h * func(u0, v0, w0);
            v1 = v0 + h * w0;
            u1 = u0 + h * v0;
        }

        public void solve(double b, int N, ref double w0, ref double v0, ref double u0, double h, ref double w1, ref double v1, ref double u1)
        {
            for (int i = 1; i <= N; i++)
            {
                Euler(w0, v0, u0, h, ref w1, ref v1, ref u1);
                w0 = w1;
                v0 = v1;
                u0 = u1;
            }
        }
    }
}