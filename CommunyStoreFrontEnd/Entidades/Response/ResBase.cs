﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunyStoreFrontEnd.Entidades
{
    public class ResBase
    {
        public short tipoRegistro { get; set; }//1 correcto, 2 error de logica, 3 error de datos, 4 no controlado
        public bool resultado { get; set; }

        public List<String> listaDeErrores {  get; set; }

       
    }
}