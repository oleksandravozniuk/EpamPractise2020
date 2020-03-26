using DAL_ADONET.Entities;
using DAL_ADONET.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADONET.TDG
{
    public class CategoryTDG:ICategoryTDG
    {
        private SqlConnection connection;

        public CategoryTDG(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void Create(Category value)
        {
            var command = new SqlCommand($"Insert into Categories values('{value.CategoryId}', null, '{value.CategoryName}')", connection);

            command.ExecuteNonQuery();
        }

        public void Delete(int value)
        {
            var command = new SqlCommand($"Delete Categories Where CategoryId = '{value}'", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Category> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Categories", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            List<Category> categories = new List<Category>();
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Category category = new Category();
                    var cells = row.ItemArray;
                    category.CategoryId = (int)cells[0];
                    category.CategoryName = (string)cells[1];
                    categories.Add(category);
                }
            }
            return categories;
        }

        public Category GetById(int id)
        {
            SqlCommand command = new SqlCommand($"Select * from Categories where CategoryId = '{id.ToString()}'", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Category category = new Category();
                reader.Read();

                category.CategoryId = (int)reader.GetValue(0);
                category.CategoryName = (string)reader.GetValue(1);

                reader.Close();
                return category;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public void Update(Category value)
        {
            var command = new SqlCommand($"Update Categories Set CategoryName = '{value.CategoryName}' Where CategoryId = '{value.CategoryId}'", connection);

            var res = command.ExecuteNonQuery();
        }
    }
}
