using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Containers;


namespace Core.Realization.Entities.Containers
{
    public class ShopBunch : IShopBunch
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Shedule { get; set; }
        #endregion

        #region IShopBunch Members
        int IShopBunch.Id
        {
            get { return this.Id.Value; }
        }
        string IShopBunch.Name
        {
            get { return this.Name; }
        }
        string IShopBunch.Address
        {
            get { return this.Address; }
        }
        string IShopBunch.Shedule
        {
            get { return this.Shedule; }
        }
        #endregion
    }
}
