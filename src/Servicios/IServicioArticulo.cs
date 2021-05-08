using System;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IServicioArticulo
    {
        void Guardar(ArticuloDTO ArticuloDTO);
        void Editar(ArticuloDTO ArticuloDTO);
        void Eliminar(ArticuloDTO ArticuloDTO);
        List<ArticuloDTO> ObtenerArticulos();
    }
}
