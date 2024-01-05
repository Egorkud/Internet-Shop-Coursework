using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InternetShop.Service;
using InternetShop.Service.Interfaces;

namespace InternetShop
{
    internal class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public ItemData(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
