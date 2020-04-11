using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }

        public OrderModel()
        {
            
            DateOfCreation = DateTime.Now;
        }
    }
}