using System.Web.Http;
using Backend.Entidades;
using Backend.Logica;
namespace CommunyStoreApi.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/Login/iniciarSesion")]
        public ResIniciarSesion iniciarSesion(ReqIniciarSesion req)
        {
            return new LogicaIniciarSesion().iniciarSesion(req);
        }
    }
}