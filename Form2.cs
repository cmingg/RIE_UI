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
            Thread thread = new Thread(worker);
            isRunning = true;
            thread.Start();

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
            if (timercount == 20)
            {
                isRunning = false;
            }
        }

        bool isRunning = false;
        private void worker()
        {
            while(isRunning)
            {
                Thread.Sleep(1000);
                Debug.WriteLine("Thread working...");
                
                textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = "" + pressurecount++;  });
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("timer2 tick event...");
            textBox1.Text = "" + pressurecount++;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DrawColorBar(graphics, 0, 0, panel1.Width, panel1.Height, colorMap, "Jet");
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
    }
}
