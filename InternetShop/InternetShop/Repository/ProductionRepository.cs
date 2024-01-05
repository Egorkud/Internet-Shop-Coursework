using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Repository.Interfaces;

namespace InternetShop.Repository
{
    internal class ProductionRepository : IProductionRepository
    {
        // Поле відповідає за доступ безпосередньо до бази даних
        private DbContext _dbContext;

        // Конструктор класу
        public ProductionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ItemEntity> ReadAll()
        {
            return _dbContext.ItemsData;
        }
    }
}
