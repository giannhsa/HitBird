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

namespace HitHit
{
    public partial class Form4 : Form
    {
        string user, score;
        Users[] clients;
        string[] entries;
        PictureBox pictureBox1 = new PictureBox();
        Label labelscore = new Label();
        public Label labelGO = new Label();
        Timer timer1start = new Timer() { Interval = 1500 };
        Timer timerlabelGOdis = new Timer() { Interval = 1500 };
        int gamescore = 0;
        Timer flybird = new Timer();
        Random r = new Random();
        DateTime startTime, endTime;
        int runtime;
        int GO;


        public Form4(string username, string highscore)
        {
            InitializeComponent();
            user = username;
            score = highscore;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text + " " + user;
            label2.Text = label2.Text + " " + score;
            timer1start.Tick += new System.EventHandler(Timer1start_Tick);
            timerlabelGOdis.Tick += new System.EventHandler(TimerlabelGOdis_Tick);
            flybird.Tick += new System.EventHandler(flybird_tick);

            //labelscore properties
            labelscore.Location = new Point(this.Width / 2 - labelscore.Width, 5);
            labelscore.Font = new System.Drawing.Font("Arial", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelscore.BackColor = Color.Transparent;
            labelscore.ForeColor = Color.Black;
            labelscore.Size = new Size(200, 60);
            labelscore.Text = "0";
            //picturebox1 properties
            pictureBox1.ImageLocation = "bird.gif";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point((this.Width / 2) - 100, (this.Height / 2) - 100);
            pictureBox1.Click += new System.EventHandler(pictureBox1_click);
            //add picturebox1 and label score to form
            this.Controls.Add(pictureBox1);
            this.Controls.Add(labelscore);
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            labelscore.Enabled = false;
            labelscore.Visible = false;




        }

        private void button2_Click(object sender, EventArgs e)
        {            
            string path = "users.txt";
            //transfer file data to list
            List<string> lines = File.ReadAllLines(path).ToList();
            //split username from pass from score and store them to array so i can search
            foreach (var line in lines)
            {
                entries = line.Split(',');
            }

            clients = new Users[entries.Length / 3];
            //int l = (entries.Length / 3) * 2;
            
            for(int i=0; i < clients.Length; i = i+1 )
            {
                clients[i] = new Users(entries[3*i], Convert.ToInt32(entries[3 * i+2]));
                
            }

            //sort clients dy hightest score bublesort algorithm
            for(int i = 0; i < clients.Length; i++)
            {
                for (int j = 0; j < clients.Length - 1; j++)
                {
                    if(clients[j].userscore < clients[j+1].userscore)
                    {
                        Users temp = clients[j];
                        clients[j] = clients[j + 1];
                        clients[j + 1] = temp;
                    }
                }
            }
           //print high scores
           foreach (var j in clients)
            {
                richTextBox1.Text = richTextBox1.Text + j.username + ":" + (j.userscore).ToString() + Environment.NewLine;
            }



            richTextBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.WindowState = FormWindowState.Maximized;
            timer1start.Enabled = true;
            GO = 3;
            gamescore = 0;
            labelGO.Text = GO.ToString();
            this.Controls.Add(labelGO);
        }

        private void pictureBox1_click(object sender, EventArgs e)
        {
            gamescore = gamescore + 1;  
            labelscore.Text = gamescore.ToString();
        }

        private void Timer1start_Tick(object sender, EventArgs e)
        {
            labelGO.Location = new Point((this.Width / 2-150),(this.Height / 2-200));
            labelGO.Font = new System.Drawing.Font("Arial", 156F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelGO.BackColor = Color.Transparent;
            labelGO.ForeColor = Color.Red;
            labelGO.Size = new Size(600, 300);
            if(GO>0)
            {
                labelGO.Text = GO.ToString();
                GO--;

            }
            else
            {
                labelGO.Text = "GO!";
                timer1start.Enabled = false;
                timerlabelGOdis.Enabled = true;

            }
        }

        private void TimerlabelGOdis_Tick(object sender, EventArgs e)
        {
            this.Controls.Remove(labelGO);
            timerlabelGOdis.Enabled = false;
            Gameplay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Gameplay()
        {
            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;
            labelscore.Enabled = true;
            labelscore.Visible = true;
            startTime = DateTime.Now;
            flybird.Interval = 1200;
            flybird.Enabled = true;



        }

        private void flybird_tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(r.Next(0, this.Width - pictureBox1.Width), r.Next(0, this.Height - pictureBox1.Height));
            endTime = DateTime.Now;
            TimeSpan ellapsedTime = endTime.Subtract(startTime);
            runtime = ellapsedTime.Seconds;
            if(ellapsedTime.Minutes > 0)
            {
                runtime = runtime + ellapsedTime.Minutes * 60;
            }
            if(runtime>2 && runtime<=5)
            {
                //second stage of difficulty
                flybird.Interval = 700;            }
            else if(runtime>5 && runtime<=8)
            {
                //3rd stage of difficulty
                flybird.Interval = 400;
            }
            else if(runtime>8)
            {
                flybird.Enabled = false;
                GameOver();
            }

        }

        private void GameOver()
        {
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            labelscore.Enabled = false;
            labelscore.Visible = false;
            //label to show the score user achieved
            Label showScore = new Label();
            showScore.Location = new Point(this.Width / 2 - showScore.Width/2-100, this.Height/2-showScore.Height/2-100);
            showScore.Font = new System.Drawing.Font("Arial", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            showScore.BackColor = Color.Transparent;
            showScore.ForeColor = Color.Black;
            showScore.Size = new Size(500,50);
            showScore.Text = "Your score: " + gamescore.ToString();
            //button to play again
            Button cont1 = new Button();
            cont1.Text = "Continue";
            cont1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cont1.Size = new Size(300, 100);
            cont1.Location = new Point(this.Width / 2-150, this.Height / 2 - showScore.Height / 2 - 20);
            cont1.BackColor = System.Drawing.Color.LightSalmon;
            cont1.ForeColor = System.Drawing.Color.DarkRed;
            //Add the above buttons to the form
            this.Controls.Add(showScore);
            this.Controls.Add(cont1);
            cont1.Click += new System.EventHandler(cont1_click);
        }

        private void cont1_click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(richTextBox1);
            this.Controls.Add(label2);
            this.Controls.Add(button3);
            this.Controls.Add(button2);
            this.Controls.Add(button1);
            this.Controls.Add(label1);
        }


    }
}
