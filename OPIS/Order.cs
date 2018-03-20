using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    /*
    * Class: Order
    * @purpose: The Order class is used to create and interact with objects 
    *           that represent a particular order. Orders contain a list of 
    *           Products to be purchased, as well as totals.
    */
    public class Order
    {
        public string orderNumber { get; set; }
        public double subtotal { get; set; }
        public double total { get; set; }
        public double tax { get; set; }
        private const double TAXAMT = 0.06;
        private List<Product> orderProducts; //List of Products to be purchased

        /*
         * @method: Order()
         * @purpose: Order constructor. Initializes all values--(re)sets totals to 0.00
         *           and sets orderNumber to DISTINCT value.
         */
        public Order()
        {
            orderProducts = new List<Product>();
            subtotal = 0.0;
            total = 0.0;
            tax = 0.0;
            orderNumber = "1000";
        }

        /*
         * @method: addItem()
         * @param: item -> Product to be added to the Order
         * @purpose: Add a Product to the Order
         */
        public void addItem(Product item)
        {
            //if the Order doesn't contain the Product already, add the item
            if (!orderProducts.Contains(item))
            {
                orderProducts.Add(item);
            }
            //if the Order does contain the Product already, increase the orderQty
            else
            {
                item.orderQuantity++;
            }

        }

        /*
         * @method: removeItem()
         * @param: item -> Product to be removed from the Order
         * @purpose: Removes the specified Product from the Order
         */
        public void removeItem(Product item)
        {
            for (int x = 0; x < orderProducts.Count; x++)
            {
                if (orderProducts[x].name == item.name)
                {
                    orderProducts.RemoveAt(x);
                    item.orderQuantity = 1; //reset orderQuantity to 1
                }
            }
        }

        /*
         * @method: setTotals()
         * @purpose: Updates the subtotal, tax, and total variables
         *           according to the current state of the order
         */
        public void setTotals()
        {
            subtotal = 0; //reset subtotal to 0.00

            foreach(Product p in orderProducts)
            {
                subtotal += p.price * p.orderQuantity;
                tax = subtotal * TAXAMT;
                total = subtotal + tax;
            }

        }

        /*
         * @method: getEntireOrder()
         * @purpose: Returns the Order's list of items to be purchased 
         */
        public List<Product> getEntireOrder()
        {
            return orderProducts;
        }

        public void deleteOrder()
        {

        }

        public void payWithCash()
        {

        }

        public void payWithCard()
        {

        }

        public void viewReceipt()
        {

        }
    }
}
