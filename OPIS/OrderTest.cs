using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace OPIS
{
    [TestFixture]
    class OrderTest
    {
        [Test]
        public void TestOrder_AddItem_AssertTrue()
        {
            Product p = new Product("Test", "0000", 1, 2);
            bool result = p.orderQuantity + 1 <= p.stockQuantity;
            Assert.IsTrue(result);
        }

        [Test]
        public void TestOrder_AddItem_AssertFalse()
        {
            Product p = new Product("Test", "0001", 1, 0);
            bool result = p.orderQuantity + 1 <= p.stockQuantity;
            Assert.IsFalse(result);
        }

        [Test]
        public void TestOrder_RemoveItem_AssertTrue()
        {
            Product p = new Product("Test", "0002", 1, 2);
            Order o = new Order();

            o.addItem(p);
            List<Product> products = o.getEntireOrder();
            bool firstBool = products.Contains(p);

            o.removeItem(p);
            products = o.getEntireOrder();
            bool secondBool = !products.Contains(p);

            bool result = firstBool && secondBool;
            Assert.IsTrue(result);
        }

        [Test]
        public void TestOrder_RemoveItem_AssertFalse()
        {
            Product p = new Product("Test", "0002", 1, 2);
            Order o = new Order();

            o.addItem(p);
            List<Product> products = o.getEntireOrder();
            bool firstBool = products.Contains(p);

            o.removeItem(p);
            products = o.getEntireOrder();
            bool secondBool = products.Contains(p);

            bool result = firstBool && secondBool;
            Assert.IsFalse(result);
        }

        [Test]
        public void TestOrder_DecreaseQuantity_AssertTrue()
        {
            Product p = new Product("Test", "0003", 1, 2);
            Order o = new Order();

            o.addItem(p);
            o.addItem(p);
            int initQuantity = p.orderQuantity;

            o.decreaseQuantity(p);
            int nextQuantity = p.orderQuantity;

            bool result = (nextQuantity == initQuantity - 1);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestOrder_DecreaseQuantity_AssertFalse()
        {
            Product p = new Product("Test", "0004", 1, 2);
            Order o = new Order();

            o.addItem(p);
            o.addItem(p);
            int initQuantity = p.orderQuantity;

            o.decreaseQuantity(p);
            int nextQuantity = p.orderQuantity;

            bool result = (nextQuantity != initQuantity - 1);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestOrder_SetTotals_Reset()
        {
            Order o = new Order();
            o.setTotals();

            bool sub = false, tax = false, tot = false;

            if (o.subtotal == 0) { sub = true; }
            if (o.tax == 0) { tax = true; }
            if (o.total == 0) { tot = true; }

            bool result = sub && tax && tot;
            Assert.IsTrue(result);
        }

        [Test]
        public void TestOrder_SetTotals_AssertTrue()
        {
            Product p = new Product("Test", "0005", 1, 2);
            Order o = new Order();

            o.addItem(p);
            o.addItem(p);

            o.setTotals();

            double mySub = 0, myTax = 0, myTotal = 0;

            foreach (Product pr in o.getEntireOrder())
            {
                mySub += p.price * p.orderQuantity;
            }

            myTax = mySub * 0.06;
            myTotal = mySub + myTax;

            bool sub = (o.subtotal == mySub);
            bool tax = (o.tax == myTax);
            bool tot = (o.total == myTotal);

            bool result = sub && tax && tot;
            Assert.IsTrue(result);
        }

        [Test]
        public void TestOrder_GetEntireOrder_AssertTrue()
        {
            Product p = new Product("Test", "0006", 1, 2);
            Product q = new Product("Test", "0007", 1, 2);
            Order o = new Order();

            List<Product> myProducts = new List<Product>();
            myProducts.Add(p);
            myProducts.Add(q);

            o.addItem(p);
            o.addItem(q);

            List<Product> products = o.getEntireOrder();

            bool result = true;

            for(int i = 0; i < products.Count(); i++)
            {
                if (products[i].itemNumber !=
                    myProducts[i].itemNumber)
                    result = false;
            }

            Assert.IsTrue(result);
        }
    }
}
