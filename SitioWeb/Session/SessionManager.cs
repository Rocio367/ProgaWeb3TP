using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SitioWeb.Session
{
    public static class SessionManager
    {

        public static T Get<T>(this ISession session, string clave)
        {
            var valor = session.GetString(clave);
            if (valor == null)
                return default(T);
            else
                return JsonConvert.DeserializeObject<T>(valor);
        }
        public static void Set<T>(ISession session, string clave, T valor)
        {
            string stringValue = JsonConvert.SerializeObject(valor);
            session.SetString(clave, stringValue);
        }
    }
}
