using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Common;


namespace Core.Realization.Common
{
    public abstract class EntityID : IEntityID
    {
        public int Id { get; set; }
    }
}
