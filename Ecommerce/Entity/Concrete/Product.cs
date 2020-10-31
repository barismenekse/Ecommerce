using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class Product:IEntity
    {
        public int productId { get; set; }
        [DisplayName("Product Name")]
        public string name { get; set; }
        public string description { get; set; }
        public int unitPrice { get; set; }
        public int stockQuantity { get; set; }
        public int categoryId { get; set; }
        public virtual Category category { get; set; }
    }
}