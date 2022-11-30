using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HitHit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form signup = new Form2();
            signup.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form login = new Form3();
            login.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form signup = new Form2();
            signup.ShowDialog();
        }
        private void existingUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form login = new Form3();
            login.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            WindowState = FormWindowState.Maximized;
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, this.Height / 4 + button1.Height  );
            button2.Location = new Point(this.Width / 2 - button2.Width / 2, this.Height / 4 + button2.Height + 100);
            button3.Location = new Point(this.Width / 2 - button3.Width / 2, this.Height / 4 + button3.Height + 200);
            button4.Location = new Point(this.Width / 2 - button4.Width / 2, this.Height / 4 + button4.Height + 300);
            button5.Location = new Point(this.Width / 2 - button5.Width / 2, this.Height / 4 + button5.Height + 400);
            label2.Location = new Point(label2.Location.X, this.Height - 10 * label2.Height);
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 8);
        }
    }
}
