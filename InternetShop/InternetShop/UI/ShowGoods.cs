using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Service;
using InternetShop.UI.Base;

namespace InternetShop.UI
{
    internal class ShowGoods : IUserInterface
    {
        private readonly ProductionService productionService;

        public ShowGoods(ProductionService ProductServ)
        {
            productionService = ProductServ;
        }

        public void Execute()
        {
            List<ItemData> itemData = productionService.ReadAll();

            Console.WriteLine("Check out our items and prices:");
            foreach (ItemData item in itemData)
            {
                Console.WriteLine($"{item.Id + 1}. {item.Name} - {item.Price}");
            }

            Console.WriteLine("");
        }

        public string PrintAction()
        {
            return "Show all goods available now";
        }
    }
}
