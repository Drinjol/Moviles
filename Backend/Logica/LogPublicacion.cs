using Backend.DataAccess;
using Backend.Entidades;
using Backend.Entidades.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
            ResObtenerPublicaciones res = new ResObtenerPublicaciones();
            res.listaDeErrores = new List<string>();
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

        public ResBuscarPublicaciones buscarPublicaciones(ReqBuscarPublicaciones req)
        {
            Int16 tipoDeTransaccion = 0;
            string descripcionError = "";
            int? errorId = 0;
            ResBuscarPublicaciones res = new ResBuscarPublicaciones();
            res.listaDeErrores = new List<string>();




            try
            {

                ConnectionDataContext linq = new ConnectionDataContext();
                List<SP_BUSCAR_PUBLICACIONESResult> listaDeLinq = new List<SP_BUSCAR_PUBLICACIONESResult>();
                listaDeLinq = linq.SP_BUSCAR_PUBLICACIONES(req.Palabra).ToList();
                res.publicaciones = this.crearListaDePublicacionesBuscadas(listaDeLinq);
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

        private List<Publicacion> crearListaDePublicacionesBuscadas(List<SP_BUSCAR_PUBLICACIONESResult> listaDeLinq)
        {
            List<Publicacion> listaArmada = new List<Publicacion>();
            foreach (SP_BUSCAR_PUBLICACIONESResult tipoComplejo in listaDeLinq)
            {
                listaArmada.Add(this.crearPublicacionBuscadas(tipoComplejo));
            }
            return listaArmada;
        }

        private Publicacion crearPublicacionBuscadas(SP_BUSCAR_PUBLICACIONESResult unTipoComplejo)
        {

            ConnectionDataContext linq = new ConnectionDataContext();

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
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en Lógica - 3 Error No Controlado
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
                    if (String.IsNullOrEmpty(req.publicacion.descripcionPublicacion))
                    {
                        res.listaDeErrores.Add("Descripción faltante");
                        res.resultado = false;
                        tipoRegistro = 2;
                    }
                    if (String.IsNullOrEmpty(req.publicacion.categoriaPublicacion))
                    {
                        res.listaDeErrores.Add("Categoría faltante");
                        res.resultado = false;
                        tipoRegistro = 2;
                    }
                    if (String.IsNullOrEmpty(req.publicacion.nombresArchivos))
                    {
                        res.listaDeErrores.Add("Imágenes faltantes");
                        res.resultado = false;
                        tipoRegistro = 2;
                    }

                    if (!res.listaDeErrores.Any())
                    {
                        ConnectionDataContext linq = new ConnectionDataContext();
                        int? idReturn = 0;
                        int? idError = 0;
                        string errorBd = "";

                        //string imagen = string.Join(";", req.publicacion.nombresArchivos);

                        linq.SP_INGRESAR_PUBLICACION(req.publicacion.usuario.Id, req.publicacion.descripcionPublicacion, req.publicacion.precioPublicacion, req.publicacion.categoriaPublicacion, req.publicacion.nombresArchivos, ref idReturn, ref idError, ref errorBd);

                        if (idError == null || idError != 0)
                        {
                            res.resultado = false;
                            res.listaDeErrores.Add("Error BD");
                            tipoRegistro = 2;
                        }
                        else
                        {
                            res.resultado = true;
                            res.listaDeErrores.Add("Éxito");
                            res.tipoRegistro = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add("Error interno");
                tipoRegistro = 3;
            }
            finally
            {
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoRegistro, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }





        public ResObtenerPublicacionIdUsuario obteneListaDePublicacionesPorIdUsuario(ReqObtenerPublicacionPorIdUsuario req)
        {
            ResObtenerPublicacionIdUsuario res = new ResObtenerPublicacionIdUsuario();
            res.listaDeErrores = new List<string>();
            ReqBase reqBase = new ReqBase();
            ResBase resBase = new ResBase();
            resBase = logicaSesionValida.validarSesion(reqBase);

            try
            {
                ConnectionDataContext linq = new ConnectionDataContext();
                List<sp_obtener_publicacion_por_id_usuarioResult> listaDeLinq = new List<sp_obtener_publicacion_por_id_usuarioResult>();
                listaDeLinq = linq.sp_obtener_publicacion_por_id_usuario(req.Id).ToList();
                res.listaDepublicacionPorUsuario = listaDeLinq
                    .Select(item => new Publicacion
                    {
                        idPublicacion = (int)item.publicacion_id,
                        usuario = new Usuario
                        {
                            Id = (int)item.usuario_id,
                            nombre = item.nombre_usuario, // Map user data properties
                            apellidos = item.apellidos_usuario
                        },
                        fechaPublicacion = item.publicacion_fecha ?? DateTime.MinValue,
                        descripcionPublicacion = item.publicacion_descripcion,
                        precioPublicacion = item.publicacion_precio ?? 0m,
                        categoriaPublicacion = item.publicacion_categoria,
                        nombresArchivos = HexStringToString(item.imagen_binario),
                        estadoPublicacion = (int)(item.publicacion_estado ?? 0),

                        favorito = item.IsFavorito ?? false // Assuming this is the correct field
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

            return res;
        }
        public ResEliminarPublicacion eliminarPublicacion(ReqEliminarPublicacion req)
        {
            Int16 tipoDeTransaccion = 0;
            ResEliminarPublicacion res = new ResEliminarPublicacion();
            res.listaDeErrores = new List<string>();

            try
            {
                using (ConnectionDataContext linq = new ConnectionDataContext())
                {

                    linq.SP_ELIMINAR_PUBLICACION(req.usuarioid, req.Id);
                    res.resultado = true;

                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                tipoDeTransaccion = 2;
                res.listaDeErrores.Add("Error de BD: " + ex.Message);
            }
            finally
            {
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoDeTransaccion, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }

            return res;
        }


        public ResActualizarPublicacion actualizarPublicacion(ReqActualizarPublicacion req)
        {
            short tipoRegistro = 0; // 1 Exitoso - 2 Error en Lógica - 3 Error No Controlado
            ResActualizarPublicacion res = new ResActualizarPublicacion();

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
                    if (req.IdPublicacion <= 0)
                    {
                        res.listaDeErrores.Add("ID de publicación no válido");
                        res.resultado = false;
                        tipoRegistro = 2;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(req.DescripcionPublicacion))
                        {
                            res.listaDeErrores.Add("Descripción faltante");
                            res.resultado = false;
                            tipoRegistro = 2;
                        }
                        if (String.IsNullOrEmpty(req.CategoriaPublicacion))
                        {
                            res.listaDeErrores.Add("Categoría faltante");
                            res.resultado = false;
                            tipoRegistro = 2;
                        }

                        if (!res.listaDeErrores.Any())
                        {
                            ConnectionDataContext linq = new ConnectionDataContext();
                            int? idError = 0;
                            int? idReturn = 0;
                            string errorBd = "";

                            linq.SP_ACTUALIZAR_PUBLICACION(req.IdPublicacion, req.DescripcionPublicacion, req.PrecioPublicacion, req.CategoriaPublicacion, req.NombresArchivos, ref idReturn, ref idError, ref errorBd);

                            if (idError == null || idError != 0)
                            {
                                res.resultado = false;
                                res.listaDeErrores.Add("Error BD");
                                tipoRegistro = 2;
                            }
                            else
                            {
                                res.resultado = true;
                                res.listaDeErrores.Add("Publicación actualizada correctamente");
                                res.tipoRegistro = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add("Error interno");
                tipoRegistro = 3;
            }
            finally
            {
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoRegistro, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }

            return res;
        }


        public ResObtenerPublicacionIdUsuario publicaciones_por_usuarioID(ReqObtenerPublicacionPorIdUsuario req)
        {
            Int16 tipoDeTransaccion = 0;
            string descripcionError = "";
            int? errorId = 0;
            ResObtenerPublicacionIdUsuario res = new ResObtenerPublicacionIdUsuario();
            res.listaDeErrores = new List<string>();

            try
            {

                ConnectionDataContext linq = new ConnectionDataContext();
                List<sp_obtener_publicacion_por_id_usuarioResult> listaDeLinq = new List<sp_obtener_publicacion_por_id_usuarioResult>();
                listaDeLinq = linq.sp_obtener_publicacion_por_id_usuario(req.Id).ToList();
                res.listaDepublicacionPorUsuario = this.crearListaDePublicacionesPorIdUsuario(listaDeLinq);
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

        private List<Publicacion> crearListaDePublicacionesPorIdUsuario(List<sp_obtener_publicacion_por_id_usuarioResult> listaDeLinq)
        {
            List<Publicacion> listaArmada = new List<Publicacion>();
            foreach (sp_obtener_publicacion_por_id_usuarioResult publicaciones in listaDeLinq)
            {
                listaArmada.Add(this.crear_publicacion_usuario_id(publicaciones));
            }
            return listaArmada;
        }


        private Publicacion crear_publicacion_usuario_id(sp_obtener_publicacion_por_id_usuarioResult publicaciones)
        {

            ConnectionDataContext linq = new ConnectionDataContext();
            ReqObtenerPublicacionPorIdUsuario req = new ReqObtenerPublicacionPorIdUsuario();
            Publicacion pub = new Publicacion();
            pub.usuario = new Usuario();

            pub.idPublicacion = (int)publicaciones.publicacion_id;
            pub.fechaPublicacion = (DateTime)publicaciones.publicacion_fecha;
            pub.descripcionPublicacion = publicaciones.publicacion_descripcion;
            pub.precioPublicacion = (decimal)publicaciones.publicacion_precio;
            pub.nombresArchivos = HexStringToString(publicaciones.imagen_binario);
            pub.estadoPublicacion = (int)publicaciones.publicacion_estado;

            pub.usuario.Id = (int)publicaciones.usuario_id;
            pub.usuario.nombre = publicaciones.nombre_usuario;
            pub.usuario.apellidos = publicaciones.apellidos_usuario;
            pub.usuario.descripcion = publicaciones.publicacion_descripcion;
            pub.usuario.direccion = publicaciones.tb_usuario_direccion;
            pub.usuario.email = publicaciones.tb_usuario_email;
            pub.usuario.telefono = publicaciones.tb_usuario_telefono;
            pub.favorito = (bool)publicaciones.IsFavorito;

            return pub;
        }



    }
    }
