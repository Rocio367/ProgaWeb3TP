using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelo
{
    public class ClienteResponse
    {
        public int Count { get; set; }
        public IEnumerable<ClienteDatos> Items { get; set; }
    }
}
