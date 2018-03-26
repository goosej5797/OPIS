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
        public static string orderNumber { get; set; }
        public double subtotal { get; set; }
        public double total { get; set; }
        public double tax { get; set; }
        private const double TAXAMT = 0.06;
        private List<Product> orderProducts; //List of Products to be purchased

        static Order()
        {
            orderNumber = "999";
        }

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
            int num = Convert.ToInt32(orderNumber);
            num++;
            orderNumber = Convert.ToString(num);
        }

        /*
         * @method: addItem()
         * @param: item -> Product to be added to the Order
         * @purpose: Add a Product to the Order
         */
        public bool addItem(Product item)
        {
            if(item.orderQuantity + 1 <= item.stockQuantity)
            {
                //if the Order doesn't contain the Product already, add the item
                if (!orderProducts.Contains(item))
                {
                    item.orderQuantity++;
                    orderProducts.Add(item);
                }
                //if the Order does contain the Product already, increase the orderQty
                else
                {
                    item.orderQuantity++;
                }

                return true;
            }
            else
            {
                return false;
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
                    item.orderQuantity = 0; //reset orderQuantity to 0
                }
            }
        }

        /*
        * @method: decreaseQuantity()
        * @param: item -> Product whose quantity is to be decreased by ONE
        * @purpose: Decreases the selected Product's order quantity by ONE
        */
        public void decreaseQuantity(Product item)
        {
            item.orderQuantity--;

            //if orderQuantity becomes ZERO, remove item from Order
            if (item.orderQuantity == 0)
            {
                removeItem(item);
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
            tax = 0;
            total = 0;

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

        /*
        * @method: payWithCash()
        * @param input -> the contents of the textbox
        * @purpose: Checks the validity of the customer's tender given (i.e. if 
        *           the customer provided enough cash to cover the cost of the 
        *           purchase). Then, the purchased is approved and the correct 
        *           change is returned. Otherwise, an exception is thrown.
        */
        public double payWithCash(String input)
        {
            double change = -1;

            try
            {
                //convert input to double
                double tender = Convert.ToDouble(input);

                //ensures that tender given is greater than or equal to order total
                if (tender >= total)
                {
                    change = tender - total;
                }
            }
            catch (ArrayTypeMismatchException e)
            {
                throw;
            }

            return change;
        }

        /*
        * @method: payWithCard()
        * @param input -> the contents of the textbox
        * @purpose: Checks the basic validity of the customer's credit card 
        *           (i.e. if the card number consits of ONLY digits and is 16
        *           characters long). Then, the credit card is approved and 
        *           $0.00 is returned for change. Otherwise, an exception is thrown.
        */
        public double payWithCard(String input)
        {
            double change = -9999;
            try
            {
                //convert input to long...if exception thrown, invalid card entered!
                long tender = Convert.ToInt64(input);

                //ensures card number is of length 16
                if (input.Length == 16)
                {
                    change = 0.0;
                }
            }
            catch(ArrayTypeMismatchException e)
            {
                throw;
            }

            return change;
        }
    }
}
