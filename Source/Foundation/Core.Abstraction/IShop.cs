using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Common;


namespace Core.Abstraction
{
    public interface IShop : IEntityID, IPrototype
    {
        int ShopNameId { get; set; }
        string Address { get; set; }
        string Shedule { get; set; }
    }
}
