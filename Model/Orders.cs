using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechMarket.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
       
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public double OrderTotal { get; set; }
        public int NumberOfItems { get; set; }

        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
} 