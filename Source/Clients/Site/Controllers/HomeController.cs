using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Running.Abstraction;
using Running.Abstraction.Common;

using Site.Models;

using Shop = Site.Models.Shop;


namespace Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Shops.IReading reading = Operations.Resolve<Shops.IReading>();

                List<Shop> shops = reading.Load().Convert();

                return this.View(shops);
            }
            catch (Exception exception)
            {
                this.ModelState.AddModelError("Error", exception);

                throw;
            }
        }
    }
}
