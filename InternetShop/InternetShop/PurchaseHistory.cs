using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop
{
    internal class PurchaseHistory
    {
        public string UserLogin { get; set; }
        public string ItemName { get; set; }
        public int CurrentBalance { get; set; }

        public PurchaseHistory(string userLogin, string itemName, int currentBalance)
        {
            UserLogin = userLogin;
            ItemName = itemName;
            CurrentBalance = currentBalance;
        }

        public PurchaseHistory() { }
    }
}
