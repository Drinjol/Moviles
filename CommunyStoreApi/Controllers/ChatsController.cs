using Backend.Entidades;
using Backend.Entidades.Request;
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
    public class ChatsController : ApiController
    {
      

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/chats/obtenerchats")]
        public ResObtenerChats obtenerchats(ReqObtenerChats req)
        {
            //int id usuario
            return new LogChats().obtenerchats(req);

        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/chats/obtenerMensajesConIdChat")]
        public ResObtenerMensajes obtenerMensanjes(ReqObtenerMensajes req)
        {
            //int id chat
            return new LogChats().obtenerMensajes(req);

        }



        // GET: Mensaje
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/chats/ingresarMensaje")]
        public ResIngresarMensaje ingresarMensajeApi(ReqIngresarMensaje req)
        {
            return new LogChats().ingresarMensaje(req);
        }


        // GET: CrearChatNuevo
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CommunyStoreApi/chats/crearChat")]
        public ResCrearChat crearChat(ReqCrearChat req)
        {
            return new LogChats().crearChatNuevo(req);
        }

    }





}