﻿using Backend.DataAccess;
using Backend.Entidades;
using System;

namespace Backend.Logica
{
    public class LogicaAgregarInteraccionUsuario
    {
        public ResAgregarInteraccionUsuario agregarInteraccionUsuario(ReqAgregarInteraccionUsuario req)
        {
            ResAgregarInteraccionUsuario result = new ResAgregarInteraccionUsuario();
            if (req.id_usuario == 0 || req.id_publicacion == 0 || req.fecha_busqueda == null) 
            {
                result.listaDeErrores.Add("datos invalidos");
                result.tipoRegistro = 2;
                result.resultado = false;
            }
            else
            {
                // si llega hasta acá es porque todo salió bien hasta el momento
                try
                {
                    ConnectionDataContext linq = new ConnectionDataContext();
                    //linq.sp_agregar_interaccion_usuario(req.id_publicacion, req.id_usuario, req.fecha_busqueda);

                    result.resultado = true;
                    result.listaDeErrores.Add("success");
                    result.tipoRegistro = 1;
                }
                catch (Exception e)
                {
                    result.listaDeErrores.Add("Error de BD");
                    result.tipoRegistro = 4;
                    result.resultado = false;
                }
            }

            return null;
        }
    }
}
