using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Entity
{
    public class UserEntity
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }
    }
}
