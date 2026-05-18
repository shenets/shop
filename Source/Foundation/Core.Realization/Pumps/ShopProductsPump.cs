using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;

using Core.Realization.Database.Generation;


namespace Core.Realization.Pumps
{
    public static class ShopProductsPump
    {
        public static int Max()
        {
            using (Storage storage = new Storage())
            {
                int? max = storage.ShopProducts.Max(item => (int?)item.Id);
                if (max == null)
                    return 1;

                return max.Value + 1;
            }
        }

        public static IShopProduct Select(int id)
        {
            using (Storage storage = new Storage())
            {
                ShopProduct container = storage.ShopProducts.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return null;

                return container.ToEntity();
            }
        }
        public static void Insert(IShopProduct entity)
        {
            using (Storage storage = new Storage())
            {
                ShopProduct container = new ShopProduct(entity);

                storage.ShopProducts.Add(container);

                storage.SaveChanges();
            }
        }
        public static void Update(IShopProduct entity)
        {
            using (Storage storage = new Storage())
            {
                ShopProduct container = new ShopProduct(entity);

                storage.Entry(container).State = EntityState.Modified;

                storage.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (Storage storage = new Storage())
            {
                ShopProduct container = storage.ShopProducts.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return;

                storage.ShopProducts.Remove(container);

                storage.SaveChanges();
            }
        }

        public static List<IShopProduct> Collect()
        {
            using (Storage storage = new Storage())
            {
                List<IShopProduct> couples = storage.ShopProducts.OrderBy(item => item.Id).ToList().Select(item => item.ToEntity()).ToList();
                return couples;
            }
        }
    }
}
