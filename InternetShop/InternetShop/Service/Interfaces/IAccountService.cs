using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Service.Interfaces
{
    internal interface IAccountService
    {
        void AddUserData(UserAccount user);
        List<UserAccount> ReadAll();
        bool LoginCheck { get; set; }
        int CurrentUserId { get; set; }
        int GetCurrentUserId();
        void Update(UserAccount entity);

    }
}
