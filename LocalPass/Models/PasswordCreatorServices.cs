using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LocalPass
{
    public class PasswordCreatorServices
    {
        private static PasswordCreatorDBContext _dbContext = new PasswordCreatorDBContext();

        private static User _currentUser;

        public static void SetCurrentUser(User user)
        {
            _currentUser = user; 
        }
      
        public static User CurrentUser()
        {
            return _currentUser;
        }

        public static bool UserExists(string username, string password)
        {
            return _dbContext.Users.Any(u => u.Username == username && u.UserPassword == password);

        }

        public static User GetUser(string username, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username && u.UserPassword == password);
        }

        public static void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public static void DeleteUser(User user)
        {
            if (_dbContext.Passwords.Any(p => p.User == user))
            {
                foreach (var p in _dbContext.Passwords.Where(p => p.User == user))
                {
                    _dbContext.Passwords.Remove(p);
                }
            }
            _dbContext.Remove(user);
            _dbContext.SaveChanges();   
        }
        

        public static void AddPassword(Password password)
        {
            _dbContext.Passwords.Add(password);
            _dbContext.SaveChanges();
        }


        public static Password GetPassword(string password)
        {
            return _dbContext.Passwords.FirstOrDefault(p => p._password == password);


        }

        public static List<Password> GetAllPasswords()
        {
            List<Password> passwordList = _dbContext.Passwords
                .Where(p => p.User == _currentUser)
                .OrderByDescending(p => p.PasswordDate)
                .ToList();
            return passwordList;
        }




        public static List<Password> OldestToNewestPassword()
        {
            List<Password> passwordList = _dbContext.Passwords
              .Where(p => p.User == _currentUser)
              .OrderBy(p => p.PasswordDate)
              .ToList();
            return passwordList;
        }

        public static List<Password> LargestToSmallest()
        {
          List<Password> passwordList = _dbContext.Passwords
              .Where(p => p.User == _currentUser)
              .OrderByDescending(p => p._password.Length)
              .ToList();
            return passwordList;
        }

        public static List<Password> SmallestToLargest()
        {
            List<Password> passwordList = _dbContext.Passwords
                .Where(p => p.User == _currentUser)
                .OrderBy(p => p._password.Length)
                .ToList();
            return passwordList;
        }
        
       public static void DeletePassword(Password password)
       {
            _dbContext.Passwords.Remove(password);
            _dbContext.SaveChanges();
       }









    }
}
