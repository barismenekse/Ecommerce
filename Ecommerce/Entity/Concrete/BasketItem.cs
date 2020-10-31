using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class BasketItem:IEntity
    {
        public int basketItemId { get; set; }
        public int productQuantity { get; set; }
        public int totalPrice { get; set; }

        public int productId { get; set; }
        public virtual Product product { get; set; }
        [ForeignKey("basket")]
        public int basketId { get; set; }
        public Basket basket { get; set; }
    }
}