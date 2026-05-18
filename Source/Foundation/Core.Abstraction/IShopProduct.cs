using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Common;


namespace Core.Abstraction
{
    public interface IShopProduct : IEntityID, IPrototype
    {
        int ShopId { get; set; }
        int ProductId { get; set; }
        string Description { get; set; }
    }
}
