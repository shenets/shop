using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction;

using Core.Realization.Common;
using Core.Realization.Pumps;


namespace Core.Realization.Entities
{
    public class ShopProduct : Prototype, IShopProduct
    {
        #region Properties
        public int? ShopId { get; set; }
        public int? ProductId { get; set; }
        public string Description { get; set; }
        #endregion

        #region IShopProduct Members
        int IShopProduct.ShopId
        {
            get { return this.ShopId.Value; }
            set { this.ShopId = value; }
        }
        int IShopProduct.ProductId
        {
            get { return this.ProductId.Value; }
            set { this.ProductId = value; }
        }
        #endregion

        #region Override Members
        public override void Insert()
        {
            this.Id = ShopProductsPump.Max();

            ShopProductsPump.Insert(this);
        }
        public override void Update()
        {
            ShopProductsPump.Update(this);
        }
        public override void Delete()
        {
            ShopProductsPump.Delete(this.Id);
        }
        #endregion
    }
}
