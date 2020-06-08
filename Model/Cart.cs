using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechMarket.Model
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImageUrl { get; set; }
        public string productInformation { get; set; }
        public int quantity { get; set; }
        public double productPrice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}