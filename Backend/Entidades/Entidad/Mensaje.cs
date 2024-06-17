
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Mensaje
    {

        public int idMensaje { get; set; }

        public string contenido { get; set; }
        
        public int idUsuario { get; set; }

        public int idchat { get; set; }
        public DateTime fechaEnvio { get; set; }

        public bool estado { get; set; }

        public string URLimg { get; set; }



    }
}
