using Backend.DataAccess;
using Backend.Entidades;
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
           
            public ResIngresarPublicacion ingresarPublicacion(ReqIngresarPublicacion req, ReqIngresarImagen reqImage)
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

                        if (req.sesion == null)
                        {

                            res.listaDeErrores.Add("Sesion null");
                            res.resultado = false;
                            tipoRegistro = 2;
                        }
                        else
                        {

                            if (String.IsNullOrEmpty(req.sesion.sesion))
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
                        }


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
                        if (!res.listaDeErrores.Any()) // Lista vacia 

                        {

                           ConnectionDataContext linq = new ConnectionDataContext();
                          // linq.tb_imagen_binario.

                            var nuevaImagen = new tb_imagen_binario
                            {
                               // tb_publicacion_id = 1,
                                tb_imagen_binario1 = File.ReadAllBytes("C:\\Users\\PC\\OneDrive - Universidad Nacional de Costa Rica\\Escritorio\\Cristiano_Ronaldo_2018.jpg"),
                                tb_imagen_extension = ".jpg"
                            };

                        linq.tb_imagen_binario.InsertOnSubmit(nuevaImagen);
                        linq.SubmitChanges();

                        int? idReturn = 0;
                            int? idError = 0;
                            string errorBd = "";

                        linq.SP_INGRESAR_PUBLICACION(req.sesion.usuario.Id, req.publicacion.descripcionPublicacion, req.publicacion.precioPublicacion, req.publicacion.categoriaPublicacion, reqImage.imagen.extension, ref idReturn, ref idError, ref errorBd);
                           // linq.SP_INGRESAR_PUBLICACION(req.publicacion.idTema, (int)req.sesion.usuario.id, req.publicacion.titulo, req.publicacion.mensaje, ref idReturn, ref idError, ref errorBd);
                            if (idError == null || idError == 0)
                            {
                                res.resultado = false;
                                res.listaDeErrores.Add(errorBd); //GRAVISIMO!!!
                                tipoRegistro = 2; //No Exitoso
                            }
                            else
                            {
                                res.resultado = true;
                                tipoRegistro = 1; //Exitoso
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
