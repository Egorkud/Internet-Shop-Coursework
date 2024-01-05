using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShop.Entity;

namespace InternetShop.Repository.Interfaces
{
    internal interface IProductionRepository
    {
        List<ItemEntity> ReadAll();
    }
}
