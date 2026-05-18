using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;

using Entity = Core.Realization.Entities.Product;


namespace Core.Realization.Database.Generation
{
    public partial class Product
    {
        #region Constructors
        public Product(IProduct entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }
        #endregion

        #region Methods
        public IProduct ToEntity()
        {
            Entity entity = new Entity();
            entity.Id = this.Id;
            entity.Name = this.Name;

            return entity;
        }
        #endregion
    }
}
