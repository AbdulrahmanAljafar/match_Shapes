using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W03D05
{
    public partial class Form1 : Form
    {
       
        int x = 0, y = 0;
        int x1 = 0, y1 = 0;
        bool isselect = false;
        bool isselect2 = false;
        bool ismarg = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isselect)
            {
                this.x = e.X;
                this.y = e.Y;
                this.Invalidate();
            }

            if (isselect2)
            {
                this.x1 = e.Location.X -150;
                this.y1 = e.Location.Y- 150;
                this.Invalidate();
            }
            if ((this.x >= this.x1 +90 && this.x <= this.x1 + 210) && (isselect || isselect2) && (this.y > this.y1+90 && this.y < this.y1+210))
            {
                this.x = this.x1 +150;
                this.y = this.y1 + 100;
                this.ismarg = true;
                this.Invalidate();
            }
            else
            {
                this.ismarg = false;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isselect = false;
            isselect2 = false;
        }
        private bool first_shape(MouseEventArgs e)
        {
            var rect1 = new System.Drawing.Rectangle(this.x, this.y, 150, 100);
            var rect2 = new System.Drawing.Rectangle(e.X, e.Y, 10, 10);
            bool firstCheck = rect1.IntersectsWith(rect2);
            return firstCheck;

        }

        private bool secand_shape(MouseEventArgs e)
        {
            var rect3 = new System.Drawing.Rectangle(this.x1 + 150, this.y1 + 150, 100, 100);

            var rect4 = new System.Drawing.Rectangle(e.Location.X, e.Location.Y, 1, 1);
            bool secandCheck = rect3.IntersectsWith(rect4);
            return secandCheck;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (first_shape(e))
            {
                isselect = true;

            }
            
            if (secand_shape(e))
            {
                isselect2 = true;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            

            // Create a graphics path  
            GraphicsPath path = new GraphicsPath();
            GraphicsPath path0 = new GraphicsPath();

            // Add two lines, a rectangle and an ellipse  
            path.AddRectangle(new Rectangle(x, y, 50, 50));
            path.AddRectangle(new Rectangle(x+50, y, 50, 50));
            path.AddRectangle(new Rectangle(x+100, y, 50, 50));
            path.AddRectangle(new Rectangle(x+50, y+50, 50, 50));
            path0.AddRectangle(new Rectangle(x,y, 50, 00));
            // Draw path  
            Pen redPen = new Pen(Color.Red, 2);
            g.DrawPath(redPen, path);
            path.CloseFigure();
            path0.CloseFigure();
            if (this.ismarg)
            {
                Pen blue1 = new Pen(Color.Blue, 2);
                g.DrawPath(blue1, path);
                g.FillPath(Brushes.LightSkyBlue,path);
            }





            // Create a graphics path  
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();
            // Add two lines, a rectangle and an ellipse  
            path1.AddRectangle(new Rectangle(x1+150, y1+150, 50, 50));
            //path1.AddRectangle(new Rectangle(200, 150, 50, 50));
            path1.AddRectangle(new Rectangle(x1+150, y1+200, 50, 50));
            path1.AddRectangle(new Rectangle(x1+200, y1+200, 50, 50));
            path1.AddRectangle(new Rectangle(x1+250, y1+200, 50, 50));
            path1.AddRectangle(new Rectangle(x1+250, y1+150, 50, 50));

            path2.AddRectangle(new Rectangle(x1+150, y1+150, 100, 100));

            // Draw path  
            Pen redPen1 = new Pen(Color.Red, 2);

            g.DrawPath(redPen1, path1);
            if (this.ismarg)
            {
                Pen green = new Pen(Color.Green, 2);
                g.DrawPath(green, path1);
                g.FillPath(Brushes.Orange, path1);
            }
            path1.CloseFigure();
            path2.CloseFigure();

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
