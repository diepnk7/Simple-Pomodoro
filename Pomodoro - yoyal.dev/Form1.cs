using System;
using System.Windows.Forms;
using System.Media;
namespace Pomodoro___yoyal.dev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 24;
        int j = 60;
        public void timer1_Tick(object sender, EventArgs e)
        {
            j--;
            label4.Text = j.ToString().PadLeft(2, '0');
            label2.Text = i.ToString().PadLeft(2, '0');
            if (j == 0)
            {
                i--;
                label2.Text = i.ToString().PadLeft(2, '0');
                // reset second number
                j = 60;
                if (i == 0)
                {
                    timer1.Stop();
                    Form2 fm = new Form2();
                    fm.Show();
                }
            }
            
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            
            if (!timer1.Enabled)
            {
                try
                {
                    //25 minutes to focus
                    SoundPlayer focus_sound = new SoundPlayer("focus_sound.wav");
                    focus_sound.Play();
                }
                catch (Exception)
                {
                    goto resume;
                    throw;
                }
            resume:
                btnStart.Text = "Stop";
                timer1.Start();
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                btnStart.Text = "Start";
                Application.Restart();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            //play relax sound
            SoundPlayer relax_sound = new SoundPlayer("relax_sound.wav");
            //click to pause or resume
            if (!timer1.Enabled)
            {
                btnPause.Text = "Pause";
                try
                {
                    relax_sound.Stop();
                }
                catch (Exception)
                {
                    goto start;
                    throw;
                }
                start: 
                timer1.Start();
            }
            else
            {
                btnPause.Text = "Resume";
                try
                {
                    relax_sound.Play();
                }
                catch (Exception)
                {
                    goto stop;
                    throw;
                }
                    stop:
                    timer1.Stop();     
            }
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelMininize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
