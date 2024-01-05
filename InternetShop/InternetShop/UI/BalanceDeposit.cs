using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Service;
using InternetShop.UI.Base;

namespace InternetShop.UI
{
    internal class BalanceDeposit : IUserInterface
    {
        private readonly AccountService accountService;

        public BalanceDeposit(AccountService AccService)
        {
            accountService = AccService;
        }

        public void Execute()
        {
            // Отримуємо масив зареєстрованих користувачів
            List<UserAccount> usersList = accountService.ReadAll();

            // Отримуємо індекс користувача, який залогінився
            int CurrentUserId = accountService.GetCurrentUserId();

            // Перевіряємо чи він залогінений (-1 не залогінений)
            if (CurrentUserId == -1)
            {
                return;
            }

            // Створюємо змінну нашого (залогіненого користувача)
            UserAccount CurrentUser = usersList[CurrentUserId];

            // Введення бажаної суми поповнення балансу
            Console.WriteLine("Type the mount of money you want to deposit on your balance:\n");
            int NewMoney = int.Parse(Console.ReadLine());




            // Додавання суми до балансу користувача
            CurrentUser.Balance += NewMoney;
            accountService.Update(CurrentUser);


            // Гарний друк про успішне додавання грошей до балансу
            Console.WriteLine("Processing...\n");
            Thread.Sleep(1500);
            Console.WriteLine($"Success! Your balance is {CurrentUser.Balance} now\n");
        }

        public string PrintAction()
        {
            return "Top up your account balance";
        }

    }
}
