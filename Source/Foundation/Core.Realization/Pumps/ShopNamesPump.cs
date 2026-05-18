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
    public static class ShopNamesPump
    {
        public static int Max()
        {
            using (Storage storage = new Storage())
            {
                int? max = storage.ShopNames.Max(item => (int?)item.Id);
                if (max == null)
                    return 1;

                return max.Value + 1;
            }
        }

        public static IShopName Select(int id)
        {
            using (Storage storage = new Storage())
            {
                ShopName container = storage.ShopNames.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return null;

                return container.ToEntity();
            }
        }
        public static void Insert(IShopName entity)
        {
            using (Storage storage = new Storage())
            {
                ShopName container = new ShopName(entity);

                storage.ShopNames.Add(container);

                storage.SaveChanges();
            }
        }
        public static void Update(IShopName entity)
        {
            using (Storage storage = new Storage())
            {
                ShopName container = new ShopName(entity);

                storage.Entry(container).State = EntityState.Modified;

                storage.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (Storage storage = new Storage())
            {
                ShopName container = storage.ShopNames.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return;

                storage.ShopNames.Remove(container);

                storage.SaveChanges();
            }
        }
    }
}
