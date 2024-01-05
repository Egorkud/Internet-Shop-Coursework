using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Service;
using InternetShop.UI;

namespace InternetShop
{
    internal class UserAccount
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }

        public int UserId { get; set; }

        public UserAccount(string userLogin, string password, int Id)
        {
            UserLogin = userLogin;
            Password = password;
            UserId = Id;
            Balance = 0;
        }
    }
}
