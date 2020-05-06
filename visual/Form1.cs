using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace visual
{
    public partial class Form1 : Form
    {
        Dictionary<Point, Color> images;
        public Form1()
        {
            InitializeComponent();
            Paint += mForm_Paint;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Brush aBrush = Brushes.Black;
            Graphics g = this.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, 500, 500);
            Bitmap grayBmp = new Bitmap(500, 500, PixelFormat.Format32bppRgb);
            for (int x = 0; x < 500; x++)
            {
                for (int y = 0; y < 500; y++)
                {
                    grayBmp.SetPixel(x, y, Color.Aqua);
                }
            }
            g.DrawImage(grayBmp, 0, 0);
        }

        private void mForm_Paint(object sender, PaintEventArgs e)
        {
            this.images = MandelBoys.MandelColors(this.ClientSize.Width, this.ClientSize.Height);
            Graphics g = this.CreateGraphics();
            Bitmap grayBmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height, PixelFormat.Format32bppRgb);
            for (int x = 0; x < this.ClientSize.Width; x++)
            {
                for (int y = 0; y < this.ClientSize.Height; y++)
                {
                    grayBmp.SetPixel(x, y, this.images[new Point(x,y)]);
                }
            }
            g.DrawImage(grayBmp, 0, 0);
        }
    }
}