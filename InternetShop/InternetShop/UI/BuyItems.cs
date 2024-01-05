using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Repository.Interfaces;
using InternetShop.Service;
using InternetShop.UI.Base;
using InternetShop.UI;
using InternetShop;

namespace InternetShop.UI
{
    internal class BuyItems : IUserInterface
    {
        private readonly AccountService accountService;
        private readonly ProductionService productionService;
        private readonly HistoryService historyService;

        public BuyItems(AccountService AccService, ProductionService ProductServ, HistoryService HistService)
        {
            accountService = AccService;
            productionService = ProductServ;
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

            string answer;
            do
            {
                MakePurchase(accountService, productionService, CurrentUserId);

                Console.WriteLine("Do you want to make another purchase? (Y/N)");
                answer = Console.ReadLine();

            } while (answer.ToUpper() == "Y");
        }


        private void MakePurchase(AccountService accountService, ProductionService productionService, int CurrentUserId)
        {
            List<ItemData> itemData = productionService.ReadAll();
            List<UserAccount> usersList = accountService.ReadAll();


            Console.WriteLine("To buy something chose the items number (shows by option 5)\n" +
                "To check the product info press '0'\n");
            int answer;
            answer = int.Parse(Console.ReadLine());


            if (answer == 0)
            {
                new ShowGoods(productionService).Execute();
                return;
            }


            UserAccount CurrentUser = usersList[CurrentUserId];
            int userBalance = CurrentUser.Balance;
            int itemPrice = itemData[answer - 1].Price;


            string errorMessage = $"Sorry, but You cannot afford it\n" +
                $"Your balance is {userBalance} but the price {itemPrice} is higher for {itemPrice - userBalance}\n";
            string successMessage = $"Congratulations, your {itemData[answer - 1].Name} will be sent soon\n";


            if (userBalance < itemPrice)
            {
                Console.WriteLine(errorMessage);
                return;
            }

            CurrentUser.Balance -= itemPrice;
            accountService.Update(CurrentUser);

            string itemName = itemData[answer - 1].Name;

            var newRecord = new PurchaseHistory(CurrentUser.UserLogin, itemName, CurrentUser.Balance);

            historyService.AddPurchaseData(newRecord);

            Console.WriteLine(successMessage, $"Your current balance is {CurrentUser.Balance}\n");

            return;
        }

        public string PrintAction()
        {
            return "Make a purchase";
        }
    }
}
