using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Containers;
using Core.Realization.Pumps;

using IReading = Running.Abstraction.Shops.IReading;


namespace Running.Realization
{
    public static partial class Articles
    {
        public class Reading : IReading
        {
            public IReadOnlyList<IShopBunch> Load()
            {
                try
                {
                    IReadOnlyList<IShopBunch> collection = ShopsPump.Load();
                    return collection;
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
