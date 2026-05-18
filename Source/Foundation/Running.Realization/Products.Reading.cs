using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Containers;
using Core.Realization.Pumps;

using IReading = Running.Abstraction.Products.IReading;


namespace Running.Realization
{
    public static partial class Products
    {
        public class Reading : IReading
        {
            public IReadOnlyList<IProductBunch> Find(int shopId)
            {
                try
                {
                    IReadOnlyList<IProductBunch> products = ProductsPump.Find(shopId);
                    return products;
                }
                catch (Exception exception)
                {
                    // Write to log
                    // ...

                    throw;
                }
            }
        }
    }
}
