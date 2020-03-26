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
    public class SupplierTDG:ISupplierTDG
    {
        private SqlConnection connection;

        public SupplierTDG(SqlConnection connection)
        {
            this.connection = connection;
        }
        public void Create(Supplier value)
        {
            var command = new SqlCommand($"Insert into Suppliers values('{value.SupplierId}', '{value.SupplierName}')", connection);

            command.ExecuteNonQuery();
        }

        public void Delete(int value)
        {
            var command = new SqlCommand($"Delete Suppliers Where SupplierId = '{value}'", connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Supplier> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Suppliers", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            List<Supplier> suppliers = new List<Supplier>();
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Supplier supplier = new Supplier();
                    var cells = row.ItemArray;
                    supplier.SupplierId = (int)cells[0];
                    supplier.SupplierName = (string)cells[1];
                    suppliers.Add(supplier);
                }
            }
            return suppliers;
        }

        public Supplier GetById(int id)
        {
            SqlCommand command = new SqlCommand($"Select * from Suppliers where SupplierId = '{id.ToString()}'", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Supplier supplier = new Supplier();
                reader.Read();

                supplier.SupplierId = (int)reader.GetValue(0);
                supplier.SupplierName = (string)reader.GetValue(1);

                reader.Close();
                return supplier;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public void Update(Supplier value)
        {
            var command = new SqlCommand($"Update Suppliers Set SupplierName = '{value.SupplierName}', where SupplierId = '{value.SupplierId}'", connection);
            command.ExecuteNonQuery();
        }
    }
}
