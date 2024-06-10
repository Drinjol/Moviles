using Backend.DataAccess;
using Backend.Entidades;
using Backend.Entidades;
using Backend.Entidades.Request;
using Backend.Entidades.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogChats
    {
        public LogicaSesionValida logicaSesionValida = new LogicaSesionValida();


        public ResObtenerChats obtenerchats(ReqObtenerChats req)
        {
            Int16 tipoDeTransaccion = 0;
            string descripcionError = "";
            int? errorId = 0;
            ResObtenerChats res = new ResObtenerChats();
            res.listaDeErrores = new List<string>();
      

            try
            {

                ConnectionDataContext linq = new ConnectionDataContext();
                List<sp_obtener_chat_por_idUsuarioResult> listaDeLinq = new List<sp_obtener_chat_por_idUsuarioResult>();
                listaDeLinq = linq.sp_obtener_chat_por_idUsuario(req.idUsuario).ToList();
                res.chats = this.crearListaDeChats(listaDeLinq);
                res.resultado = true;

            }
            catch (Exception ex)
            {
                res.resultado = false;
                tipoDeTransaccion = 2;
                res.listaDeErrores.Add("error bd");
            }
            finally
            {
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoDeTransaccion, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }

        private List<Chats> crearListaDeChats(List<sp_obtener_chat_por_idUsuarioResult> listaDeLinq)
        {
            List<Chats> listaArmada = new List<Chats>();
            foreach (sp_obtener_chat_por_idUsuarioResult tipoComplejo in listaDeLinq)
            {
                listaArmada.Add(this.crearChat(tipoComplejo));
            }
            return listaArmada;
        }

        private Chats crearChat(sp_obtener_chat_por_idUsuarioResult unTipoComplejo)
        {
            Chats chat = new Chats();
            chat.idUsuario1 = new Usuario();
            chat.idUsuario2 = new Usuario();

            chat.idChat = (int)unTipoComplejo.tb_chat_id;
            chat.idUsuario1.Id = (int)unTipoComplejo.tb_usuario1_id;
            chat.idUsuario2.Id = (int)unTipoComplejo.tb_usuario2_id;
            chat.idUsuario2.nombre = unTipoComplejo.tb_usuario_nombre;
            chat.idUsuario2.apellidos = unTipoComplejo.tb_usuario_apellidos;
            chat.estado = unTipoComplejo.tb_chat_estado;
            
            return chat;
        }

        public ResObtenerMensajes obtenerMensajes(ReqObtenerMensajes req)
        {

            ResObtenerMensajes res = new ResObtenerMensajes();
            res.listaDeErrores = new List<string>();
            ReqBase reqBase = new ReqBase();
           

            ResBase resBase = new ResBase();
            resBase = logicaSesionValida.validarSesion(reqBase);

          
            try
            {

                ConnectionDataContext linq = new ConnectionDataContext();
                List<sp_obtenerMensajesConIdChatResult> listaDeLinq = new List<sp_obtenerMensajesConIdChatResult>();
                listaDeLinq = linq.sp_obtenerMensajesConIdChat(req.idChat).ToList();
                res.mensajes = listaDeLinq.Select(item => new Mensaje
                {

                    contenido = item.tb_mensaje_contenido,
                    idUsuario = (int)item.tb_usuario_id,
                    idchat = (int)item.tb_chats_id
                  
                }).ToList();

                res.resultado = true;
                res.listaDeErrores.Add("success");
                res.tipoRegistro = 1;
            }
            catch (Exception ex)
            {
                res.listaDeErrores.Add("Error de BD");
                res.tipoRegistro = 4;
                res.resultado = false;
            }
            finally
            {
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, res.tipoRegistro, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            //}



            return res;
        }



        public ResIngresarMensaje ingresarMensaje(ReqIngresarMensaje req)
        {
            short tipoRegistro = 0; //1 Exitoso - 2 Error en Logica - 3 Error No Controlado
            ResIngresarMensaje res = new ResIngresarMensaje();


            try
            {
                if (req == null)
                {
                    res.listaDeErrores.Add("Request null");
                    res.resultado = false;
                    tipoRegistro = 2;
                }
                else
                {

                    /* if (req.sesion == null)
                     {

                         res.listaDeErrores.Add("Sesion null");
                         res.resultado = false;
                         tipoRegistro = 2;
                     }
                     else
                     {

                         if (req.sesion == null)
                         {

                             res.listaDeErrores.Add("Sesion vacia");
                             res.resultado = false;
                             tipoRegistro = 2;
                         }

                         if (!req.sesion.esValido)
                         {

                             res.listaDeErrores.Add("Sesion vencida");
                             res.resultado = false;
                             tipoRegistro = 2;
                         }
                     }*/


                    if (String.IsNullOrEmpty(req.mensaje.contenido))
                    {
                        res.listaDeErrores.Add("contenido faltante");
                        res.resultado = false;
                        tipoRegistro = 2;
                    }
                    
                    if (!res.listaDeErrores.Any()) // Lista vacia 

                    {

                        ConnectionDataContext linq = new ConnectionDataContext();


                        int? idReturn = 0;
                        int? idError = 0;
                        string errorBd = "";

                        

                        linq.sp_ingresar_mensajes(req.mensaje.contenido,req.mensaje.idUsuario, req.mensaje.idchat);
                    
                        if (idError == null || idError == 0)
                        {
                            res.resultado = false;
                            res.listaDeErrores.Add("Error BD"); //GRAVISIMO!!!
                            tipoRegistro = 2; //No Exitoso
                        }
                        else
                        {
                            res.resultado = true;
                            res.listaDeErrores.Add("success");
                            res.tipoRegistro = 1;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add("Error interno");
                tipoRegistro = 3; //No Exitoso
            }
            finally
            {
                //Se bitacorea todo resultado. Exitoso o no exitoso.
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoRegistro, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;


        }





    }
}
