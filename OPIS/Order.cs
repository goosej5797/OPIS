using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    class Order
    {
        private string orderNumber { get; }
        private double subtotal { get; }
        private double total { get; }
        private double tax;
        private List<Product> orderProducts;
        private Catalog inventory;

        public Order()
        {

        }

        public void addItem(Product item)
        {
            orderProducts.Add(item);
        }

        public void removeItem(Product item)
        {
            List<int> indexList = new List<int>();
            for (int x = 0; x < orderProducts.Count; x++) 
            {
                if (orderProducts[x].name == item.name)
                {
                    indexList.Add(x);
                }
            }

            foreach(int n in indexList)
            {
                orderProducts.RemoveAt(n);
            }
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
