﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunyStoreFrontEnd.Entidades
{
    public class ReqObtenerListaPublicaciones
    {
        public int idUsuario { get; set; }
        public string categoria { get; set; }
    }
}