using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        Stopwatch sw;
        public Form1()
        {
            InitializeComponent();
            sw = new Stopwatch();
            sw.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    TimeSpan time = sw.Elapsed;

                    this.Invoke((Action)delegate
                    {
                        textBox1.Text = $"{time.Minutes:00}:{time.Seconds:00}:{time.Milliseconds:0000}";
                    });

                }
            });
            t.Start();
        }

    }
}
