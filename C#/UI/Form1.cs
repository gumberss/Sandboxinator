using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            await OtherWay();
        }

        private async Task OtherWay()
        {
            while (true)
            {
                await Task.Delay(100);
                TimeSpan time = sw.Elapsed;
                textBox1.Text = $"{time.Minutes:00}:{time.Seconds:00}:{time.Milliseconds:0000}";
            }
        }

        private void UsingTasks()
        {
            Task.Factory.StartNew(() =>
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
        }

        private void UsingThread()
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
