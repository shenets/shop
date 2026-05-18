using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Realization.Database.Generation
{
    public class DBInitializer : CreateDatabaseIfNotExists<Storage>
    {
        #region Override Members
        protected override void Seed(Storage context)
        {
            this.InitializeShopNames(context);
            this.InitializeShops(context);
            this.InitializeProducts(context);
            this.InitializeShopProducts(context);

            base.Seed(context);
        }
        #endregion

        #region Assistants
        private void InitializeShopNames(Storage context)
        {
            List<ShopName> targets = new List<ShopName>();
            targets.Add(new ShopName { Id = 1, Name = "Мегашлеп" });
            targets.Add(new ShopName { Id = 2, Name = "Родны дух" });
            targets.Add(new ShopName { Id = 3, Name = "Рога и копыта" });

            foreach (ShopName target in targets)
            {
                context.ShopNames.Add(target);
            }
        }
        private void InitializeShops(Storage context)
        {
            List<Shop> targets = new List<Shop>();
            targets.Add(new Shop { Id = 1, ShopNameId = 1, Address = "г. Минск, ул. Могилевская, 51", Shedule = "Пн-Сб 10.00-20.00; Вс 10.00-18.00" });
            targets.Add(new Shop { Id = 2, ShopNameId = 1, Address = "г. Минск, ул. Немига, 28", Shedule = "Пн-Сб 10.00-20.00; Вс 10.00-18.00" });
            targets.Add(new Shop { Id = 3, ShopNameId = 1, Address = "г. Бобруйск, ул. Минская, 1058", Shedule = "Пн-Сб 10.00-20.00" });
            targets.Add(new Shop { Id = 4, ShopNameId = 2, Address = "г. Минск, просп. Победителей, 17", Shedule = "вс-чт: 09.00-23.00, пт,сб: 09.00-00.00" });
            targets.Add(new Shop { Id = 5, ShopNameId = 2, Address = "г. Бобруйск, просп. Вредителей, 17", Shedule = "вс-чт: 09.00-23.00, пт,сб: 09.00-00.00" });
            targets.Add(new Shop { Id = 6, ShopNameId = 3, Address = "Витебская обл., д. Копейная, ул. Советская, 23", Shedule = "Пн., Ср. 10.00-18.00" });

            foreach (Shop target in targets)
            {
                context.Shops.Add(target);
            }
        }
        private void InitializeProducts(Storage context)
        {
            List<Product> targets = new List<Product>();
            targets.Add(new Product { Id = 1, Name = "Сапоги" });
            targets.Add(new Product { Id = 2, Name = "Сандалии" });
            targets.Add(new Product { Id = 3, Name = "Хлеб" });
            targets.Add(new Product { Id = 4, Name = "Батон" });
            targets.Add(new Product { Id = 5, Name = "Вино 0.5" });
            targets.Add(new Product { Id = 6, Name = "Вино 0.7" });

            foreach (Product target in targets)
            {
                context.Products.Add(target);
            }
        }
        private void InitializeShopProducts(Storage context)
        {
            List<ShopProduct> targets = new List<ShopProduct>();
            targets.Add(new ShopProduct { Id = 1, ShopId = 1, ProductId = 1, Description = "Модные сапоги осень зима 2016 2017 – придутся по вкусу мужчинам, вынужденным целый день находиться на ногах, ведь они дарят желанный комфорт." });
            targets.Add(new ShopProduct { Id = 2, ShopId = 1, ProductId = 2, Description = "Отличаются элегантностью, изяществом, а также красотой и смелостью." });
            targets.Add(new ShopProduct { Id = 3, ShopId = 2, ProductId = 1, Description = "Модные сапоги осень зима 2016 2017 – придутся по вкусу девушкам, вынужденным целый день находиться на ногах, ведь они дарят желанный комфорт." });
            targets.Add(new ShopProduct { Id = 4, ShopId = 2, ProductId = 2, Description = "Отличаются элегантностью, изяществом, а также красотой и смелостью." });
            targets.Add(new ShopProduct { Id = 5, ShopId = 3, ProductId = 1, Description = "Модные сапоги осень зима 2016 2017 – придутся по вкусу любому, вынужденным целый день находиться на ногах, ведь они дарят желанный комфорт." });
            targets.Add(new ShopProduct { Id = 6, ShopId = 4, ProductId = 3, Description = "Свежий вчерашний хлеб" });
            targets.Add(new ShopProduct { Id = 7, ShopId = 4, ProductId = 4, Description = "Батон был свежий" });
            targets.Add(new ShopProduct { Id = 8, ShopId = 4, ProductId = 5, Description = "Вино улучшенного качества" });
            targets.Add(new ShopProduct { Id = 9, ShopId = 4, ProductId = 6, Description = null });
            
            targets.Add(new ShopProduct { Id = 10, ShopId = 5, ProductId = 3, Description = "Свежий хлеб" });
            targets.Add(new ShopProduct { Id = 11, ShopId = 5, ProductId = 4, Description = "Свежий батон" });
            targets.Add(new ShopProduct { Id = 12, ShopId = 5, ProductId = 5, Description = null });
            targets.Add(new ShopProduct { Id = 13, ShopId = 5, ProductId = 6, Description = null });

            targets.Add(new ShopProduct { Id = 14, ShopId = 6, ProductId = 5, Description = "Вино улучшенного качества" });
            targets.Add(new ShopProduct { Id = 15, ShopId = 6, ProductId = 6, Description = "Вино крепленое" });

            foreach (ShopProduct target in targets)
            {
                context.ShopProducts.Add(target);
            }
        }
        #endregion
    }
}
