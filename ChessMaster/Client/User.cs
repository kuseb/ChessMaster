using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Client
{
    public class User
    {
        private string nick;
        private string mail;
        private int ranking;
        private int points;
        private string designation;
        private SecureString password;
        private string avatarPath;

        private bool anonymous;
        
        public bool IsAnonymous { get { return anonymous; } } 
        public string Nick { get { return nick; } }
        public string Mail { get { return mail==null?"":mail; } set { mail = value; } }
        public int Ranking
        {
            get { return ranking; }
            set { value = ranking; }
        }
        public int Points { get { return points; } }
        public string Designation { get { return designation; } }
        public SecureString Password { get { return password; } set { password = value; } }
        public string Avatar { get { return avatarPath; } set { avatarPath = value; } }
        public User()
        {
            anonymous = true;
        }     
        
        public User(string nick)
        {
            this.nick = nick;
            anonymous = false;
        }  

        public User(string nick, string mail, SecureString password)
        {
            this.nick = nick;
            this.mail = mail;
            this.password = password;
            anonymous = false;
        }

        
    }
}
