using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Service;
using InternetShop.UI.Base;

namespace InternetShop.UI
{
    internal class UserLogin : IUserInterface
    {
        private readonly AccountService accountService;

        public UserLogin(AccountService AccService)
        {
            accountService = AccService;
        }


        public void Execute()
        {
            // Отримання даних про користувачів
            List<UserAccount> usersList = accountService.ReadAll();

            string CurrentUserLogin = "", CurrentUserPassword = "";

            int CurrentUserBalance = 0, indicator = 0, index = 0;
            while (indicator == 0)
            {
                Console.WriteLine("Input your login:");
                string UserLogin = Console.ReadLine();

                if (string.IsNullOrEmpty(UserLogin))
                {
                    Console.WriteLine("Input anything");
                    continue;
                }
                foreach (UserAccount user in usersList)
                {
                    if (user.UserLogin == UserLogin)
                    {
                        CurrentUserLogin = user.UserLogin;
                        CurrentUserPassword = user.Password;
                        CurrentUserBalance = user.Balance;
                        indicator++;
                        accountService.LoginCheck = true;
                        accountService.CurrentUserId = index;
                        break;
                    }
                    index++;
                }
                index = 0;
            }

            while (true)
            {
                Console.WriteLine("Input your password:");
                string UserPassword = Console.ReadLine();

                if (string.IsNullOrEmpty(UserPassword) || UserPassword != CurrentUserPassword)
                {
                    Console.WriteLine("Wrong password!");
                    continue;
                }
                break;
            }
            Console.WriteLine("\nYou have successfully logged in!\n" +
                              $"Welcome {CurrentUserLogin}!\n" +
                              $"Now you are able to purchase our goods, do not forget to check your balance before placing your order!\n" +
                              $"Your current balance is: {CurrentUserBalance}\n");
        }

        public string PrintAction()
        {
            return "Login";
        }
    }
}
