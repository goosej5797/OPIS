using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OPIS
{
    public class Catalog
    {
        DatabaseConnection objConnect;
        string conString;

        DataSet ds;
        DataRow dRow;

        int MaxRows;
        int inc = 0;

        private List<Product> products = new List<Product>();
        public Catalog()
        {
            buildCatalog();
        }

        public void buildCatalog()
        {
            objConnect = new DatabaseConnection();
            conString = Properties.Settings.Default.DatabaseConnString;
            objConnect.connection_string = conString;
            objConnect.Sql = "SELECT * FROM Inventory";

            ds = objConnect.GetConnection;
            MaxRows = ds.Tables[0].Rows.Count;

            Product prod;
            for (int x = 0; x < MaxRows; x++)
            {
                dRow = ds.Tables[0].Rows[x];
                string name = dRow.ItemArray.GetValue(1).ToString();
                string productId = dRow.ItemArray.GetValue(0).ToString();
                double cost = (double)dRow.ItemArray.GetValue(2);
                int quantity = (int)dRow.ItemArray.GetValue(3);
                prod = new Product(name, productId, cost, quantity);
                products.Add(prod);
            }
            
        }

        public void viewCatalog()
        {

        }

        public void getProduct(string itemId)
        {

        }

        public void productDescription(string itemNo)
        {

        }
    }
}
