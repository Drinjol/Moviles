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
         [System.Web.Http.HttpPost]
         [System.Web.Http.Route("CommunyStoreApi/publicacion/ingresarPublicacion")]
        public ResIngresarPublicacion ingresar(ReqIngresarPublicacion req)
         {
            return new LogPublicacion().ingresarPublicacion(req);
          }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/obtenerPublicacion")]
        public ResObtenerPublicaciones ObtenerPublicaciones(ReqObtenerPublicaciones req)
        {
          
            return new LogPublicacion().obtenerPublicaciones(req);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/obtenerPublicacionPorIdUsuario")]
        public ResObtenerPublicacionIdUsuario ObtenerPublicacionesPorIdUsuario(ReqObtenerPublicacionPorIdUsuario req)
        {
            //int id usuario
            return new LogPublicacion().obteneListaDePublicacionesPorIdUsuario(req);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/obtenerPublicacionGuardadas")]
        public ResObtenerPublicacionesGuardadas ObtenerPublicacionesGuardadas(ReqObtenerPublicacionesGuardadas req)
        {
            
            return new LogicaPublicacionesGuardadas().obtenerpublicacionesGuardadas(req);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/agregarPublicacionGuardado")]
        public ResAgregarPublicacionGuardada agregarPublicacionGuardado(ReqAgregarPublicacionGuardada req)
        {

            return new LogicaPublicacionesGuardadas().agregarPublicacionGuardada(req);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/eliminarPublicacionGuardada")]
        public ResEliminarPublicacionGuardada eliminarPublicacionGuardada(ReqEliminarPublicacionGuardada req)
        {

            return new LogicaPublicacionesGuardadas().eliminarPublicacionGuardada(req);

        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/publicacion/buscarPublicaciones")]
        public ResBuscarPublicaciones ObtenerPublicacionesBuscadas(ReqBuscarPublicaciones req)
        {

            return new LogPublicacion().buscarPublicaciones(req);

        }




    }
}