using DorOrWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace DorOrWebApi.Controllers
{
     public class ProductController : ApiController
     {
          // GET: api/Product
           [EnableCors("*", "*", "*")]
          public IHttpActionResult Get()
          {
               ProductRepository repos = new ProductRepository();
               return Ok(repos.Retrieve());
          }

          // GET: api/Product/5
           [EnableCors("*", "*", "*")]
          public IHttpActionResult Get(int id)
        {
            ProductRepository repos = new ProductRepository();
            var prods = repos.Retrieve();

            var desireProd = prods.FirstOrDefault(p => p.ProductId == id);

               if(desireProd == null)
               {
                    return Content(HttpStatusCode.BadRequest, "Source Not Found");
               }

               return Ok(desireProd);

        }

          // POST: api/Product
          [EnableCors("*","*","*")]
           public void Post([FromBody]Product product)
          {
               ProductRepository repos = new ProductRepository();
               var prods = repos.Save(product);
          }

          // PUT: api/Product/5
          public void Put(int id, [FromBody]string value)
          {
          }

          // DELETE: api/Product/5
          public void Delete(int id)
          {
          }
     }
}
