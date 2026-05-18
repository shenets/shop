using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Common;


namespace Core.Realization.Common
{
    public abstract class Prototype : EntityID, IPrototype
    {
        #region IPrototype Members
        public abstract void Insert();
        public abstract void Update();
        public abstract void Delete();
        #endregion
    }
}
