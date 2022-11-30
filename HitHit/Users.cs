//Contains functions that are used to register new user 
//check his login info, search a user, sort the users by highscore

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HitHit
{
    public class Users
    {
        public string username;
        public int userscore;
        public string path = "users.txt";
        public  string[] entries;
        public int i;
        private string score;
        private string tempscores;
        private string[] highscores;

        public Users(string name, int score)
        {
            username = name;
            userscore = score;
        }
        

        //function that imports data of the file to an array
        private string[] fileToArray()
        {
            //transfer file data to list
            List<string> lines = File.ReadAllLines(path).ToList();
            //split username from pass from score and store them to array so i can search
            foreach (var line in lines)
            {
                entries = line.Split(',');
            }
            return entries;
        }

        //add userdata in database
        public bool AddUser(string username, string password, string score)
        {
            bool done;            
            string data = username + "," + password + "," + score + ',';
            try
            {
                File.AppendAllText(path, data);
                done = true;
            }
            catch
            {
                done = false;
            }            
            return done;
        }

        //search for a user
        public bool SearchUsername(string username)
        {
            bool found = false;
            entries = fileToArray();
            for (i = 0; i < entries.Length; i = i + 3)
            {
                if (entries[i] == username)
                    found = true;
            }
            return found;
        }

        //validate users login
        public bool ValidateUser(string username, string password)
        {
            bool isuser = false;
            entries = fileToArray();
            //check if user is registered
            for (i = 0; i < entries.Length; i = i + 3)
            {
                if (entries[i] == username && entries[i + 1] == password)
                    isuser = true;                    
            }

            return isuser;
        }

        //get users score
        public string GetScore(string username, string password)
        {
            entries = fileToArray();
            for (i = 0; i < entries.Length; i = i + 3)
            {
                if (entries[i] == username && entries[i + 1] == password)
                     score = entries[i + 2];                
            }
            return score;
        }


        
    }
}
