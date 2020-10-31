using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Ninject
{
    public static class InstanceFactory
    {
        public static StandardKernel kernel = new StandardKernel(new InstanceModule());
        public static T GetInstance<T>()
        {
            return kernel.Get<T>();
        }
    }
}