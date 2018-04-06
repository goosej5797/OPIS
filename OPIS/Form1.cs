/*
 * PHASE IV: IMPLEMENTATION
 * Point of Sales Order Processing and Invoicing System
 * 
 * @authors: Chris Phillips (PM), Joshua Goosen, Becky House, & Katie Wenban
 * @date: 21 March 2018
 * @course: CPS410
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPIS
{
    /*
    * Form: Form1
    * @purpose: The initially executing window that contains the primary
    *           user interface. It is used to add/delete Products to the customer's
    *           order, view the customer's cart and totals, and proceed to checkout.
    */
    public partial class Form1 : Form
    {
        public Catalog c;
        public Order o;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            o = new Order(); //instantiate a new Order
            c = new Catalog(); //instantiate an updated Catalog
            generateButtons(); //instantiate the GUI

            listView1.View = View.Details;
        }

        public void ResetForm()
        {
            o = new Order(); //instantiate a new Order
            c = new Catalog(); //instantiate an updated Catalog

            //Clear Panel, Labels, & Listview
            flowLayoutPanel1.Controls.Clear();
            UpdateTotal(); //Clear labels
            ErrorMsg.Visible = false;
            UpdateListView();
            listView1.View = View.Details;

            generateButtons(); //instantiate the GUI

        }

        /*
         * Button1 = Checkout Button
         * @purpose: open the Payment User Interface
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Payment1 payment = new Payment1(o, c, this);

            // Show the payment form
            payment.Show();

            // Hide the current form
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        /*
         * @method: generateButtons()
         * @purpose: given the generated catalog, creates
         *           a unique button for each Product in the Catalog
         */
        public void generateButtons()
        {
            List<Product> products = c.getAllProducts();
            foreach (Product p in products)
            {
                Button b = new Button();
                b.Text = p.name;
                b.Name = p.name;
                b.Size = new System.Drawing.Size(94, 76);
                b.BackColor = Color.FromArgb(146, 76, 156);
                b.ForeColor = Color.White;
                b.Font = new Font("Times New Roman", 14);
                b.Click += Btn_action; //Adds event handler
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        /*
         * @method: btn_action()
         * @purpose: Whenever a "Product Button" is pressed,
         *           the corresponding Product will be added to the
         *           customer's order. Then, the ListView and Totals
         *           will be updated.
         */
        public void Btn_action(object sender, EventArgs e)
        {
            // Hide error message label
            ErrorMsg.Visible = false;

            Button btn = (Button)sender;
            Product p = c.getProduct(btn.Name);

            if (o.addItem(p) == false)
            {
                ErrorMsg.Text = p.name + " is out of stock!";
                ErrorMsg.Visible = true;
            }

            UpdateListView();
            UpdateTotal();
        }

        /*
         * @method: updateListView()
         * @purpose: refreshes the ListView to show an updated version
         *           of the customer's order that accurrately displays
         *           what the customer intends to purchase.
         */
        public void UpdateListView()
        {
            listView1.Items.Clear(); //Clear the ListView of past items

            List<Product> products = o.getEntireOrder();

            foreach (Product p in products)
            {
                ListViewItem i = new ListViewItem(p.name);
                i.SubItems.Add(p.price.ToString("F"));
                i.SubItems.Add(Convert.ToString(p.orderQuantity));
                listView1.Items.Add(i);
            }
        }

        /*
         * @method: updateTotal()
         * @purpose: updates the Order's totals and displays them on the User Interface
         */
        public void UpdateTotal()
        {
            o.setTotals();

            label2.Text = "$" + o.subtotal.ToString("F");
            label5.Text = "$" + o.tax.ToString("F");
            label4.Text = "$" + o.total.ToString("F");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /*
         * @button2: "Delete Item"
         * @purpose: remove an entire Product (a selected row) from the Order
         */
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                String pName = listView1.SelectedItems[0].SubItems[0].Text;

                Product p = c.getProduct(pName);
                o.removeItem(p);

                UpdateTotal();
                UpdateListView();
            }
            catch
            {

            }
        }

        /*
         * @button3: "Decrease"
         * @purpose: decrease the order quantity of a Product (a selected row) from the Order by ONE
         */
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String pName = listView1.SelectedItems[0].SubItems[0].Text;
                Product p = c.getProduct(pName);

                o.decreaseQuantity(p);

                UpdateTotal();
                UpdateListView(); 
            }
            catch
            {

            }
        }
    }
}
