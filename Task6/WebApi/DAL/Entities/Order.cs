using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        //public virtual ICollection<ProductOrder> ProductOrders { get; set; }

        public Order()
        {
            //ProductOrders = new List<ProductOrder>();
            DateOfCreation = DateTime.Now;
        }
    }
}
