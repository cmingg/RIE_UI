using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Timers;
using System.Diagnostics;

namespace RIE_UI
{
    public partial class Form2 : Form
    {
        ColorMap colorMap;
        public Form2()
        {
            InitializeComponent();
            colorMap = new ColorMap();
        }

        int timercount = 0;
        int pressurecount = 300;

        private void Form2_Load(object sender, EventArgs e)
        {
            //if (Form1.)
            //{

            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = ""+timercount++;

            if (timercount == 5)
            {
                //timer2.Start();
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("timer2 tick event...");
            textBox1.Text = "" + pressurecount++;
        }

        private void pn_colormap_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DrawColorBar(graphics, 0, 0, pn_colormap.Width, pn_colormap.Height, colorMap, "Jet");
        }

        private void DrawColorBar(Graphics graphics, int x, int y, int width, int height, ColorMap colorMap, string text)
        {
            int[,] colorValueArray = new int[64, 4];

            switch (text)
            {
                case "Jet": colorValueArray = colorMap.GetJetColorValueArray(); break;
                case "Hot": colorValueArray = colorMap.GetHotColorValueArray(); break;
                case "Gray": colorValueArray = colorMap.GetGrayColorArray(); break;
                case "Cool": colorValueArray = colorMap.GetCoolColorValueArray(); break;
                case "Summer": colorValueArray = colorMap.GetSummerColorValueArray(); break;
                case "Autumn": colorValueArray = colorMap.GetAutumnColorValueArray(); break;
                case "Spring": colorValueArray = colorMap.GetSpringColorValueArray(); break;
                case "Winter": colorValueArray = colorMap.GetWinterColorValueArray(); break;
            }

            int minimumY = 0;
            int maximumY = 32;
            int deltaY = height / (maximumY - minimumY);
            int colorValueArrayLength = 64;

            for (int i = 0; i < 32; i++)
            {
                int colorIndex = (int)((i - minimumY) * colorValueArrayLength / (maximumY - minimumY));

                SolidBrush brush = new SolidBrush
                (
                    Color.FromArgb
                    (
                        colorValueArray[colorIndex, 0],
                        colorValueArray[colorIndex, 1],
                        colorValueArray[colorIndex, 2],
                        colorValueArray[colorIndex, 3]
                    )
                );

                graphics.FillRectangle(brush, x, y + i * deltaY, width, deltaY);
            }
        }

        private void pn_wafer_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Silver;
            Rectangle rect = new Rectangle(0, 0, pn_wafer.Width, pn_wafer.Height);
            graphics.FillEllipse(brush, rect);
            int width = pn_wafer.Width;     // wafer 그리기
            int height = pn_wafer.Height;
            int sx = (int)(width * 0.15);
            int sy = (int)(height * 0.15);
            Rectangle rect2 = new Rectangle(sx, sy, (int)(width * 0.7), (int)(height * 0.7));
            graphics.DrawRectangle(Pens.Black, rect2);
            // 
            int xu = rect2.Width / 10;
            int yu = rect2.Height / 10;
            Pen pen = new Pen(Color.DarkGray, 1);
            for (int x = 1; x < 10; x++)
            {
                graphics.DrawLine(pen, new Point(sx + x * xu, sy), new Point(sx + x * xu, sy + rect2.Height));
            }
            for (int y = 1; y < 10; y++)
            {
                graphics.DrawLine(pen, new Point(sx, sy + y * yu), new Point(sx + rect2.Width, sy + y * yu));
            }
        }
    }
}
