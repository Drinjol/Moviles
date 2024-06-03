using System;
using System.Collections.Generic;

namespace Backend.Entidades
{
    public class ResBase
    {
        public short tipoRegistro {  get; set; }//1 correcto, 2 error de logica, 3 error de datos, 4 no controlado
        public bool resultado { get; set; }
        public string descripcion { get; set; }

        public List<String> listaDeErrores = new List<String>();
    }
}
