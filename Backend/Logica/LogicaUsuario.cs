using Backend.DataAccess;
using Backend.Entidades;
using Backend.Entidades.Response;
using System;
namespace Backend.Logica
{
    public class LogicaUsuario
    {
        public LogicaSesionValida logicaSesionValida = new LogicaSesionValida();
        // Registro de nuevo usuario 
        public ResAgregarUsuario agregarUsuario(ReqAgregarUsuario req)
        {

            ResAgregarUsuario res = new ResAgregarUsuario();
            if (String.IsNullOrEmpty(req.usuario.nombre)|| String.IsNullOrEmpty(req.usuario.apellidos)||
                String.IsNullOrEmpty(req.usuario.email)|| String.IsNullOrEmpty(req.usuario.password)||
                String.IsNullOrEmpty(req.usuario.direccion)|| String.IsNullOrEmpty(req.usuario.telefono)
                )
            {
                res.listaDeErrores.Add("Datos Inconsistentes");
                res.tipoRegistro = 3;
                res.resultado = false;
            }
            else
            {
                // si llega hasta acá es porque todo salió bien hasta el momento
                try
                {
                    ConnectionDataContext linq = new ConnectionDataContext();
                    string descripcion = string.IsNullOrEmpty(req.usuario.direccion) ? "" : req.usuario.direccion;
                    linq.sp_CrearUsuario(req.usuario.nombre, req.usuario.apellidos
                        , req.usuario.email, req.usuario.password, req.usuario.direccion, 
                        req.usuario.telefono, descripcion);

                    res.resultado = true;
                    res.listaDeErrores.Add("success");
                    res.tipoRegistro = 1;
                }
                catch (Exception e)
                {
                    res.listaDeErrores.Add("Error de BD");
                    res.tipoRegistro = 4;
                    res.resultado = false;
                }
            }
            
            return res;
        }

        public ResActualizarUsuario ActualizarUsuario(ReqActualizarUsuario req)
        {
            ResActualizarUsuario res = new ResActualizarUsuario();
            ReqBase reqBase = new ReqBase();
            reqBase.sesion = req.sesion;

            ResBase resBase = new ResBase();
            // resBase = logicaSesionValida.validarSesion(reqBase);

            // if (resBase.tipoRegistro != 1 || !resBase.resultado)
            // {
            res.listaDeErrores = resBase.listaDeErrores;
            res.tipoRegistro = resBase.tipoRegistro;
            res.resultado = resBase.resultado;
            // }
            // else
            // {
            if (String.IsNullOrEmpty(req.nombre) || String.IsNullOrEmpty(req.apellidos) ||
                String.IsNullOrEmpty(req.email) || String.IsNullOrEmpty(req.password) ||
                String.IsNullOrEmpty(req.direccion) || String.IsNullOrEmpty(req.telefono))
            {
                res.listaDeErrores.Add("Datos Inconsistentes");
                res.tipoRegistro = 3;
                res.resultado = false;
            }
            else
            {
                try
                {
                    using (ConnectionDataContext linq = new ConnectionDataContext())
                    {
                        linq.sp_ActualizarUsuario(req.Id, req.nombre, req.apellidos,
                            req.email, req.direccion, req.telefono, req.descripcion, req.password);

                        res.resultado = true;
                        res.listaDeErrores.Add("success");
                        res.tipoRegistro = 1;
                    }
                }
                catch (Exception ex)
                {
                    res.listaDeErrores.Add("Error de BD: " + ex.Message); // Registrar el mensaje de excepción
                    res.tipoRegistro = 4;
                    res.resultado = false;
                }
                // }
            }
            return res;
        }

    }

}
