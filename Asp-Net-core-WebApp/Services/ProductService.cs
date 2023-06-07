using Asp_Net_core_WebApp.Models;
using Microsoft.Data.SqlClient;

namespace Asp_Net_core_WebApp.Services
{
    public class ProductService
    {
        private static string db_source = "mydb-1999.database.windows.net"; // Server name
        private static string db_user = "rootadmin"; // Database username
        private static string db_password = "Zakria@1999%"; // Database password
        private static string db_database = "mydb"; // Database name

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString); // Creates a new SqlConnection with the connection string
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection(); // Gets a connection to the database

            List<Product> _product_list = new List<Product>(); // List to store the retrieved products

            string statement = "SELECT * FROM Products"; // SQL statement to select all products

            conn.Open(); // Opens the database connection

            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int productId = reader.GetInt32(0);
                    string productName = reader.GetString(1);
                    int quantity = reader.GetInt32(2);

                    Product product = new Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        Quantity = quantity
                    };

                    _product_list.Add(product);
                }
            }

            conn.Close();


            return _product_list; // Returns the list of products
        }
    }
}












//old
/*
using (SqlDataReader reader = cmd.ExecuteReader()) // Executes the command and reads the results
{
    while (reader.Read()) // Iterates through each row in the result set
    {
        // Creates a new Product object and assigns values from the reader
        Product product = new Product()
        {
            ProductId = reader.GetInt32(0), // Assumes that the first column in the result set is the ProductId
            ProductName = reader.GetString(1), // Assumes that the second column is the ProductName
            Quantity = reader.GetInt32(2) // Assumes that the third column is the Quantity
        };
        _product_list.Add(product); // Adds the product to the list
    }
}

conn.Close(); // Closes the database connection
*/