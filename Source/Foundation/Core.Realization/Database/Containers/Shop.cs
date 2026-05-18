using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;

using Entity = Core.Realization.Entities.Shop;


namespace Core.Realization.Database.Generation
{
    public partial class Shop
    {
        #region Constructors
        public Shop(IShop entity)
        {
            this.Id = entity.Id;
            this.ShopNameId = entity.ShopNameId;
            this.Address = entity.Address;
            this.Shedule = entity.Shedule;
        }
        #endregion

        #region Methods
        public IShop ToEntity()
        {
            Entity entity = new Entity();
            entity.Id = this.Id;
            entity.ShopNameId = this.ShopNameId;
            entity.Address = this.Address;
            entity.Shedule = this.Shedule;
            
            return entity;
        }
        #endregion
    }
}
