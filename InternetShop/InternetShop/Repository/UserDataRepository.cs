using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Repository.Interfaces;

namespace InternetShop.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        // Поле відповідає за доступ безпосередньо до бази даних
        private DbContext _dbContext;

        // Конструктор класу
        public UserDataRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Метод додавання користувача в базу даних
        public void AddUser(UserEntity user)
        {
            _dbContext.UserData.Add(user);
        }

        // Отримання даних про користувачів із бази даних
        public List<UserEntity> ReadAll()
        {
            return _dbContext.UserData;
        }

        // Оновлення даних про користувача
        public void Update(UserEntity entity)
        {
            _dbContext.UserData.RemoveAt(entity.UserId);
            _dbContext.UserData.Insert(entity.UserId, entity);
        }
    }
}
