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
    public class Product : Prototype, IProduct
    {
        #region Properties
        public string Name { get; set; }
        #endregion

        #region IProduct Members
        string IProduct.Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        #endregion

        #region Override Members
        public override void Insert()
        {
            this.Id = ProductsPump.Max();

            ProductsPump.Insert(this);
        }
        public override void Update()
        {
            ProductsPump.Update(this);
        }
        public override void Delete()
        {
            ProductsPump.Delete(this.Id);
        }
        #endregion
    }
}
