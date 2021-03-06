﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPIS
{
    /*
    * Form: Invoice1
    * @purpose: The third window that will appear when the payment has been
    *           processed. This form will show an invoice of the customer's
    *           order, update the database with the transaction info, and
    *           allow a user to begin a new Order.
    */
    public partial class Invoice1 : Form
    {
        Order o;
        Catalog c;
        Form1 start;

        /*
         * @method: Invoice1()
         * @param: o -> Order transferred from Payment1
         * @purpose: instantiate the customer's Order, initializes form
         */
        public Invoice1(Order o, Catalog c, Form1 f)
        {
            InitializeComponent();
            this.o = o;
            this.c = c;
            this.start = f;

            ordrNum.Text = Order.orderNumber;
            listView1.View = View.Details;
        }

        private void Invoice1_Load(object sender, EventArgs e)
        {
            updateTotals();
            updateListView();
        }

        /*
         * @method: updateTotals()
         * @purpose: updates the Order's totals and displays them on the User Interface
         */
        public void updateTotals()
        {
            o.setTotals();

            label6.Text = "$" + o.subtotal.ToString("F");
            label7.Text = "$" + o.tax.ToString("F");
            label8.Text = "$" + o.total.ToString("F");
        }

        /*
         * @method: updateListView()
         * @purpose: refreshes the ListView to show an updated version
         *           of the customer's order that accurrately displays
         *           what the customer purchased to purchase.
         */
        public void updateListView()
        {
            listView1.Items.Clear();

            List<Product> products = o.getEntireOrder();

            foreach (Product p in products)
            {
                ListViewItem i = new ListViewItem(p.name);
                i.SubItems.Add(p.price.ToString("F"));
                i.SubItems.Add(Convert.ToString(p.orderQuantity));
                listView1.Items.Add(i);
            }
        }

        //NEW TRANSACTION
        private void button1_Click(object sender, EventArgs e)
        {
            //UPDATE DATABASE WITH NEW QUANTITIES
            StreamWriter sw = new StreamWriter("C:\\Users\\Katie\\Documents\\OPIS\\OPIS\\items.txt");
            foreach(Product p in c.getAllProducts())
            {
                int qty = p.stockQuantity - p.orderQuantity;
                sw.WriteLine(p.name + " " + p.itemNumber + " " + p.price + " " + qty);
            }

            sw.Close();

            start.ResetForm();
            start.Show();

            this.Close();
        }
    }
}
