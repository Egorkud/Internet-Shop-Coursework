using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Service;
using InternetShop.UI.Base;

namespace InternetShop.UI
{
    internal class ShowCurrentUserBalance : IUserInterface
    {
        private readonly AccountService accountService;

        public ShowCurrentUserBalance(AccountService AccService)
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

            // Виводимо його баланс
            Console.WriteLine($"\n{CurrentUser.UserLogin} your balance is: {CurrentUser.Balance}\n");
        }

        public string PrintAction()
        {
            return "Show current user balance";
        }
    }
}
