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
        private int quantity { get; }

        public Product(string name, string itemNumber, double price, int quantity)
        {
            this.name = name;
            this.itemNumber = itemNumber;
            this.price = price;
            this.quantity = quantity;
        }


    }
}
