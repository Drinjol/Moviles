
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
                    resBase.listaDeErrores.Add("Request Null");
                    resBase.tipoRegistro = 2; //error en logica
                    resBase.resultado = false;
                }
                else
                {
                    // si la sesion es nula
                    if (req.sesion == null)
                    {
                        resBase.listaDeErrores.Add("sesion nula");
                        resBase.tipoRegistro = 2; //error en logica
                        resBase.resultado = false;
                    }
                    else if (String.IsNullOrEmpty(req.sesion.sesion))
                    {//sino es nula pero el string viene vacio
                        resBase.listaDeErrores.Add("sesion no iniciada"); 
                        resBase.resultado = false;
                        resBase.tipoRegistro = 2;
                    }
                    else if (!req.sesion.esValido)
                    {//sino es vacio pero la sesión está vencida
                        resBase.listaDeErrores.Add("sesion vencida");
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
                resBase.listaDeErrores.Add("error no controlado");
                resBase.resultado = false;
                resBase.tipoRegistro = 3;
            }
            return resBase;
        }
    }
}
