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
    public partial class Form2 : Form
    {
        string username, password;
        string score = "0";
        bool passshow = false;
        bool haschar, passforb;
        Users user1;
        DialogResult result;
        public Form2()
        {
            InitializeComponent();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void checkBox1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            user1 = new Users(null,0);
        }

        //show and hide password
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
            //check username to not contain special characters
            for (int i = 0; i < username.Length; i++)
            {
                char c = username[i];
                if (!(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z') && !(c >= '0' && c <= '9')/**/)
                {
                    haschar = true;
                }
            }
            //check password to not contain characters from string banned bellow
            string banned = "~`><,.?/;:{}[]-+=()";
            for (int i = 0; i < banned.Length; i++)
            {
                if (password.Contains(banned[i])/**/)
                {
                    passforb = true;
                }
            }

            //check username to be 3-12 char
            if (username.Length > 12 || username.Length < 3)
                MessageBox.Show("Username must be 3-12 characters!");
            //check password to be 8-16 char
            else if (password.Length > 12 || password.Length < 3)
                MessageBox.Show("Password must be 8-16 characters!");
            else if (haschar)
                MessageBox.Show("Username cannot contain special characters!");
            else if (passforb)
                MessageBox.Show(" ~`><,.?/;:{}[]-+=() Are not allowed!");
            else
            //try to register user
            {
                if (user1.SearchUsername(username))
                    MessageBox.Show("username already excists");
                else
                {
                    if (user1.AddUser(username, password, score))
                    {
                        DialogResult result = MessageBox.Show("hello");
                        Form game = new Form4(username, score);
                        game.Show();
                        this.Close();

                    }
                    else
                        MessageBox.Show("Try Again");
                }                   
            }
        }
    }
}
