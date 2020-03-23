using DAL_ADONET.Entities;
using DAL_ADONET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_ADONET.TDG
{
    public class ProductTDG:IProductTDG
    {
        private SqlConnection connection;

        public ProductTDG(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void Add(Product value)
        {
            var command = new SqlCommand($"Insert into Products values('{value.ProductId}', '{value.ProductName}', '{value.Category.CategoryId}','{value.Supplier.SupplierId}',)", connection);
            var res = command.ExecuteNonQuery();
        }

        public void Delete(int value)
        {
            var command = new SqlCommand($"Delete Products Where ProductId = '{value}'", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Product> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products join Suppliers on Products.SupplierId = Suppliers.SupplierId join Categories on Products.CategoryId = Categories.CategoryId;", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            List<Product> products = new List<Product>();
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Product prod = new Product();
                    Supplier sup = new Supplier();
                    Category cat = new Category();
                    var cells = row.ItemArray;
                    prod.ProductId = (int)cells[0];
                    prod.ProductName = (string)cells[1];
                    cat.CategoryId = (int)cells[2];
                    cat.CategoryName = (string)cells[3];
                    sup.SupplierId = (int)cells[4];
                    sup.SupplierName = (string)cells[5];
                    prod.Supplier = sup;
                    prod.Category = cat;
                    products.Add(prod);
                }
            }
            return products;
        }

        public Product GetById(int id)
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"Select TOP(1) * from Products left join Suppliers on Products.SupplierId = Suppliers.SupplierId left join Categories on Products.CategoryId = Categories.CategoryId where ProductId = '{id.ToString()}'", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Product prod = new Product();
                Supplier sup = null;
                Category cat = null;
                reader.Read();

                prod.ProductId = (int)reader.GetValue(0);
                prod.ProductName = (string)reader.GetValue(1);
                if (!reader.GetValue(6).GetType().Equals(typeof(DBNull)))
                {
                    sup = new Supplier();
                    sup.SupplierId = (int)reader.GetValue(6);
                    sup.SupplierName = (string)reader.GetValue(7);
                }

                if (!reader.GetValue(9).GetType().Equals(typeof(DBNull)))
                {
                    cat = new Category();
                    cat.CategoryId = (int)reader.GetValue(9);
                    cat.CategoryName = (string)reader.GetValue(11);
                }

                prod.Supplier = sup;
                prod.Category = cat;

                reader.Close();
                return prod;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public void Update(Product value)
        {
            var command = new SqlCommand($"Update Products Set ProductName = '{value.ProductName}','{value.Category.CategoryId}','{value.Supplier.SupplierId}' Where ProductId = '{value.ProductId}'", connection);
            command.ExecuteNonQuery();
        }
    }
}
