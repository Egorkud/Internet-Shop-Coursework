using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.UI.Base;
using InternetShop.UI;
using InternetShop.Service;

namespace InternetShop
{
    public abstract class Program
    {
        // Головна функця Main
        public static void Main()
        {
            var context = new DbContext();
            var accountService = new AccountService(context);
            var productionService = new ProductionService(context);
            var historyService = new HistoryService(context);


            // Реалізація вибору опцій через масив із командами
            IUserInterface[] UIs =
            [
                new ExitShop(),
                new UserRegistration(accountService),
                new UserLogin(accountService),
                new ShowCurrentUserBalance(accountService),
                new BalanceDeposit(accountService),
                new ShowGoods(productionService),
                new BuyItems(accountService, productionService, historyService),
                new ShowAccountHistory(accountService, historyService)
            ];

            Console.WriteLine("Welcome in our Axe Shop!\n");


            // Безпосередньо можливість обрати необхідну опцію
            int answer = 1, i;
            while (answer != 0)
            {
                for (i = 0; i < UIs.Length; i++)
                {
                    Console.WriteLine($"{i}) {UIs[i].PrintAction()}");
                }


                answer = int.Parse(Console.ReadLine());
                UIs[answer].Execute();
            }
        }
    }
}