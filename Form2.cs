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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int timercount = 0;
        int pressurecount = 300;

        private void Form2_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(worker);
            isRunning = true;
            thread.Start();

            if (Form1.)
            {

            }
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
    }
}
