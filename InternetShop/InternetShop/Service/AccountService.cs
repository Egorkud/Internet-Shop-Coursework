using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Repository;
using InternetShop.Service.Interfaces;
using InternetShop.UI;

namespace InternetShop.Service
{
    internal class AccountService : IAccountService
    {
        // Поле, відповідає за доступ до бази даних
        UserDataRepository accountRepository;

        // Конструктор класу
        public AccountService(DbContext context)
        {
            accountRepository = new UserDataRepository(context);
        }

        // Метод додавання нового акаунту
        public void AddUserData(UserAccount user)
        {
            accountRepository.AddUser(Map(user));
        }

        // Його маппер
        private UserEntity Map(UserAccount user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserEntity
            {
                UserLogin = user.UserLogin,
                Password = user.Password,
                UserId = user.UserId,
                Balance = user.Balance
            };
        }

        // Список об'єктів UserAccount, які представляють всіх користувачів
        public List<UserAccount> ReadAll()
        {
            // Отримання списку користувачів з репозиторію та їх мапіння до типу UserAccount
            var list = accountRepository.ReadAll().Select(x => x != null ? Map(x) : null).ToList();
            return list;
        }

        // Його маппер (об'єкт представлення користувача)
        private UserAccount Map(UserEntity user)
        {
            return new UserAccount(user.UserLogin, user.Password, user.UserId)
            {
                UserLogin = user.UserLogin,
                Password = user.Password,
                UserId = user.UserId,
                Balance = user.Balance
            };
        }

        // Змінні для отримання даних про користувача (перевірка на залогіненість)
        public bool LoginCheck { get; set; }
        public int CurrentUserId { get; set; }

        //Отримання ідентифікатора користувача
        public int GetCurrentUserId()
        {
            if (LoginCheck)
            {
                return CurrentUserId;
            }
            else
            {
                Console.WriteLine("No user is currently logged in");
                return -1;
            }
        }

        public void Update(UserAccount entity)
        {
            accountRepository.Update(Map(entity));
            
        }
    }
}