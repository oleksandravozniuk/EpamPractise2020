using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        //public ICollection<ProductOrderDTO> ProductOrders { get; set; }

        public OrderDTO()
        {
            //ProductOrders = new List<ProductOrderDTO>();
            DateOfCreation = DateTime.Now;
        }
    }
}
