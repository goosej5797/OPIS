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
    * Form: Payment1
    * @purpose: The second window that will appear when the customer is
    *           ready to checkout. This form will facilitate payment by
    *           either cash or card.
    */
    public partial class Payment1 : Form
    {
        public Order o;
        public Catalog c;
        public Form1 start;

        /*
         * @method: Payment1()
         * @param: o -> Order transferred from Form1
         * @purpose: instantiate the customer's Order
         */
        public Payment1(Order o, Catalog c, Form1 f)
        {
            this.o = o;
            this.c = c;
            start = f;
            InitializeComponent();
        }

        private void Payment1_Load(object sender, EventArgs e)
        {
            updateTotals();
        }

        /*
         * @method: updateTotals()
         * @purpose: updates the Order's totals and displays them on the User Interface
         */
        public void updateTotals()
        {
            o.setTotals();

            subAmt.Text = "$" + o.subtotal.ToString("F");
            taxAmt.Text = "$" + o.tax.ToString("F");
            ttl.Text = "$" + o.total.ToString("F");
        }

        /*
         * @button1: "Credit/Debit"
         * @purpose: set up the User Interface for payment by card
         */
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            label1.Text = "Enter Card Number:";
            label1.Visible = true;
            textBox1.Visible = true;
            Submit.Visible = true;
        }

        /*
         * @button1: "Cash"
         * @purpose: set up the User Interface for payment by cash
         */
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Text = "Enter Cash Tendered:";
            label1.Visible = true;
            textBox1.Visible = true;
            Submit.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /*
         * @Button: "Submit"
         * @purpose: facilitate payment by card or cash, ensuring that
         *           payment is valid for either method.
         */
        private void Submit_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            //if payment by card
            if(label1.Text.Equals("Enter Card Number:"))
            {
                try
                {
                    double change = o.payWithCard(input);
                    if(change == 0)
                    {
                        Error.Visible = false;
                        label6.Visible = true;
                        chngDue.Visible = true;
                        chngDue.Text = "$" + change.ToString("F");

                        Submit.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        Invoice.Visible = true;
                    }
                    else
                    {
                        //if invalid card number entered, error displayed on user interface
                        Error.Text = "****Invalid Card Entered!";
                        Error.Visible = true;
                    }

                }
                catch
                {
                    //if invalid card number entered, error displayed on user interface
                    Error.Text = "****Invalid Card Entered!";
                    Error.Visible = true;
                }
            }
            //if payment by cash
            else
            {
                try
                {
                    double change = o.payWithCash(input);

                    //ensures that tender given is greater than or equal to order total
                    if (change >= 0)
                    {
                        Error.Visible = false;
                        label6.Visible = true;
                        chngDue.Visible = true;
                        chngDue.Text = "$" + change.ToString("F");

                        Submit.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        Invoice.Visible = true;
                    }
                    else
                    {
                        //if tender given is less than order total, error displayed on user interface
                        Error.Text = "***Invalid Tender Entered!";
                        Error.Visible = true;
                    }
                }
                catch
                {
                    //if invalid cash amount entered, error displayed on user interface
                    Error.Text = "***Invalid Tender Entered!";
                    Error.Visible = true;
                }
            }
        }

        /*
         * @button = "Invoice"
         * @purpose: open the Invoice User Interface
         */
        private void Invoice_Click(object sender, EventArgs e)
        {
            Invoice1 invoice = new Invoice1(o, c, start);

            // Show the invoice form
            invoice.Show();
            this.Close();
        }
    }
}
