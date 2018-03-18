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
    public partial class Invoice1 : Form
    {
        Order o;

        public Invoice1(Order o)
        {
            InitializeComponent();
            this.o = o;

            ordrNum.Text = o.orderNumber;
            listView1.View = View.Details;
        }

        private void Invoice1_Load(object sender, EventArgs e)
        {
            updateTotals();
            updateListView();
        }

        public void updateTotals()
        {
            o.setTotals();

            label6.Text = "$" + Convert.ToString(o.getSubtotal());
            label7.Text = "$" + Convert.ToString(o.getTax());
            label8.Text = "$" + Convert.ToString(o.getTotal());
        }

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
    }
}
