using System;
using System.Windows.Forms;
using System.Media;

namespace Pomodoro___yoyal.dev
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //play relax sound
            SoundPlayer relax_sound = new SoundPlayer("relax_sound.wav");
            try
            {
                relax_sound.Play();
            }
            catch (Exception)
            {
                goto next;
                throw;
            }
            next:
            InitializeComponent();
        }
        //lock and add shortcut key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt & Keys.F4) || keyData == (Keys.Alt | Keys.F4))
            {
                return true;
            }
            if (keyData == (Keys.Alt & Keys.B) || keyData == (Keys.Alt | Keys.B))
            {
                Form3 fm = new Form3();
                fm.Show();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //5 minutes to relax
        int i = 300;
        private void timer2_Tick(object sender, EventArgs e)
        {
            i--;
            if (i == 3)
            {
                SoundPlayer notif_sound = new SoundPlayer("notif.wav");
                try
                {
                    notif_sound.Play();
                }
                catch (Exception)
                {
                    goto exit;
                    throw;
                }  
            }
            exit:
            if (i == 0)
            {
                Application.Restart();
            }
        }
        private void Form2_Click(object sender, EventArgs e)
        {
            
        }
    }               
}
