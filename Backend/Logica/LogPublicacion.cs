using Backend.DataAccess;
using Backend.Entidades;
using Backend.Entidades.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogPublicacion
    {
        public LogicaSesionValida logicaSesionValida = new LogicaSesionValida();


        public ResObtenerPublicaciones obtenerPublicaciones(ReqObtenerPublicaciones req)
        {
            Int16 tipoDeTransaccion = 0;
            string descripcionError = "";
            int? errorId = 0;
            ResObtenerPublicaciones res = new ResObtenerPublicaciones();
            res.listaDeErrores = new List<string>();
          //  ReqIngresarPublicacion req = new ReqIngresarPublicacion();

            var categoria = req.categoria;

            try
            {

                ConnectionDataContext linq = new ConnectionDataContext();
                List<SP_OBTENER_PUBLICACIONESResult> listaDeLinq = new List<SP_OBTENER_PUBLICACIONESResult>();
                listaDeLinq = linq.SP_OBTENER_PUBLICACIONES(req.categoria, req.usuarioID).ToList();
                res.publicaciones = this.crearListaDePublicaciones(listaDeLinq);
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

        private List<Publicacion> crearListaDePublicaciones(List<SP_OBTENER_PUBLICACIONESResult> listaDeLinq)
        {
            List<Publicacion> listaArmada = new List<Publicacion>();
            foreach (SP_OBTENER_PUBLICACIONESResult tipoComplejo in listaDeLinq)
            {
                listaArmada.Add(this.crearPublicacion(tipoComplejo));
            }
            return listaArmada;
        }

        private Publicacion crearPublicacion(SP_OBTENER_PUBLICACIONESResult unTipoComplejo)
        {

            ConnectionDataContext linq = new ConnectionDataContext();
            ReqObtenerPublicaciones req = new ReqObtenerPublicaciones();
            Publicacion pub = new Publicacion();
            pub.usuario = new Usuario();

            pub.idPublicacion = (int)unTipoComplejo.ID_PUBLICACION;
            pub.usuario.Id = (int)unTipoComplejo.ID_USUARIO;
            pub.usuario.nombre = unTipoComplejo.NOMBRE_USUARIO;
            pub.usuario.apellidos = unTipoComplejo.APELLIDOS_USUARIO;
            pub.fechaPublicacion = (DateTime)unTipoComplejo.FECHA_PUBLICACION;
            pub.descripcionPublicacion = unTipoComplejo.DESCRIPCION;
            pub.precioPublicacion = (decimal)unTipoComplejo.PRECIO;
            pub.categoriaPublicacion = unTipoComplejo.CATEGORIA;
            pub.estadoPublicacion = (int)unTipoComplejo.ESTADO;
            pub.favorito = (bool)unTipoComplejo.IsFavorito;

            // Convertir la cadena hexadecimal a una representación legible
            pub.nombresArchivos = HexStringToString(unTipoComplejo.IMAGEN_BINARIO);

            return pub;
        }

        private static string HexStringToString(string hex)
        {
            if (hex.StartsWith("0x"))
            {
                hex = hex.Substring(2);
            }

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return Encoding.ASCII.GetString(bytes);
        }




        public ResIngresarPublicacion ingresarPublicacion(ReqIngresarPublicacion req)
            {
                short tipoRegistro = 0; //1 Exitoso - 2 Error en Logica - 3 Error No Controlado
                ResIngresarPublicacion res = new ResIngresarPublicacion();
                

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


                        if (String.IsNullOrEmpty(req.publicacion.descripcionPublicacion))
                        {
                            res.listaDeErrores.Add("descripcion faltante");
                            res.resultado = false;
                            tipoRegistro = 2;
                        }
                        if (String.IsNullOrEmpty(req.publicacion.categoriaPublicacion))
                        {
                            res.listaDeErrores.Add("categoria faltante");
                            res.resultado = false;
                            tipoRegistro = 2;
                        }

                        if(String.IsNullOrEmpty(req.publicacion.nombresArchivos))
                    {
                        res.listaDeErrores.Add("imagenes faltante");
                        res.resultado = false;
                        tipoRegistro = 2;
                    }

                        if (!res.listaDeErrores.Any()) // Lista vacia 

                        {

                           ConnectionDataContext linq = new ConnectionDataContext();
                          

                            int? idReturn = 0;
                            int? idError = 0;
                            string errorBd = "";

                        string imagen = string.Join(";", req.publicacion.nombresArchivos);

                        linq.SP_INGRESAR_PUBLICACION(req.publicacion.usuario.Id, req.publicacion.descripcionPublicacion, req.publicacion.precioPublicacion, req.publicacion.categoriaPublicacion, imagen, ref idReturn, ref idError, ref errorBd);
                           // linq.SP_INGRESAR_PUBLICACION(req.publicacion.idTema, (int)req.sesion.usuario.id, req.publicacion.titulo, req.publicacion.mensaje, ref idReturn, ref idError, ref errorBd);
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

        public ResObtenerPublicacionIdUsuario obteneListaDePublicacionesPorIdUsuario(ReqObtenerPublicacionPorIdUsuario req)
        {
           
            ResObtenerPublicacionIdUsuario res = new ResObtenerPublicacionIdUsuario();
          
            res.listaDeErrores = new List<string>();
            //  ReqIngresarPublicacion req = new ReqIngresarPublicacion();
            ReqBase reqBase = new ReqBase();
        //    reqBase.sesion = req.sesion;

            ResBase resBase = new ResBase();
            resBase = logicaSesionValida.validarSesion(reqBase);

           // if (resBase.tipoRegistro != 1 || !resBase.resultado)
           /* {
                //algo salió mal en la sesión
                res.listaDeErrores = resBase.listaDeErrores;
                res.tipoRegistro = resBase.tipoRegistro;
                res.resultado = resBase.resultado;
            }*/
          //  else
          //  {
                try
                {

                    ConnectionDataContext linq = new ConnectionDataContext();
                    List<sp_obtener_publicacion_por_id_usuarioResult> listaDeLinq = new List<sp_obtener_publicacion_por_id_usuarioResult>();
                    listaDeLinq = linq.sp_obtener_publicacion_por_id_usuario(req.Id).ToList();
                    res.listaDepublicacionPorUsuario = listaDeLinq.Select(item => new Publicacion
                    {
                        idPublicacion = (int)item.publicacion_id, 
                        usuario = new Usuario { Id = (int)item.usuario_id },
                        fechaPublicacion = item.publicacion_fecha ?? DateTime.MinValue, 
                        descripcionPublicacion = item.publicacion_descripcion,
                        precioPublicacion = item.publicacion_precio ?? 0m, 
                        categoriaPublicacion = item.publicacion_categoria,
                        estadoPublicacion = (int)(item.publicacion_estado ?? 0) 
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
    }
    

}
