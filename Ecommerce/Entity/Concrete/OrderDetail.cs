using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class OrderDetail:IEntity
    {
        public int orderDetailId { get; set; }
        public int unitPrice { get; set; }
        public int quantity { get; set; }
        [ForeignKey("order")]
        public int orderId { get; set; }
        public virtual Order order { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        public virtual Product product { get; set; }
    }
}