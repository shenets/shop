using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Abstraction.Common
{
    public interface IEntityID : IEntity
    {
        int Id { get; }
    }
}
