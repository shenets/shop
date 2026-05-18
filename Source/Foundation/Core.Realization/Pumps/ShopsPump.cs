using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;
using Core.Abstraction.Containers;

using Core.Realization.Database.Generation;
using Core.Realization.Entities.Containers;


namespace Core.Realization.Pumps
{
    public static class ShopsPump
    {
        public static int Max()
        {
            using (Storage storage = new Storage())
            {
                int? max = storage.Shops.Max(item => (int?)item.Id);
                if (max == null)
                    return 1;

                return max.Value + 1;
            }
        }

        public static IShop Select(int id)
        {
            using (Storage storage = new Storage())
            {
                Shop container = storage.Shops.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return null;

                return container.ToEntity();
            }
        }
        public static void Insert(IShop entity)
        {
            using (Storage storage = new Storage())
            {
                Shop container = new Shop(entity);

                storage.Shops.Add(container);

                storage.SaveChanges();
            }
        }
        public static void Update(IShop entity)
        {
            using (Storage storage = new Storage())
            {
                Shop container = new Shop(entity);

                storage.Entry(container).State = EntityState.Modified;

                storage.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (Storage storage = new Storage())
            {
                Shop container = storage.Shops.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return;

                storage.Shops.Remove(container);

                storage.SaveChanges();
            }
        }

        public static IReadOnlyList<IShopBunch> Load()
        {
            using (Storage storage = new Storage())
            {
                var query = from shop in storage.Shops
                            join shopName in storage.ShopNames
                                on shop.ShopNameId equals shopName.Id
                            select new ShopBunch
                            {
                                Id = shop.Id,
                                Name = shopName.Name,
                                Address = shop.Address,
                                Shedule = shop.Shedule
                            };

                IReadOnlyList<ShopBunch> collection = query.ToList();
                return collection;
            }
        }
    }
}
