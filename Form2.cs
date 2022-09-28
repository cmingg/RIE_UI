﻿using System;
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
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        Form1 f1;
        ColorMap colorMap;
        double timercount = 0;
        double pt;
        double progress ;

        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;
            colorMap = new ColorMap();

        }


        public class items
        {
            public int pressure = 0;
            public int speed = 0;

            public items(int pressure, int speed)
            {
                this.pressure = pressure;
                this.speed = speed;
            }
        }

        public double process_time(double thickness, int speed)
        {
            double p_time;
            p_time = (600 * thickness / speed);
            return p_time;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Thread thread = new Thread(worker);
            //isRunning = true;
            //thread.Start();
            int a, b;

            if (f1.SI.Checked) 
            {
                dataGridView1.Rows.Add("O2", "5");
                dataGridView1.Rows.Add("SF6", "50");
                a = 10;
                b = 22000;
            }
            else if (f1.SiO2.Checked)
            {
                dataGridView1.Rows.Add("C4F8", "90");
                dataGridView1.Rows.Add("SF6", "30");
                a = 9;
                b = 450;
            }
            else
            {
                dataGridView1.Rows.Add("CF4", "50");
                dataGridView1.Rows.Add("O2", "10");
                a = 1;
                b = 4000;
            }
            items it = new items(a,b);
            textBox1.Text = it.pressure.ToString();
            label4.ForeColor = Color.Red;
            label4.Text = "공정 진행 중";

            pt = process_time(Convert.ToDouble(f1.textBox1.Text), it.speed);

           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = "" + timercount++;

            progress = timercount / (pt / 10);
            Debug.WriteLine(pt /10);

            if (pt<timercount)
            {
                label4.ForeColor = Color.Blue;
                label4.Text = "공정 가스 배출 중";
            }
            if (timercount > (pt + 5))
            {
                label4.ForeColor = Color.Black;
                label4.Text = "공정 종료";
                timer1.Enabled = false;

                radioButton2.Checked = true;

                if (MessageBox.Show("공정 종료","종료창",MessageBoxButtons.OK)==DialogResult.OK)
                {
                    this.Close();
                }
            }

            if (progress<9)
            {
                pn_wafer.Refresh();
            }
            //textBox2.Text = ""+timercount++;

            //if (timercount == 5)
            //{
            //    //timer2.Start();
            //}
            //if (timercount == 20)
            //{
            //    isRunning = false;
            //}
        }

        //bool isRunning = false;
        private void worker()
        {
            //while(isRunning)
            //{
            //    Thread.Sleep(1000);
            //    Debug.WriteLine("Thread working...");
                
            //    textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = "" + pressurecount++;  });
            //}
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Debug.WriteLine("timer2 tick event...");
            //textBox1.Text = "" + pressurecount++;
        }

        private void pn_wafer_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Silver;
            Rectangle rect = new Rectangle(0, 0, pn_wafer.Width, pn_wafer.Height);
            graphics.FillEllipse(brush, rect);
            int width = pn_wafer.Width;
            int height = pn_wafer.Height;
            int sx = (int)(width * 0.15);
            int sy = (int)(height * 0.15);
            Rectangle rect2 = new Rectangle(sx, sy, (int)(width * 0.7), (int)(height * 0.7));
            graphics.DrawRectangle(Pens.Black, rect2);

            // Scribe Line 그리기
            int xu = rect2.Width / 10;
            int yu = rect2.Height / 10;
            Pen pen = new Pen(Color.White, 1);
            for (int x = 1; x < 10; x++)
            {
                graphics.DrawLine(pen, new Point(sx + x * xu, sy), new Point(sx + x * xu, sy + rect2.Height));
            }
            for (int y = 1; y < 10; y++)
            {
                graphics.DrawLine(pen, new Point(sx, sy + y * yu), new Point(sx + rect2.Width, sy + y * yu));
            }

            Color color;
            if (progress < 1)
            {
                color = Color.FromArgb(210, 0, 0, 200);
                graphics.FillRectangle(new SolidBrush(color), rect2);

            }
            else if (progress < 2)
            {
                color = Color.FromArgb(210, 0, 51, 255);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 3)
            {
                color = Color.FromArgb(210, 0, 250, 250);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 4)
            {
                color = Color.FromArgb(210, 0, 250, 200);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 5)
            {
                color = Color.FromArgb(210, 0, 250, 0);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 6)
            {
                color = Color.FromArgb(210, 250, 250, 0);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 7)
            {
                color = Color.FromArgb(210, 250, 200, 0);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 8)
            {
                color = Color.FromArgb(210, 250, 50, 0);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
            else if (progress < 9)
            {
                color = Color.FromArgb(210, 200, 0, 0);
                graphics.FillRectangle(new SolidBrush(color), rect2);
            }
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
    }
}
