using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Abstraction.Containers;

using Running.Abstraction.Common;


namespace Running.Abstraction
{
    public static partial class Shops
    {
        public interface IReading : IOperations
        {
            IReadOnlyList<IShopBunch> Load();
        }
    }
}
