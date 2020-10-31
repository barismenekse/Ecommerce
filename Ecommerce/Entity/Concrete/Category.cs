using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class Category:IEntity
    {
        public int categoryId { get; set; }
        [DisplayName("Category Name")]
        public string name { get; set; }
        
        [ForeignKey("parentCategory")]
        public int? parentCategoryId { get; set; }
        public virtual Category parentCategory { get; set; }
       
    }
}