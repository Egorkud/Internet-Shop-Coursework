using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.UI.Base;
using InternetShop.Service;

namespace InternetShop.UI
{
    internal class UserRegistration : IUserInterface
    {
        private readonly AccountService accountService;
        public UserRegistration(AccountService AccService)
        {
            accountService = AccService;
        }


        public void Execute()
        {
            // Запит на отримання даних
            List<UserAccount> usersList = accountService.ReadAll();
            string username = "";

            // Перевірка чи є користувач у системі
            do
            {
                Console.WriteLine("Input your login (username):");
                username = Console.ReadLine();

                // На випадок пустого масиву користувачів (тобто перший раз зареєструватися)
                if (usersList.Count == 0)
                {
                    break;
                }

                if (usersList.Any(registeredUser => registeredUser.UserLogin == username))
                {
                    Console.WriteLine("This login already exists, try another one");
                }
                else
                {
                    break;
                }

            } while (true);



            Console.WriteLine("Input password:");
            string password = Console.ReadLine();

            // Виклик методу для створення нового акаунту
            var Id = accountService.ReadAll().Count();

            var newUser = new UserAccount(username, password, Id);
            accountService.AddUserData(newUser);

            // Дістаємо попередньо записані дані
            List<UserAccount> newUsersList = accountService.ReadAll();

            // Друк новоствореного акаунту (виводимо лише один останній акаунт)
            UserAccount user = newUsersList.Last();
            Console.WriteLine($"\nYou have just created new account, please remember your password\n" +
                                  $"User: {user.UserLogin}\n" +
                                  $"Password: {user.Password}\n");
        }

        // Метод для повернення інформації про дію даного класу в початкове меню
        public string PrintAction()
        {
            return "Registration";
        }
    }
}
