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
        Form1 f1;
        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }

        int timercount = 0;
        int pressurecount = 300;
        int speed;

        public double process_time(double thickness)
        {
            double p_time;
            p_time = (60 * thickness / speed);
            return p_time;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(worker);
            isRunning = true;
            thread.Start();


            if (f1.SI.Checked)
            {
                dataGridView1.Rows.Add("O2", "5");
                dataGridView1.Rows.Add("SF6", "50");
                textBox1.Text = "10";
                speed = 2200;
            }
            if (f1.SiO2.Checked)
            {
                dataGridView1.Rows.Add("C4F8", "90");
                dataGridView1.Rows.Add("SF6", "30");
                textBox1.Text = "9";
                speed = 150;
            }
            if (f1.Si3N4.Checked)
            {
                dataGridView1.Rows.Add("CF4", "50");
                dataGridView1.Rows.Add("O2", "10");
                textBox1.Text = "1";
                speed = 200;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            while (true)
            {
                textBox2.Text = (timercount++).ToString();
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

        bool isRunning = false;
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
    }
}
