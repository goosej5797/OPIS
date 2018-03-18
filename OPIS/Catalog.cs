using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIS
{
    public class Catalog
    {
        private List<Product> products = new List<Product>();

        public Catalog()
        {
            buildCatalog();
        }

        public void buildCatalog()
        {
            StreamReader scan = new StreamReader("C:\\Users\\Katie\\Google Drive\\CMU\\Spring 2018\\CPS 410\\workspace\\OPIS\\OPIS\\items.txt");
            String[] substrings;

            String line = scan.ReadLine();

            while (line != null)
            {
                substrings = line.Split(' ');

                String name = substrings[0];
                String num = substrings[1];
                double price = Convert.ToDouble(substrings[2]);
                int qty = Convert.ToInt16(substrings[3]);

                products.Add(new Product(name, num, price, qty));

                line = scan.ReadLine();
            }

        }

        public List<Product> getAllProducts()
        {
            return products;
        }

        public Product getProduct(string name)
        {
            foreach(Product p in products)
            {
                if (p.name.Equals(name))
                {
                    return p;
                }
            }

            return null;
        }


    }
}
