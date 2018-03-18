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
            o = new Order();
            c = new Catalog();
            generateButtons();

            listView1.View = View.Details;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment1 payment = new Payment1(o);
            
            // Show the settings form
            payment.Show();
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

        public void generateButtons()
        {
            List<Product> products = c.getAllProducts();
            foreach(Product p in products)
            {
                Button b = new Button();
                b.Text = p.name;
                b.Name = p.name;
                b.Size = new System.Drawing.Size(94, 76);
                b.Click += btn_action;
                flowLayoutPanel1.Controls.Add(b);
                
            }
        }

        public void btn_action(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Console.WriteLine(btn.Name);

            Product p = c.getProduct(btn.Name);
            o.addItem(p);

            updateListView();

            updateTotal();
        }

        public void updateListView()
        {
            listView1.Items.Clear();

            List<Product> products = o.getEntireOrder();

            foreach(Product p in products)
            {
                ListViewItem i = new ListViewItem(p.name);
                i.SubItems.Add(Convert.ToString(p.price));
                i.SubItems.Add(Convert.ToString(p.orderQuantity));
                listView1.Items.Add(i);
            }

        }

        public void updateTotal()
        {
            o.setTotals();

            label2.Text = "$" + Convert.ToString(o.getSubtotal());
            label5.Text = "$" + Convert.ToString(o.getTax());
            label4.Text = "$" + Convert.ToString(o.getTotal());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                String pName = listView1.SelectedItems[0].SubItems[0].Text;

                Product p = c.getProduct(pName);
                o.removeItem(p);

                updateListView();
                updateTotal();
            }
            catch
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String pName = listView1.SelectedItems[0].SubItems[0].Text;
                Product p = c.getProduct(pName);
                p.orderQuantity--;
                if (p.orderQuantity == 0)
                {
                    o.removeItem(p);
                }

                updateListView();
                updateTotal();
            }
            catch
            {

            }

        }
    }
}
