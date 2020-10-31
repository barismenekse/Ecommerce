using Ecommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Entity
{
    public class User:IEntity
    {
        public string userId { get; set; }
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        public virtual List<Order> orders { get; set; }

    }
}