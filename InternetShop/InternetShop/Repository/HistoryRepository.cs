using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;
using InternetShop.Repository.Interfaces;

namespace InternetShop.Repository
{
    internal class HistoryRepository : IHistoryRepository
    {
        // Поле відповідає за доступ безпосередньо до бази даних
        private DbContext _dbContext;

        // Конструктор класу
        public HistoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddHistoryRecord(HistoryEntity entity)
        {
            _dbContext.HistoryData.Add(entity);
        }

        public List<HistoryEntity> ReadAll()
        {
            return _dbContext.HistoryData;
        }
    }
}
