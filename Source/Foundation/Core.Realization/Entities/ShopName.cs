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
    public class ShopName : Prototype, IShopName
    {
        #region Properties
        public string Name { get; set; }
        #endregion

        #region IShopName Members
        string IShopName.Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        #endregion

        #region Override Members
        public override void Insert()
        {
            this.Id = ProductsPump.Max();

            ShopNamesPump.Insert(this);
        }
        public override void Update()
        {
            ShopNamesPump.Update(this);
        }
        public override void Delete()
        {
            ShopNamesPump.Delete(this.Id);
        }
        #endregion
    }
}
