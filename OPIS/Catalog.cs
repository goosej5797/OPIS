using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class: Catalog
 * @purpose: The Catalog class is used to communicate with the database and store all of the
 *           business's stock in a single instance.
 */ 
namespace OPIS
{
    public class Catalog
    {
        //List of products from the Inventory database
        private List<Product> products = new List<Product>();

        //Catalog Constructor: generates the catalog
        public Catalog()
        {
            buildCatalog();
        }

        /*
         * @method: buildCatalog()
         * @purpose: connect to the Inventory Table in the database (or scan a file for TESTING ONLY)
         *           to create Product instances of each product, then add them to the catalog list.
         */
        public void buildCatalog()
        {
            StreamReader scan = new StreamReader("C:\\Users\\Katie\\Documents\\OPIS\\OPIS\\items.txt");
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

            scan.Close();
        }

        /*
         * @method: getAllProducts()
         * @purpose: return the Catalog (i.e. the list of products)
         */
        public List<Product> getAllProducts()
        {
            return products;
        }

        /*
         * @method: getProduct()
         * @param: name -> the Product name to be retrieved
         * @purpose: returns a Product instance by searching the 
         *           catalog by Product name.
         */
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
