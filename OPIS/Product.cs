using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    public class Product
    {
        public String name { get; set; }
        public String itemNumber { get; set; }
        public double price { get; set; }
        public int stockQuantity { get; set; }
        public int orderQuantity { get; set; }

        public Product(string name, string itemNumber, double price, int quantity)
        {
            this.name = name;
            this.itemNumber = itemNumber;
            this.price = price;
            this.stockQuantity = quantity;
            this.orderQuantity = 1;
        }

       
        public bool equals(Object o)
        {
            Product p1 = (Product)o;
            
            if(this.itemNumber == p1.itemNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
