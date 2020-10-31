
using Ecommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Session
{
    public static class CurrentSession
    {
        public static User getCurrentUser()
        {
            if (HttpContext.Current.Session["user"] == null) return null;
            else
            {
                User currentUser = (User)HttpContext.Current.Session["user"];
                return currentUser;
            }

        }
    }
}