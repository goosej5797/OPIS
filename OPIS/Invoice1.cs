using System;
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
        Form1 start;

        /*
         * @method: Invoice1()
         * @param: o -> Order transferred from Payment1
         * @purpose: instantiate the customer's Order, initializes form
         */
        public Invoice1(Order o, Form1 f)
        {
            InitializeComponent();
            this.o = o;
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

            label6.Text = "$" + Convert.ToString(o.subtotal);
            label7.Text = "$" + Convert.ToString(o.tax);
            label8.Text = "$" + Convert.ToString(o.total);
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
                i.SubItems.Add(Convert.ToString(p.price));
                i.SubItems.Add(Convert.ToString(p.orderQuantity));
                listView1.Items.Add(i);
            }
        }

        //NEW TRANSACTION
        private void button1_Click(object sender, EventArgs e)
        {
            //UPDATE DATABASE WITH NEW QUANTITIES

            start.ResetForm();
            start.Show();

            this.Close();
        }
    }
}
