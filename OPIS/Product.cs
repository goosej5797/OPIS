using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    /*
    * Class: Product
    * @purpose: The Product class is used to create objects that represent 
    *           the items stored in the Inventory.
    */
    public class Product
    {
        public String name { get; set; }
        public String itemNumber { get; set; }
        public double price { get; set; }
        public int stockQuantity { get; set; } //The # of Product in the Inventory
        public int orderQuantity { get; set; } //The # of Product in the Order

        /*
         * @method: Product()
         * @purpose: Product constructor
         */
        public Product(string name, string itemNumber, double price, int quantity)
        {
            this.name = name;
            this.itemNumber = itemNumber;
            this.price = price;
            this.stockQuantity = quantity;
            this.orderQuantity = 1;
        }

        /*
          * @method: equals()
          * @param: o -> the Product (p1) to be compared to the current instance
          * @purpose: determine whether two Products are equal based on itemNumber
          */
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
