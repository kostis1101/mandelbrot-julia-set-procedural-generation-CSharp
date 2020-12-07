using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace mandelbrot_julia_set_tutorial
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black);
        Graphics g;

        Color white = Color.White;

        public Form1()
        {
            InitializeComponent();
        }

        private void draw(object sender, PaintEventArgs e)
        {
            g = drawPanel.CreateGraphics();
            /*
            g.DrawRectangle(pen, 100, 100, .5f, .5f);*/

            Thread generateThread = new Thread(() => generateMandelbrotsetHalo(100, 200, Color.LightBlue, 1000));

            Console.WriteLine(Color.White.R);

            generateThread.Start();
            generateThread.Join();
        }

        void generateMandelbrotset(int iturations, int size)
        {
            int Height = drawPanel.Height;
            int Width = drawPanel.Width;

            for (float x = -Width / 2; x < Width / 2; x++)
            {
                for (float y = -Height / 2; y < Height / 2; y++)
                {
                    float r = x / size;
                    float i = -y / size;

                    float[] c = { r, i };

                    if (containsMandelbrotset(c, iturations))
                    {
                        pen.Color = Color.White;
                    }
                    else
                    {
                        pen.Color = Color.Black;
                    }

                    g.DrawRectangle(pen, x + Width / 2, y + Height / 2, .5f, .5f);
                }
            }
        }
        void generateMandelbrotsetHalo(int iturations, int size, Color colour, int brightness = 255)
        {
            int Height = drawPanel.Height;
            int Width = drawPanel.Width;

            for (float x = -Width / 2; x < Width / 2; x++)
            {
                for (float y = -Height / 2; y < Height / 2; y++)
                {
                    float r = x / size;
                    float i = -y / size;

                    float[] c = { r, i };

                    int value = (int)(brightness / iturations * escapingMandelbrotset(c, iturations));

                    if (value > 255)
                        value = 255;

                    pen.Color = Color.FromArgb(value * colour.R / 255, value * colour.G / 255, value * colour.B / 255);


                    g.DrawRectangle(pen, x + Width / 2, y + Height / 2, .5f, .5f);
                }
            }
        }

        void generateJuliaset(int iturations, int size, float re, float im)
        {
            int Height = drawPanel.Height;
            int Width = drawPanel.Width;

            for (float x = -Width / 2; x < Width / 2; x++)
            {
                for (float y = -Height / 2; y < Height / 2; y++)
                {
                    float r = x / size;
                    float i = -y / size;

                    float[] z = { r, i };
                    float[] c = { re, im };

                    if (containsJuliaset(z, c, iturations))
                    {
                        pen.Color = Color.White;
                    }
                    else
                    {
                        pen.Color = Color.Black;
                    }

                    g.DrawRectangle(pen, x + Width / 2, y + Height / 2, .5f, .5f);
                }
            }
        }
        void generateJuliasetHalo()
        {
            float size = 300;

            int Height = drawPanel.Height;
            int Width = drawPanel.Width;

            for (float x = -Width / 2; x < Width / 2; x++)
            {
                for (float y = -Height / 2; y < Height / 2; y++)
                {
                    float r = x / size;
                    float i = -y / size;

                    int iturations = 200;

                    float[] z = { r, i };
                    float[] c = { 0, -0.8f };

                    float brightness = 3;
                    
                    int value = (int) (brightness * 255f / iturations * escapingJuliaset(z, c, iturations));

                    if (value > 255)
                        value = 255;

                    pen.Color = Color.FromArgb(value, 0, 0);



                    /*if (containsJuliaset(z, c, iturations))
                    {
                        pen.Color = Color.White;
                    }
                    else
                    {
                        pen.Color = Color.Black;
                    }*/

                    g.DrawRectangle(pen, x + Width / 2, y + Height / 2, .5f, .5f);
                }
            }
        }


        #region Mandelbort set
        bool containsMandelbrotset(float[] c, int iturations)
        {
            float[] z = { 0, 0 };

            for (int i = 0; i < iturations; i++)
            {
                // z = z^2 + c

                z = add(square(z), c);

                // sqrt(r*r + i*i)
                if (Math.Sqrt(z[0] * z[0] + z[1] * z[1]) > 2)
                {
                    return false;
                }
            }

            return true;
        }

        int escapingMandelbrotset(float[] c, int iturations)
        {
            float[] z = { 0, 0 };

            for (int i = 0; i < iturations; i++)
            {
                // z = z^2 + c

                z = add(square(z), c);

                // sqrt(r*r + i*i)
                if (Math.Sqrt(z[0] * z[0] + z[1] * z[1]) > 2)
                {
                    return i;
                }
            }

            return iturations;
        }
        #endregion

        #region julia set
        bool containsJuliaset(float[] z, float[] c, int iturations)
        {
            for (int i = 0; i < iturations; i++)
            {
                // z = z^2 + c

                z = add(square(z), c);

                // sqrt(r*r + i*i)
                if (Math.Sqrt(z[0] * z[0] + z[1] * z[1]) > 2)
                {
                    return false;
                }
            }

            return true;
        }

        int escapingJuliaset(float[] z, float[] c, int iturations)
        {
            for (int i = 0; i < iturations; i++)
            {
                // z = z^2 + c

                z = add(square(z), c);

                // sqrt(r*r + i*i)
                if (Math.Sqrt(z[0] * z[0] + z[1] * z[1]) > 2)
                {
                    return i;
                }
            }

            return iturations;
        }
        #endregion

        float[] square(float[] z)
        {
            float[] result = new float[2];

            result[0] = z[0] * z[0] - z[1] * z[1];
            result[1] = 2 * z[0] * z[1];

            return result;
        }

        float[] add(float[] z, float[] c)
        {
            // z + c

            float[] result = new float[2];

            result[0] = z[0] + c[0];
            result[1] = z[1] + c[1];

            return result;
        }
    }
}
