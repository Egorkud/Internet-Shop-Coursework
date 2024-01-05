using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Repository;
using InternetShop.Repository.Interfaces;
using InternetShop.Service.Interfaces;

namespace InternetShop.Service
{
    internal class ProductionService : IProductionServise
    {
        // Поле, відповідає за доступ до бази даних
        ProductionRepository productionRepository;

        // Конструктор класу
        public ProductionService(DbContext context)
        {
            productionRepository = new ProductionRepository(context);
        }

        // Отримання списку користувачів
        public List<ItemData> ReadAll()
        {
            // Отримання списку користувачів з репозиторію та їх мапіння до типу UserAccount
            var list = productionRepository.ReadAll().Select(x => x != null ? Map(x) : null).ToList();
            return list;
        }

        // Його мапер
        private ItemData Map(ItemEntity item)
        {
            return new ItemData(item.Id, item.Name, item.Price)
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
        }

    }
}
