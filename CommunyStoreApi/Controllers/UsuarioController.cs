using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Backend.Entidades;
using Backend.Entidades.Request;
using Backend.Entidades.Response;
using Backend.Logica;
namespace CommunyStoreApi.Controllers
{
    public class UsuarioController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/usuario/agregarUsuario")]
        public ResAgregarUsuario agregarUsuario(ReqAgregarUsuario req)
        {
            return new LogicaUsuario().agregarUsuario(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/usuario/ActualizarUsuario")]
        public ResActualizarUsuario ActualizarUsuario(ReqActualizarUsuario req)
        {
            return new LogicaUsuario().ActualizarUsuario(req);
        }
    }
}