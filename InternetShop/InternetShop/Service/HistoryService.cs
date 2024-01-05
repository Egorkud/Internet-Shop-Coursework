using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Repository;
using InternetShop.Repository.Interfaces;
using InternetShop.Service.Interfaces;

namespace InternetShop.Service
{
    internal class HistoryService : IHistoryService
    {
        // Поле, відповідає за доступ до бази даних
        HistoryRepository historyRepository;

        // Конструктор класу
        public HistoryService(DbContext context)
        {
            historyRepository = new HistoryRepository(context);
        }

        // Додавання запису про покупку в базу даних
        public void AddPurchaseData(PurchaseHistory record)
        {
            historyRepository.AddHistoryRecord(Map(record));
        }

        // Його мапер
        private HistoryEntity Map(PurchaseHistory record)
        {
            if (record == null)
            {
                return null;
            }
            return new HistoryEntity
            {
                UserLogin = record.UserLogin,
                ItemName = record.ItemName,
                CurrentBalance = record.CurrentBalance
            };
        }

        // Отримання даних про історію покупок (всіх користувачів, для виводу окремого створено умовний оператор)
        public List<PurchaseHistory> ReadAll()
        {
            // Отримання списку користувачів з репозиторію та їх мапіння до типу UserAccount
            var list = historyRepository.ReadAll().Select(x => x != null ? Map(x) : null).ToList();
            return list;
        }

        private PurchaseHistory Map(HistoryEntity entity)
        {
            return new PurchaseHistory()
            {
                UserLogin = entity.UserLogin,
                ItemName = entity.ItemName,
                CurrentBalance = entity.CurrentBalance
            };
        }
    }
}
