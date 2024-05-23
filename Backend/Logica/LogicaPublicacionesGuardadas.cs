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

            try
            {
                ConnectionDataContext linq = new ConnectionDataContext();
                List<SP_MOSTRAR_PUBLICACIONES_GUARDADASResult> listalinq = new List<SP_MOSTRAR_PUBLICACIONES_GUARDADASResult>();
                listalinq = linq.SP_MOSTRAR_PUBLICACIONES_GUARDADAS(req.usuarioid).ToList();

                foreach (SP_MOSTRAR_PUBLICACIONES_GUARDADASResult resultado in listalinq)
                {
                    PublicacionGuardada publicacion = new PublicacionGuardada();
                    publicacion.publicacion.idPublicacion = (int)resultado.tb_publicacion_id;
                    publicacion.publicacion.usuario.Id = (int)resultado.tb_usuario_id;
                    publicacion.fechaGuardado = resultado.

                    publicacionesGuardadas.Add(publicacion);
                }

                res.listaDePublicacionesGuardadas = publicacionesGuardadas;
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


    }
}
