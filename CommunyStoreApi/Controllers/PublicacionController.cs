using Backend.Entidades;
using Backend.Entidades.Response;
using Backend.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CommunyStoreApi.Controllers
{
    public class PublicacionController : ApiController
    {
        // GET: Publicacion
        // [System.Web.Http.HttpPost]
        // [System.Web.Http.Route("CommunyStoreApi/publicacion/ingresarPublicacion")]
        // public ResIngresarPublicacion ingresar(ReqIngresarPublicacion req/*, ReqIngresarImagen reqImage*/)
        // {
        //    return new LogPublicacion().ingresarPublicacion(req/*, reqImage*/);
        //  }*/


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/obtenerPublicacion")]
        public ResObtenerPublicaciones ObtenerPublicaciones(ReqObtenerPublicaciones req)
        {
            //ResObtenerPublicaciones res = new ResObtenerPublicaciones();
            // req.sesion = "12345";
            //string categoria = "";
            return new LogPublicacion().obtenerPublicaciones(req);

        }
    }
}