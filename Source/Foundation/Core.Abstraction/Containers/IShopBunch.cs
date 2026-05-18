using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Abstraction.Containers
{
    public interface IShopBunch
    {
        int Id { get; }
        string Name { get; }
        string Address { get; }
        string Shedule { get; }
    }
}
