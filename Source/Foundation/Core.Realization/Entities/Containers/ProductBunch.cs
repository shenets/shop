using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Containers;


namespace Core.Realization.Entities.Containers
{
    public class ProductBunch : IProductBunch
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region IProductBunch Members
        int IProductBunch.Id
        {
            get { return this.Id.Value; }
        }
        string IProductBunch.Name
        {
            get { return this.Name; }
        }
        string IProductBunch.Description
        {
            get { return this.Description; }
        }
        #endregion
    }
}
