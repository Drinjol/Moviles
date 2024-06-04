using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ReqObtenerPublicaciones:ReqBase
    {
        public string categoria { get; set; }
        public int usuarioID { get; set; }

    }
}
