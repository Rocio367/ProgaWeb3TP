using Microsoft.AspNetCore.Mvc;
using ProgaWeb3TP.Models;

namespace ProgaWeb3TP.Controllers
{
    public abstract class BaseController : Controller
    {
        public void CrearNotificacionExitosa(string mensaje)
        {
            CrearNotificacion(
                new NotificacionViewModel { Mensaje = mensaje, Tipo = TipoNotificacion.EXITOSO}
            );
        }

        public void CrearNotificacionDeError(string mensaje)
        {
            CrearNotificacion(
                new NotificacionViewModel { Mensaje = mensaje, Tipo = TipoNotificacion.ERROR }
            );
        }

        private void CrearNotificacion(NotificacionViewModel notificacion)
        {
            TempData["Notificacion.Mensaje"] = notificacion.Mensaje;
            TempData["Notificacion.Tipo"] = notificacion.Tipo;
            TempData["Notificacion.Mostrar"] = true;
        }
    }
}
