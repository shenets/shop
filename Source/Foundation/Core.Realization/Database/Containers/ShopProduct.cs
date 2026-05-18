using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;

using Entity = Core.Realization.Entities.ShopProduct;


namespace Core.Realization.Database.Generation
{
    public partial class ShopProduct
    {
        #region Constructors
        public ShopProduct()
        {
        }
        public ShopProduct(IShopProduct entity)
        {
            this.Id = entity.Id;
            this.ShopId = entity.ShopId;
            this.ProductId = entity.ProductId;
            this.Description = entity.Description;
        }
        #endregion

        #region Methods
        public IShopProduct ToEntity()
        {
            Entity entity = new Entity();
            entity.Id = this.Id;
            entity.ShopId = this.ShopId;
            entity.ProductId = this.ProductId;
            entity.Description = this.Description;

            return entity;
        }
        #endregion
    }
}
