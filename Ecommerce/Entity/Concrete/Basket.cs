using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class Basket:IEntity
    {
        [Key]
        public int basketId { get; set; }
        public int totalPrice { get; set; }
        [ForeignKey("user")]
        [Index(IsUnique = true)]
        [Required]
        public string userId { get; set; }
        [Required]
        public virtual User user { get; set; }
        public virtual List<BasketItem> basketItems { get; set; }
    }
}