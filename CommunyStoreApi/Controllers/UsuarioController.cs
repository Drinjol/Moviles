using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Backend.Entidades;
using Backend.Entidades.Response;
using Backend.Logica;
using Newtonsoft.Json.Linq;
namespace CommunyStoreApi.Controllers
{
    public class UsuarioController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/usuario/agregarUsuario")]
        public ResAgregarUsuario agregarUsuario([FromBody] JObject usuarioJson)
        {
            Usuario usuario = usuarioJson.ToObject<Usuario>();
            ReqAgregarUsuario req = new ReqAgregarUsuario();
            req.usuario = usuario;
            return new LogicaUsuario().agregarUsuario(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/usuario/agregarInteraccionUsuario")]
        public ResAgregarInteraccionUsuario agregarInteraccionUsuario(ReqAgregarInteraccionUsuario req)
        {
            return new LogicaAgregarInteraccionUsuario().agregarInteraccionUsuario(req);
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/usuario/actualizarUsuario")]
        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            return new LogicaUsuario().ActualizarUsuario(req);
        }


    }
}