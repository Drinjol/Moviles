using Backend.DataAccess;
using Backend.Entidades;
using System;
using System.Linq;

namespace Backend.Logica
{
    public class LogicaIniciarSesion
    {
        public ResIniciarSesion iniciarSesion(ReqIniciarSesion req)
        {
            ResIniciarSesion res = new ResIniciarSesion();
            if (String.IsNullOrEmpty(req.correo) || String.IsNullOrEmpty(req.password))
            {
                res.listaDeErrores.Add("Datos Inconsistentes");
                res.tipoRegistro = 3;
                res.resultado = false;
            }
            else
            {
                try
                {
                    ConnectionDataContext linq = new ConnectionDataContext();
                    sp_validar_inicio_sesionResult usuarioLinq = linq.sp_validar_inicio_sesion(req.correo).FirstOrDefault();
                    if (usuarioLinq!=null)
                    {
                        Usuario usuario = new Usuario();
                        this.crearUsuarioLinq(usuario, usuarioLinq);
                        if (usuario.password == req.password)
                        {
                            //sesion exitosa
                            res.listaDeErrores.Add("sesion valida");
                            res.tipoRegistro = 1;
                            res.resultado = true;
                            res.usuario = usuario;
                        }
                        else
                        {
                            //datos no validos
                            res.listaDeErrores.Add("password no valido");
                            res.tipoRegistro = 2;
                            res.resultado = false;
                        }
                    }
                    else
                    {
                        //datos no validos
                        res.listaDeErrores.Add("correo no valido");
                        res.tipoRegistro = 2;
                        res.resultado = false;
                    }
                   
                }
                catch(Exception ex) {
                    res.listaDeErrores.Add(ex.Message);
                    res.tipoRegistro = 4;
                    res.resultado = false;
                }
            }
            return res;
        }

        public void crearUsuarioLinq(Usuario usuario, sp_validar_inicio_sesionResult usuarioLinq)
        {
            usuario.nombre = String.IsNullOrEmpty(usuarioLinq.tb_usuario_nombre) ? "" : usuarioLinq.tb_usuario_nombre;
            usuario.apellidos = String.IsNullOrEmpty(usuarioLinq.tb_usuario_apellidos) ? "" : usuarioLinq.tb_usuario_apellidos;
            usuario.email = String.IsNullOrEmpty(usuarioLinq.tb_usuario_email) ? "" : usuarioLinq.tb_usuario_email;
            usuario.descripcion = String.IsNullOrEmpty(usuarioLinq.tb_usuario_descripcion) ? "" : usuarioLinq.tb_usuario_descripcion;
            usuario.password = String.IsNullOrEmpty(usuarioLinq.tb_usuario_password) ? "" : usuarioLinq.tb_usuario_password;
            usuario.calificacion = usuarioLinq.tb_usuario_calificacion == null ? 0 : (int)usuarioLinq.tb_usuario_calificacion;
            usuario.direccion = String.IsNullOrEmpty(usuarioLinq.tb_usuario_direccion) ? "" : usuarioLinq.tb_usuario_direccion;
            usuario.estado = usuarioLinq.tb_usuario_estado == null ? 0 : (int)usuarioLinq.tb_usuario_estado;
            usuario.Id = usuarioLinq.tb_usuario_id == 0 ? 0 : (int)usuarioLinq.tb_usuario_id;
            usuario.telefono = String.IsNullOrEmpty(usuarioLinq.tb_usuario_telefono) ? "" : usuarioLinq.tb_usuario_telefono;
        }

    }
}
