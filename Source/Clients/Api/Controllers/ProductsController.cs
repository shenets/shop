using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Core.Abstraction.Containers;

using Running.Abstraction;
using Running.Abstraction.Common;


namespace Api.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Find(dynamic options)
        {
            try
            {
                int shopId;
                if (int.TryParse(options.shopId.ToString(), out shopId) == false)
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest);

                Products.IReading reading = Operations.Resolve<Products.IReading>();

                IReadOnlyList<IProductBunch> products = reading.Find(shopId);

                return this.Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception exception)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
