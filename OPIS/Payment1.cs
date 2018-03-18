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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Text = "Enter Cash Tendered:";
            label1.Visible = true;
            textBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string input = textBox1.Text;

            }
        }
    }
}
