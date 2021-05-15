namespace ProgaWeb3TP.Models
{
    public class NotificacionViewModel
    {
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
    }

    public class TipoNotificacion
    {
        public static readonly string INFORMATIVO = "info";
        public static readonly string EXITOSO = "success";
        public static readonly string ERROR = "danger";       
    }
}
