using Ecommerce.Business;
using Ecommerce.Business.Abstract;
using Ecommerce.Entity;
using Ecommerce.Ninject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace Ecommerce.Controllers
{

    public class ValuesController : ApiController
    {
        private IProductService productService;
        private ICategoryService categoryService;
        public ValuesController()
        {
            productService = InstanceFactory.GetInstance<ProductService>();
            categoryService = InstanceFactory.GetInstance<CategoryService>();
        }
        // GET api/values
        public HttpResponseMessage Get()
        {
            List<Product> products = productService.GetAll();
            var response = JsonConvert.SerializeObject(products);
            return new HttpResponseMessage()
            {
                Content = new StringContent(response, System.Text.Encoding.UTF8, "application/json")
            };
        }


        // POST api/values
        public void Post([FromBody]HttpContent content)
        {
            var encoding = Encoding.UTF8;
            string documentContents;
            using (Stream receiveStream = Request.Content.ReadAsStreamAsync().Result)
            {
                receiveStream.Position = 0;
                using (StreamReader readStream = new StreamReader(receiveStream, encoding))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }

            Product product = JsonConvert.DeserializeObject<Product>(documentContents);
            productService.Insert(product);

        }


    }
}
