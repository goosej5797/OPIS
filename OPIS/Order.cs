using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    public class Order
    {
        public string orderNumber { get; set; }
        public double subtotal { get; set; }
        public double total { get; set; }
        public double tax { get; set; }
        private const double TAXAMT = 0.06;
        private List<Product> orderProducts;
        private Catalog inventory;

        public Order()
        {
            orderProducts = new List<Product>();
            subtotal = 0.0;
            total = 0.0;
            tax = 0.0;
            orderNumber = "1000";
        }

        public void addItem(Product item)
        {
            if (!orderProducts.Contains(item))
            {
                orderProducts.Add(item);
            }
            else
            {
                item.orderQuantity++;
            }

        }

        public void removeItem(Product item)
        {
            for (int x = 0; x < orderProducts.Count; x++)
            {
                if (orderProducts[x].name == item.name)
                {
                    orderProducts.RemoveAt(x);
                    item.orderQuantity = 1;
                }
            }
        }

        public void setTotals()
        {
            subtotal = 0;

            foreach(Product p in orderProducts)
            {
                subtotal += p.price * p.orderQuantity;
                tax = subtotal * TAXAMT;
                total = subtotal + tax;
            }

        }

        public double getSubtotal()
        {
            return subtotal;
        }

        public double getTax()
        {
            return tax;
        }

        public double getTotal()
        {
            return total;
        }

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
