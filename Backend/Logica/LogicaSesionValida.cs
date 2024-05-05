
using Backend.Entidades;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Backend.Logica
{
    public class LogicaSesionValida
    {
        public ResBase validarSesion(ReqBase req)
        {
            ResBase resBase = new ResBase();
            try
            {
                //si la sesion es nula
                if (req==null)
                {
                    resBase.resultadoTexto = "Request Null";
                    resBase.tipoRegistro = 2; //error en logica
                    resBase.resultado = false;
                }
                else
                {
                    // si la sesion es nula
                    if (req.sesion == null)
                    {
                        resBase.resultadoTexto = "Sesion no iniciada";
                        resBase.tipoRegistro = 2; //error en logica
                        resBase.resultado = false;
                    }
                    else if (String.IsNullOrEmpty(req.sesion.sesion))
                    {//sino es nula pero el string viene vacio
                        resBase.resultadoTexto = "Sesion vacia";
                        resBase.resultado = false;
                        resBase.tipoRegistro = 2;
                    }
                    else if (!req.sesion.esValido)
                    {//sino es vacio pero la sesión está vencida
                        resBase.resultadoTexto = "Sesion vencida";
                        resBase.resultado = false;
                        resBase.tipoRegistro = 2;
                    }
                    else
                    {
                        //la sesión es válida!!!!
                        resBase.tipoRegistro = 1;
                        resBase.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                resBase.resultadoTexto = "Error no controlado";
                resBase.resultado = false;
                resBase.tipoRegistro = 3;
            }
            return resBase;
        }
    }
}
