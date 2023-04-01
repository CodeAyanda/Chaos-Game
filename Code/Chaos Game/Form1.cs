using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaos_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int width = Screen.PrimaryScreen.Bounds.Width;
        int height = Screen.PrimaryScreen.Bounds.Height;
        int size = 2;
        int numPoints = 3;
        Pen white = new Pen(Color.White);
        SolidBrush fill = new SolidBrush(Color.White);

        private void Draw(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            Graphics g = e.Graphics;
            Point[] startingPoints = new Point[numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                Point newPoint = new Point(rnd.Next(0, width), rnd.Next(0, height));
                startingPoints[i] = newPoint;
                g.FillEllipse(fill, startingPoints[i].X, startingPoints[i].Y, size, size);

            }

            Point global = new Point(rnd.Next(0, width), rnd.Next(0, height));
            g.DrawEllipse(white, global.X, global.Y, size, size);

            List<Point> points = new List<Point>();
            int tryy = 0;

            while (points.Count < 20000 && tryy < 200)
            {
                int lerp = rnd.Next(numPoints);
                global = new Point((startingPoints[lerp].X + global.X) / 2, (startingPoints[lerp].Y + global.Y) / 2);
                if (!points.Contains(global))
                {
                    points.Add(global);
                    g.FillEllipse(fill, global.X, global.Y, size, size);
                    tryy = 0;
                }
                else
                {
                    tryy++;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
