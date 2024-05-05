using Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Utilitarios
{
    public class Utilitarios
    {

        public static void crearBitacora(List<String> listaDeErrores, short tipo, string laClase, string elMetodo, string elRequest, string elResponse)
        {
            try
            {
                ConnectionDataContext linq = new ConnectionDataContext();
              //  linq.SP_INSERTAR_BITACORA(laClase, elMetodo, tipo, listaDeErrores.ToString(), elRequest, elResponse);
            }
            catch (Exception e)
            {
                //No se pudo bitacorear en BD. Bitacorear en archivo de texto plano.

                TextWriter loguearEnTexto = new StreamWriter("C:\\Users\\PC\\OneDrive - Universidad Nacional de Costa Rica\\Documentos\\UNA 2024\\MOVILES\\Bitacora\\logErroresEnBdXH.txt");
                loguearEnTexto.WriteLine("NO SE PUDO BITACOREAR EN BD EL MENSAJE DE ERROR FUE: " + e.StackTrace.ToString() + " --> CLASE: " + laClase + " METODO: " + elMetodo + " TIPO " + tipo + " DESCRIPCION " + listaDeErrores.ToString() + " REQ: " + elRequest + " RES " + elResponse + " FECHA: " + DateTime.Now.ToString());
            }
        }


    }
}
