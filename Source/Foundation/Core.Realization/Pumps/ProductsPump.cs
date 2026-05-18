using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;
using Core.Abstraction.Containers;

using Core.Realization.Database.Generation;
using Core.Realization.Entities.Containers;


namespace Core.Realization.Pumps
{
    public static class ProductsPump
    {
        public static int Max()
        {
            using (Storage storage = new Storage())
            {
                int? max = storage.Products.Max(item => (int?)item.Id);
                if (max == null)
                    return 1;

                return max.Value + 1;
            }
        }

        public static IProduct Select(int id)
        {
            using (Storage storage = new Storage())
            {
                Product container = storage.Products.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return null;

                return container.ToEntity();
            }
        }
        public static void Insert(IProduct entity)
        {
            using (Storage storage = new Storage())
            {
                Product container = new Product(entity);

                storage.Products.Add(container);

                storage.SaveChanges();
            }
        }
        public static void Update(IProduct entity)
        {
            using (Storage storage = new Storage())
            {
                Product container = new Product(entity);

                storage.Entry(container).State = EntityState.Modified;

                storage.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (Storage storage = new Storage())
            {
                Product container = storage.Products.SingleOrDefault(item => item.Id == id);
                if (container == null)
                    return;

                storage.Products.Remove(container);

                storage.SaveChanges();
            }
        }

        public static IReadOnlyList<IProductBunch> Find(int shopId)
        {
            using (Storage storage = new Storage())
            {
                var query = from shopProduct in storage.ShopProducts
                            join product in storage.Products
                                on shopProduct.ProductId equals product.Id
                            where shopProduct.ShopId == shopId
                            select new ProductBunch
                            {
                                Id = product.Id,
                                Name = product.Name,
                                Description = shopProduct.Description
                            };

                IReadOnlyList<IProductBunch> collection = query.ToList();
                return collection;
            }
        }
    }
}
