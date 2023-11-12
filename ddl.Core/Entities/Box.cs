using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Core.Entities
{
    public class Box
    {
        private static int id = 1;
        public int Id { get; }
        public User User { get; set; }
        public Product Product { get; set; }
        public string UserDeliveryAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public DateTime dateTime { get; }= DateTime.Now;
        public Box(User user, Product product, string userDeliveryAddress,string userPhoneNumber)
        {
            Id = id++;
            User = user;
            Product = product;  
            UserDeliveryAddress = userDeliveryAddress;
            UserPhoneNumber = userPhoneNumber;
        }
    }
}
