using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Books_Frontend.Interface
{
    public interface IBase
    {
        HttpClient Initial();
    }
}
