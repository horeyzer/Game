using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void FileOperation()
        {
            FileStream fs = new FileStream("game.txt", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(textBox1.Text + textBox2.Text);

            sw.Close();
            fs.Close();
        }

        void Check()
        {
            DialogResult dr = new DialogResult();
            if (pictureBox1.Left >= 1100 || pictureBox2.Left >= 1100)
            {
                button1.Enabled = false;
                timer1.Enabled = false;
                if (pictureBox1.Left > pictureBox2.Left)
                {
                    dr=MessageBox.Show("Winner is USER\nDo you want to record?", "MESSAGE", MessageBoxButtons.YesNo);
                }
                else
                {
                    dr=MessageBox.Show("Donate more to win\nDo you want to record?", "MESSAGE", MessageBoxButtons.YesNo);
                }
            }
            if (dr == DialogResult.Yes)
            {
                FileOperation();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Random r = new Random();

            pictureBox1.Left += r.Next(8, 15);
            textBox2.Text = pictureBox1.Left.ToString();
            Check();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            pictureBox2.Left += r.Next(-1, 5);

            Check();
        }
       

        
    }
}
