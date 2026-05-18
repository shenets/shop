using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;

using Entity = Core.Realization.Entities.ShopName;


namespace Core.Realization.Database.Generation
{
    public partial class ShopName
    {
        #region Constructors
        public ShopName(IShopName entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }
        #endregion

        #region Methods
        public IShopName ToEntity()
        {
            Entity entity = new Entity();
            entity.Id = this.Id;
            entity.Name = this.Name;

            return entity;
        }
        #endregion
    }
}
