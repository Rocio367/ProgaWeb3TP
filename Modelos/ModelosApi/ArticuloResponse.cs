using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelos.ModelosApi
{
    public class ArticuloResponse
    {
        public int Count { get; set; }
        public IEnumerable<ArticuloDatos> Items { get; set; }
    }
}
