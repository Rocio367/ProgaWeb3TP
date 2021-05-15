using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgaWeb3TP.Models
{
    public class ListaAticulosVM
    {
        public string nombre { get; set; }
        public string numero { get; set; }
        public Boolean eliminados { get; set; }

        public PagedList.IPagedList<DTOs.ArticuloDTO> articulos { get; set; }
        public List<string> nombres { get; set; }
        public List<string> numeros { get; set; }
       
    }
}
