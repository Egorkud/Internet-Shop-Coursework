using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;

namespace InternetShop
{
    public class DbContext
    {
        public List<UserEntity> UserData { get; set; } = new ();
        public List<ItemEntity> ItemsData { get; set; } = new ();
        public List<HistoryEntity> HistoryData { get; set; } = new ();


        public DbContext()
        {
            UserData = new List<UserEntity>();
            HistoryData = new List<HistoryEntity>();
            ItemsData = new List<ItemEntity>
            {
                new ItemEntity (0, "Broad Axe", 80),
                new ItemEntity (1, "Hatchet", 60),
                new ItemEntity (2, "Canadian Axe", 50),
                new ItemEntity (3, "Double Bit Axe", 120),
                new ItemEntity (4, "Tomahawk", 50),
                new ItemEntity (5, "Viking Axe", 60)
            };
        }
    }
}
