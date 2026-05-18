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
    public class Shop : Prototype, IShop
    {
        #region Properties
        public int? ShopNameId { get; set; }
        public string Address { get; set; }
        public string Shedule { get; set; }
        #endregion

        #region IShop Members
        int IShop.ShopNameId
        {
            get { return this.ShopNameId.Value; }
            set { this.ShopNameId = value; }
        }
        string IShop.Address
        {
            get { return this.Address; }
            set { this.Address = value; }
        }
        string IShop.Shedule
        {
            get { return this.Shedule; }
            set { this.Shedule = value; }
        }
        #endregion

        #region Override Members
        public override void Insert()
        {
            this.Id = ShopsPump.Max();

            ShopsPump.Insert(this);
        }
        public override void Update()
        {
            ShopsPump.Update(this);
        }
        public override void Delete()
        {
            ShopsPump.Delete(this.Id);
        }
        #endregion
    }
}
