using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class Order: IEntity
    {
        [Key]
        public int orderId { get; set; }
        public DateTime date { get; set; }
        public string shipAdress { get; set; }
        public int totalPrice { get; set; }
        public string paymentType { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }
        [Required]
        public virtual User user { get; set; }
        public virtual List<OrderDetail> orderDetails { get; set; }

    }
}