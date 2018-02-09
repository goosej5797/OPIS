using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    class Product
    {
        public string name { get; }
        private string itemNumber { get; }
        private double price { get; }

        public Product(string name, string itemNumber, double price)
        {
            this.name = name;
            this.itemNumber = itemNumber;
            this.price = price;
        }


    }
}
