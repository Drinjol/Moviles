using Backend.DataAccess;
using Backend.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Logica
{
    public class LogicaPublicacionesGuardadas
    {

        public ResObtenerPublicacionesGuardadas obtenerpublicacionesGuardadas(ReqObtenerPublicacionesGuardadas req)
        {
            Int16 tipoDeTransaccion = 0;
            ResObtenerPublicacionesGuardadas res = new ResObtenerPublicacionesGuardadas();
            res.listaDeErrores = new List<string>();
            List<PublicacionGuardada> publicacionesGuardadas = new List<PublicacionGuardada>();

            try
            {
                ConnectionDataContext linq = new ConnectionDataContext();
                List<SP_MOSTRAR_PUBLICACIONES_GUARDADASResult> listalinq = new List<SP_MOSTRAR_PUBLICACIONES_GUARDADASResult>();
                listalinq = linq.SP_MOSTRAR_PUBLICACIONES_GUARDADAS(req.usuarioid).ToList();

                foreach (SP_MOSTRAR_PUBLICACIONES_GUARDADASResult resultado in listalinq)
                {
                    //inicializar instancias
                    PublicacionGuardada publicacionGuardada = new PublicacionGuardada();
                    publicacionGuardada.publicacion = new Publicacion();
                    publicacionGuardada.publicacion.usuario = new Usuario();

                    //mapear
                    publicacionGuardada.idPublicacionGuardada = (int)resultado.tb_lista_deseos_id;
                    publicacionGuardada.publicacion.idPublicacion = (int)resultado.tb_publicacion_id;
                    publicacionGuardada.publicacion.usuario.Id = (int)resultado.tb_usuario_id;
                    publicacionGuardada.fechaGuardado = (DateTime)resultado.tb_lista_deseos_creacion;
                    publicacionGuardada.estadoGuardado = (int)resultado.tb_lista_deseos_estado;
                    
                    
                    publicacionGuardada.publicacion.descripcionPublicacion = resultado.tb_publicacion_descripcion;
                    publicacionGuardada.publicacion.fechaPublicacion = (DateTime)resultado.tb_publicacion_fecha;
                    publicacionGuardada.publicacion.precioPublicacion = (decimal)resultado.tb_publicacion_precio;
                    publicacionGuardada.publicacion.estadoPublicacion = (int)resultado.tb_publicacion_estado;
                    

                    publicacionesGuardadas.Add(publicacionGuardada);
                }

                res.listaPublicacionGuardada = publicacionesGuardadas;
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


        public ResAgregarPublicacionGuardada agregarPublicacionGuardada(ReqAgregarPublicacionGuardada req)
        {
            Int16 tipoDeTransaccion = 0;
            ResAgregarPublicacionGuardada res = new ResAgregarPublicacionGuardada();
            res.listaDeErrores = new List<string>();

            try
            {
                using (ConnectionDataContext linq = new ConnectionDataContext())
                {
                    int? RESULTADO = 0;
                    String MENSAJE = "";
                    linq.SP_GUARDAR_PUBLICACION_DESEO(req.idUsuario, req.idPublicacion, ref RESULTADO, ref MENSAJE);
                    
                    if(RESULTADO == 1)
                    {
                        res.resultado = true;
                        res.descripcion = MENSAJE;

                    }
                    else if(RESULTADO == 2)
                    {
                        res.resultado = false;
                        res.descripcion = MENSAJE;
                        res.listaDeErrores.Add(MENSAJE);
                    }
                    else if (RESULTADO == 3)
                    {
                        res.resultado = false;
                        res.descripcion = MENSAJE;
                        res.listaDeErrores.Add(MENSAJE);
                    }                                        
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                tipoDeTransaccion = 2;
                res.listaDeErrores.Add("Error bd");
            }
            finally
            {
                Utilitarios.Utilitarios.crearBitacora(res.listaDeErrores, tipoDeTransaccion, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(req), JsonConvert.SerializeObject(res));
            }
            return res;
        }


        public ResEliminarPublicacionGuardada eliminarPublicacionGuardada(ReqEliminarPublicacionGuardada req)
        {
            Int16 tipoDeTransaccion = 0;
            ResEliminarPublicacionGuardada res = new ResEliminarPublicacionGuardada();
            res.listaDeErrores = new List<string>();

            try
            {
                using (ConnectionDataContext linq = new ConnectionDataContext())
                {
                    linq.SP_ELIMINAR_PUBLICACION_LISTA_DESEO(req.usuarioid, req.publicacionGuardadaId);
                    res.resultado = true;
                    
                }
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


    }
}
