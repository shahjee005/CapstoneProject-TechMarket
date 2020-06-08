using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechMarket.Model
{
    public class Customer
    {     
        [Key]
        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<Cart> Cart { get; set; }
       // public ICollection<CustomerShippingAddresses> CustomerShippingAddresses { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
