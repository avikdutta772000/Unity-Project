using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class User
    {
        public string username;
        public string email;
        public double score;
        public User()
        {
        }

        public User(string username, string email,double score)
        {
            this.username = username;
            this.email = email;
            this.score = score;
        }
    }

