using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;

namespace InternetShop.Repository.Interfaces
{
    internal interface IUserDataRepository
    {
        void AddUser(UserEntity user);
        List<UserEntity> ReadAll();
        void Update(UserEntity entity);
    }
}
