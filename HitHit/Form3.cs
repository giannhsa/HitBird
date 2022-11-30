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
    public partial class Form3 : Form
    {
        bool passshow = false;
        string username, password;
        Users user1;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            user1 = new Users(null,0);               
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form signup = new Form2();
            signup.ShowDialog();
        }

        //show hide password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passshow = !passshow;
            if (passshow)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            //check if user is registered
           if (!user1.ValidateUser(username, password))
            {
                MessageBox.Show("Check username or password and try again!");
            }
           else
            {
                Form game = new Form4(username, user1.GetScore(username, password));
                game.Show();
                this.Close();
            }
        }
    }
}
