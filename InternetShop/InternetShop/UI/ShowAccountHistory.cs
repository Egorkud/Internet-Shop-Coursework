using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Service;
using InternetShop.UI.Base;

namespace InternetShop.UI
{
    internal class ShowAccountHistory : IUserInterface
    {
        private readonly AccountService accountService;
        private readonly HistoryService historyService;

        public ShowAccountHistory(AccountService AccService, HistoryService HistService)
        {
            accountService = AccService;
            historyService = HistService;
        }

        public void Execute()
        {
            // Отримуємо індекс користувача, який залогінився
            int CurrentUserId = accountService.GetCurrentUserId();

            // Перевіряємо чи він залогінений (-1 не залогінений)
            if (CurrentUserId == -1)
            {
                return;
            }

            List<UserAccount> usersList = accountService.ReadAll();
            UserAccount CurrentUser = usersList[CurrentUserId];


            Console.WriteLine($"Here is the full history of {CurrentUser.UserLogin}");

            List<PurchaseHistory> purchaseList = historyService.ReadAll();


            int purchaseIndex = 1;
            foreach (PurchaseHistory purchase in purchaseList)
            {
                if (purchase.UserLogin == CurrentUser.UserLogin)
                {
                    Console.WriteLine($"{purchaseIndex}) Item: {purchase.ItemName}, Balance: {purchase.CurrentBalance}");
                    purchaseIndex++;
                }
            }
        }

        public string PrintAction()
        {
            return "Check account purchase history";
        }
    }
}
