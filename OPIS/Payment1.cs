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
    public partial class Payment1 : Form
    {
        public Order o;
        public Payment1(Order o)
        {
            this.o = o;
            InitializeComponent();
        }

        private void Payment1_Load(object sender, EventArgs e)
        {
            updateTotals();
        }

        public void updateTotals()
        {
            o.setTotals();

            subAmt.Text = "$" + Convert.ToString(o.getSubtotal());
            taxAmt.Text = "$" + Convert.ToString(o.getTax());
            ttl.Text = "$" + Convert.ToString(o.getTotal());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            label1.Text = "Enter Card Number:";
            label1.Visible = true;
            textBox1.Visible = true;
            Submit.Visible = true;
        }

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

        private void Submit_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            //Console.WriteLine(input);

            if(label1.Text.Equals("Enter Card Number:"))
            {
                try
                {
                    long tender = Convert.ToInt64(input);

                    if (input.Length == 16)
                    {
                        Error.Visible = false;
                        label6.Visible = true;
                        chngDue.Visible = true;
                        chngDue.Text = "$0.00";

                        Submit.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        Invoice.Visible = true;
                    }
                }
                catch
                {
                    Error.Text = "****Invalid Card Entered!";
                    Error.Visible = true;
                }
            }
            else
            {
                try
                {
                    double tender = Convert.ToDouble(input);

                    if (tender >= o.getTotal())
                    {
                        Error.Visible = false;
                        label6.Visible = true;
                        chngDue.Visible = true;
                        chngDue.Text = "$" + (tender - o.getTotal());

                        Submit.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        Invoice.Visible = true;
                    }
                    else
                    {
                        Error.Text = "***Invalid Tender Entered!";
                        Error.Visible = true;
                    }
                }
                catch
                {
                    Error.Text = "***Invalid Tender Entered!";
                    Error.Visible = true;
                }
  
            }

        }

        private void Invoice_Click(object sender, EventArgs e)
        {
            Invoice1 invoice = new Invoice1(o);

            // Show the invoice form
            invoice.Show();
        }
    }
}
