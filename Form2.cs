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

       double timercount = 0;
        double pt;

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

            if (pt<timercount)
            {
                label4.ForeColor = Color.Black;
                label4.Text = "공정 가스 배출 중";
            }
            if (timercount > (pt + 180))
            {
                timer1.Enabled = false;

                radioButton2.Checked = true;
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
