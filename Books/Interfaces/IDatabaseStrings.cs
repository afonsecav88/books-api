using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Interfaces
{
    public interface IDatabaseStrings
    {
        string CollectionName { get; set; }
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
