using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Abstraction.Containers
{
    public interface IProductBunch
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
