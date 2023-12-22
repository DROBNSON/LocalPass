using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPass
{
    public class Password
    {
        private Guid passwordId;
        private User user;
        public DateTime passwordDate;
        public string _password {  get; set; }

        public Guid PasswordId 
        {
            get {return passwordId; } 
            set {passwordId = value;} 
        }

        public DateTime PasswordDate 
        {
            get {return passwordDate; } 
            set {passwordDate = value; } 
        }

        public User User 
        {   
            get{return user; }  
            set{user = value; }  
        }

        public Password()
        {
        }

        public Password(Guid passwordid, string password, DateTime passworddate, User usr) 
        {
            passwordId = passwordid;
            _password = password;
            passwordDate = passworddate;
            user = usr;
        }

        public void ClearPassword()
        {
            this._password = null;   
        }
    }
}
