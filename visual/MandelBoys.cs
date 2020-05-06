using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace visual
{
    class MandelBoys
    {
        //static void Main(string[] args)
        //{
        //    // Complex number: a+ bi, where i is imaginary
        //    // imaginary: i^2 = -1, (bi)^2 -> -b^2
        //    // Create a complex number by calling its class constructor.
        //    Complex c1 = new Complex(-1, 0.7);
        //    Console.WriteLine(Color.FromArgb(1000000000));
        //    double x_axis_min = -2.0;
        //    double x_axis_max = 1.0;
        //    double y_axis_min = -1.0;
        //    double y_axis_max = 1.0;

        //    int x_pixels = 120;
        //    int y_pixels = 40;

        //    var output = MandelColors(x_pixels, y_pixels);
        //    for (int y = 0; y < y_pixels; y++)
        //    {
        //        for (int x = 0; x < x_pixels; x++)
        //        {
        //            double x_transf = x * 1.0 / (x_pixels - 1) * (x_axis_max - x_axis_min) + x_axis_min;
        //            double y_transf = y * 1.0 / (y_pixels - 1) * (y_axis_max - y_axis_min) + y_axis_min;
        //            Console.WriteLine($"{x},{y}=>{x_transf},{y_transf} | mandelbrot_color:{output[new Point(x, y)]}");

        //        }
        //    }
        //    Console.WriteLine(output);
        //    Console.ReadLine();
        //}

        public static Dictionary<Point, Color> MandelColors(int x_pixels, int y_pixels, double x_axis_min = -2.0, double x_axis_max = 1.0, double y_axis_min = -1.0, double y_axis_max = 1.0)
        {
            var colors = new Dictionary<Point, Color>();

            for (int y = 0; y < y_pixels; y++)
            {
                for (int x = 0; x < x_pixels; x++)
                {
                    double x_transf = x * 1.0 / (x_pixels - 1) * (x_axis_max - x_axis_min) + x_axis_min;
                    double y_transf = y * 1.0 / (y_pixels - 1) * (y_axis_max - y_axis_min) + y_axis_min;

                    int n_iters = IsInMandelBrot(x_transf, y_transf);
                    Color color = iters2color(n_iters);
                    //Console.WriteLine($"{x},{y}=>{x_transf},{y_transf} | iters {n_iters} | mandelbrot_color:{color}");
                    colors.Add(new Point(x, y), color);
                }
            }

            return colors;
        }

        static Complex MandelBrotStep(Complex z, Complex c)
        {
            return z * z + c;
        }

        static int IsInMandelBrot(double x, double y, int n_iters = 255, double threshold = 2)
        {

            Complex z = 0.0;
            Complex c = new Complex(x, y);
            for (int i = 0; i < n_iters; i++)
            {
                z = MandelBrotStep(z, c);
                //Console.WriteLine(i);
                //Console.WriteLine(z);
                //Console.WriteLine(Complex.Abs(z));
                if (Complex.Abs(z) > threshold)
                {
                    return i;
                }
            }

            return n_iters;
        }

        static Color iters2color(int n_iters, int max_n_iters = 255)
        {
            return Color.FromArgb(n_iters, n_iters, n_iters);
        }
    }
}
