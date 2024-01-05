using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.UI.Base;

namespace InternetShop.UI
{
    internal class ExitShop : IUserInterface
    {
        public void Execute()
        {
            Console.WriteLine("Thank you for choosing our shop!");
        }

        public string PrintAction()
        {
            return "Close the shop";
        }
    }
}
